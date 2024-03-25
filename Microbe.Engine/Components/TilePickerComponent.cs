using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microbe.Engine.Components
{
    public partial class TilePickerComponent : UserControl
    {

        MicrobeGraphics _graphics;
        Timer _timer;
        int _copySource;

        public TilePickerComponent(MicrobeGraphics graphics)
        {
            InitializeComponent();
            SelectedTiles = new List<int>();
            _graphics = graphics;
            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Tick += (s, e) => TileRenderContainer.Invalidate();
            _timer.Start();

            TileRenderContainer.ContextMenuStrip = new ContextMenuStrip();
            TileRenderContainer.ContextMenuStrip.Items.Add("Copy", null, (s, e) =>
            {
              
                _copySource = SelectedTiles.FirstOrDefault();
            });
            TileRenderContainer.ContextMenuStrip.Items.Add("Paste", null, (s, e) =>
            {
                var srcTile = _graphics.GetTileData(_copySource);
               
                var destTile = SelectedTiles.FirstOrDefault();
                _graphics.SetTileData(destTile, srcTile);
                

               
            });
            TileRenderContainer.ContextMenuStrip.Items.Add("Clear", null, (s, e) =>
            {
                foreach (var tile in SelectedTiles)
                {
                    _graphics.SetTileData(tile, new byte[64]);
                }
            });
            TileRenderContainer.ContextMenuStrip.Items.Add("Flip X", null, (s, e) =>
            {
                foreach (var tile in SelectedTiles)
                {
                    var srcTile = _graphics.GetTileData(tile);
                    var destTile = new byte[64];

                    for(int y = 0; y < 8; y++)
                    {
                        for(int x = 0; x < 8; x++)
                        {
                            destTile[(y * 8) + x] = srcTile[(y * 8) + (7 - x)];
                        }
                    }
                    _graphics.SetTileData(tile, destTile);
                }
               
            });
            TileRenderContainer.ContextMenuStrip.Items.Add("Flip Y", null, (s, e) =>
            {
                foreach (var tile in SelectedTiles)
                {
                    var srcTile = _graphics.GetTileData(tile);
                    var destTile = new byte[64];

                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            destTile[(y * 8) + x] = srcTile[((7 - y) * 8) + x];
                        }
                    }
                    _graphics.SetTileData(tile, destTile);
                }
            });

            TileRenderContainer.ContextMenuStrip.Items.Add("Rotate", null, (s, e) =>
            {
                foreach (var tile in SelectedTiles)
                {
                    var srcTile = _graphics.GetTileData(tile);
                    var destTile = new byte[8*8];

                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            destTile[(y * 8) + x] = srcTile[((7 - x) * 8) + y];
                        }
                    }
                   
                    _graphics.SetTileData(tile, destTile);
                }
            });
            
        }

        public TilePickerComponent() : this(null) { }

        public List<int> SelectedTiles { get; private set; }

        public Action<List<int>> OnSelectedTilesChanged;

        public MicrobeGraphics Graphics { get { return _graphics; } set { _graphics = value; } }

        int _startX;
        int _startY;
        int _endX;
        int _endY;
        bool _isMouseDown = false;

        private void TileRenderContainer_MouseDown(object sender, MouseEventArgs e)
        {
            _startX = e.X;
            _startY = e.Y;
            _isMouseDown = true;
        }

        private void TileRenderContainer_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                _endX = e.X;
                _endY = e.Y;
                _isMouseDown = false;

                var tileSize = TileRenderContainer.Width / 4;

                SelectedTiles.Clear();

                var tx = _startX / tileSize;
                var ty = (_startY / tileSize) + tileScroll.Value;
                var ex = _endX / tileSize;
                var ey = (_endY / tileSize) + tileScroll.Value;

                for (int row = ty; row <= ey; row++)
                {
                    for (int col = tx; col <= ex; col++)
                    {
                        SelectedTiles.Add(((row) * 4) + col);
                    }
                }
                this.SelectedRangeLabel.Text = $"Selected Range: {string.Join(",", SelectedTiles)}";

                if(OnSelectedTilesChanged != null)
                    OnSelectedTilesChanged(SelectedTiles);
            }
        }

        private void TileRenderContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                _endX = e.X;
                _endY = e.Y;
            }
        }

        private void TileRenderContainer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            if (_graphics == null)
                return;
            int i = tileScroll.Value * 4;

            var tileSize = TileRenderContainer.Width / 4;

            for (int row = 0; row < 32; row++)
            {
                for (int col = 0; col < 4; col++)
                {


                    if (SelectedTiles.Contains(i))
                    {
                        e.Graphics.DrawRectangle(Pens.Red,
                            (col * tileSize) - 1, (row * tileSize) - 1,
                            tileSize + 2, tileSize + 2);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(Pens.DarkRed,
                           (col * tileSize), ((row) * tileSize),
                           tileSize, tileSize);
                    }

                    if (i < 256)
                    {
                        e.Graphics.DrawImage(_graphics.TileDataCache[i++],
                            (col * tileSize) + 1, ((row) * tileSize) + 1,
                            tileSize - 2, tileSize - 2);
                    }
                }
            }

            if(_isMouseDown)
            {
                e.Graphics.DrawRectangle(Pens.White,
                    _startX, _startY,
                    _endX - _startX, _endY - _startY);
            }
        }

        private void tileScroll_Scroll(object sender, ScrollEventArgs e)
        {
            TileRenderContainer.Invalidate();
        }
    }
}
