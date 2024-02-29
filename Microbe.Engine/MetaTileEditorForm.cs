using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microbe.Engine
{
    public partial class MetaTileEditorForm : Form
    {

        MicrobeGraphics _graphics;

        int _selectedTileIndex;
        bool _mouseIsDown;
        Timer _refreshTimer;

        public MetaTileEditorForm(MicrobeGraphics graphics)
        {
            _graphics = graphics != null ? graphics: new MicrobeGraphics();
            _selectedTileIndex = 0;
            _refreshTimer = new Timer();
            _refreshTimer.Interval = 100;
            _refreshTimer.Tick += RefreshTimer_Tick;
            _refreshTimer.Start();
            InitializeComponent();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            TileSelectorPictureBox.Invalidate();
            TileEditPictureBox.Invalidate();
        }

        protected override void OnLoad(EventArgs e)
        {
            Invalidate();
        }

        private int GetCols()
        {
            return (int)Math.Floor((double)TileSelectorPictureBox.ClientRectangle.Width / 32.0);
        }

        private void TileSelectorPictureBox_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.DarkSlateBlue);
            var cols = GetCols();

            int incX = 0;
            int incY = 0;

            for (int i = 0; i < 256; i++)
            {
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                g.DrawImage(_graphics.TileDataCache[i], new Rectangle(incX * 32, incY * 32, 32, 32), new Rectangle(0,0,8,8), GraphicsUnit.Pixel);

                if (i == _selectedTileIndex)
                {
                    g.DrawRectangle(Pens.Black, new Rectangle((incX * 32) - 1, (incY * 32) - 1, 34, 34));
                }

                incX = incX + 1;
                if (incX >= GetCols())
                {
                    incX = 0;
                    incY++;
                }


            }

          


        }


        private void TileSelectorPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (int)Math.Floor((double)e.Location.X / 32.0);
            int y = (int)Math.Floor((double)e.Location.Y / 32.0);

            var index = (y * GetCols()) + x;
            if (index < 256)
            {
                _selectedTileIndex = index;
            }
        }




        private void TileEditPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseIsDown = !(e.Button == MouseButtons.Left);
        }

        private void TileEditPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseIsDown
                && e.Location.X > 0
                && e.Location.Y > 0
                && e.Location.X < TileEditPictureBox.ClientRectangle.Width
                && e.Location.Y < TileEditPictureBox.ClientRectangle.Height)
            {
                PaintWithMouse(e);
            }

        }

        private void PaintWithMouse(MouseEventArgs e)
        {
            var lx = (int)Math.Floor(((double)e.Location.X / (double)(this.TileEditPictureBox.ClientRectangle.Width)) * 8.0);
            var ly = (int)Math.Floor(((double)e.Location.Y / (double)(this.TileEditPictureBox.ClientRectangle.Height)) * 8.0);



            var oldData = _graphics.GetTileData(_selectedTileIndex);
            oldData[(ly * 8) + lx] = 2;

            _graphics.SetTileData(_selectedTileIndex, oldData);
            Invalidate();
        }

        private void TileEditPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseIsDown = (e.Button == MouseButtons.Left);
            PaintWithMouse(e);

        }

        private void TileEditPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.DarkSlateBlue);
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
           
          
            for (int y = 0; y < 8; y++) {
                for (int x = 0; x < 8; x++) {
                    var sx = Math.Floor(((double)x / 8.0) * TileEditPictureBox.ClientRectangle.Width);
                    var sy = Math.Floor(((double)y / 8.0) * TileEditPictureBox.ClientRectangle.Height);
                    Brush c = Brushes.Transparent;
                    
                    var colorIndex = _graphics.GetTileData(_selectedTileIndex)[y * 8 + x];
                    if(colorIndex == 1) { c = Brushes.Black; }
                    if(colorIndex == 2) { c = Brushes.Gray; }
                    if(colorIndex == 3) { c = Brushes.White; }
                    e.Graphics.FillRectangle(c, new Rectangle((int)sx, (int)sy, TileEditPictureBox.ClientRectangle.Width / 8, TileEditPictureBox.ClientRectangle.Height / 8));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)sx, (int)sy, TileEditPictureBox.ClientRectangle.Width / 8, TileEditPictureBox.ClientRectangle.Height / 8));
                }
            }

            e.Graphics.DrawRectangle(Pens.DarkRed, e.ClipRectangle);

            var coordinates = TileEditPictureBox.PointToClient(Cursor.Position);


            var lx = (int)Math.Floor(((double) coordinates.X / (double)(this.TileEditPictureBox.ClientRectangle.Width)) * 8.0);
            var ly = (int)Math.Floor(((double)coordinates.Y / (double)(this.TileEditPictureBox.ClientRectangle.Height)) * 8.0);

            e.Graphics.DrawRectangle(Pens.Green, new Rectangle(
                (int)(lx* TileEditPictureBox.ClientRectangle.Width/8),
                (int)(ly * TileEditPictureBox.ClientRectangle.Height / 8),
                (int)(TileEditPictureBox.ClientRectangle.Width / 8),
                (int)(TileEditPictureBox.ClientRectangle.Height / 8)));


        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
