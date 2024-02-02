using Jint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microbe_engine
{
    public class Tile
    {
        public byte[] Data { get; set; }

        public Tile()
        {
            var r = new Random();
            Data = new byte[8 * 8];
            for (int i = 0; i < 64; i++)
            {
                Data[i] = (byte)(r.Next() % 4);
            }
        }

        public void BakeImage(Bitmap b)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    var c = Data[y * 8 + x] switch
                    {
                        0 => Color.Transparent,
                        1 => Color.Black,
                        2 => Color.DarkGray,
                        3 => Color.Gray,
                        _ => Color.Red
                    };
                    b.SetPixel(x, y, c);
                }
            }
        }
    }
    public class TileRam
    {

        public Tile[] Data { get; set; }
        public Bitmap[] BakedTiles { get; set; }

        public TileRam()
        {
            Data = new Tile[256];
            BakedTiles = new Bitmap[256];
            for (int i = 0; i < 256; i++)
            {
                Data[i] = new Tile();
                BakedTiles[i] = new Bitmap(8, 8);
                Data[i].BakeImage(BakedTiles[i]);
            }
        }

        public void SetTile(byte tileIndex, byte[] data)
        {

            this.Data[tileIndex].Data = data;
            this.Data[tileIndex].BakeImage(BakedTiles[tileIndex]);
        }

    }



    public class VRAM
    {
        public byte[] Data { get; set; }
        public TileRam TileRam { get; set; }
        public Bitmap BakedVRam { get; set; }

        public VRAM()
        {
            TileRam = new TileRam();
            Data = new byte[32 * 32];

            var r = new Random();
            for (int i = 0; i < 32 * 32; i++)
            {
                Data[i] = (byte)(r.Next() % 2);
            }

            BakedVRam = new Bitmap(256, 256);
            CopyToBakedVram();
        }

        public void SetVramValue(int x, int y, byte value)
        {
            Data[y * 32 + x] = value;
            
        }

        public void CopyToBakedVram()
        {
            using (var g = Graphics.FromImage(BakedVRam))
            {

                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        g.DrawImage(TileRam.BakedTiles[Data[y * 32 + x]], new Point(x * 8, y * 8));
                    }
                }

            }

        }
    }

    internal class MainForm : Form
    {
        private Bitmap _backBuffer;

        public VRAM VRam;

        public byte ScrollX { get; set; }
        public byte ScrollY { get; set; }

        private Engine _engine;

        private ScriptingContext _scriptingContext;

        public MainForm()
        {
            InitLayout();
            this.DoubleBuffered = true;
            _backBuffer = new Bitmap(160, 144);
            VRam = new VRAM();
            ScrollX = 0;
            ScrollY = 0;

            _engine = new Engine();
            _scriptingContext = new ScriptingContext(_engine, this);

            _scriptingContext.Run();

            _engine.Evaluate("set_tile(0,[1,1,1,1,1,1,1,1, 2,1,2,1,2,1,2,1, 2,2,2,2,2,2,2,2, 1,1,1,1,1,1,1,1, 2,3,2,3,2,3,2,3, 3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3])");

        }

        private void CopyVramToBackBuffer()
        {

            using (var ctx = Graphics.FromImage(_backBuffer))
            {

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        ctx.DrawImage(VRam.BakedVRam, new Point((j * 256) + ScrollX, (i * 256) + ScrollY));
                    }
                }
            }
        }

        private void CopyBackBufferToScreen(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, e.ClipRectangle);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(_backBuffer,
                Util.ScaleRectangle(new Rectangle(0, 0, _backBuffer.Width, _backBuffer.Height), e.ClipRectangle),
                new Rectangle(0, 0, 160, 144), GraphicsUnit.Pixel);
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            if (_scriptingContext.CommandQueue.Count >0)
            {
                var cmds = _scriptingContext.CommandQueue.Take(1000);
                foreach (var cmd in cmds)
                {
                   
                    cmd();
                }



            }


            using (var _primaryLayerContext = Graphics.FromImage(_backBuffer))
            {
                _primaryLayerContext.FillRectangle(Brushes.Black, new Rectangle(0, 0, _backBuffer.Width, _backBuffer.Height));
            }



            CopyVramToBackBuffer();
            CopyBackBufferToScreen(e);
            this.Invalidate();
            base.OnPaint(e);
        }


    }
}
