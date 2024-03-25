using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microbe.Engine
{
    public partial class MetaTileEditorForm : Form
    {
        private string _tilesetPath;
        public string TilesetPath
        {
            get { return _tilesetPath; }
            set
            {
                _tilesetPath = value;
                this.Text = "MetaTile Editor - " + _tilesetPath;
            }
        }
        MicrobeGraphics _graphics;

        int _selectedTileIndex;
        bool _mouseIsDown;
        Timer _refreshTimer;

        Color[] _palette;
        int _paletteIndex;

        public MetaTileEditorForm(MicrobeGraphics graphics)
        {
            _graphics = graphics != null ? graphics : new MicrobeGraphics();
            _selectedTileIndex = 0;
            _refreshTimer = new Timer();
            _refreshTimer.Interval = 100;
            _refreshTimer.Tick += RefreshTimer_Tick;
            _palette = new Color[4];
            _refreshTimer.Start();
            InitializeComponent();
        }

        private void SetPalette()
        {
            _palette[0] = Color.Transparent;
            _palette[1] = Color.FromArgb(255, _graphics.GetPalette(_graphics.TileToPaletteMap[_selectedTileIndex]).c1.r, _graphics.GetPalette(_graphics.TileToPaletteMap[_selectedTileIndex]).c1.g, _graphics.GetPalette(_graphics.TileToPaletteMap[_selectedTileIndex]).c1.b);
            _palette[2] = Color.FromArgb(255, _graphics.GetPalette(_graphics.TileToPaletteMap[_selectedTileIndex]).c2.r, _graphics.GetPalette(_graphics.TileToPaletteMap[_selectedTileIndex]).c2.g, _graphics.GetPalette(_graphics.TileToPaletteMap[_selectedTileIndex]).c2.b);
            _palette[3] = Color.FromArgb(255, _graphics.GetPalette(_graphics.TileToPaletteMap[_selectedTileIndex]).c3.r, _graphics.GetPalette(_graphics.TileToPaletteMap[_selectedTileIndex]).c3.g, _graphics.GetPalette(_graphics.TileToPaletteMap[_selectedTileIndex]).c3.b);

            Palette1Button.BackColor = _palette[1];
            Palette2Button.BackColor = _palette[2];
            Palette3Button.BackColor = _palette[3];

        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            TileSelectorPictureBox.Invalidate();
            TileEditPictureBox.Invalidate();
        }

        protected override void OnLoad(EventArgs e)
        {
            PaletteSelect.Items.Clear();
            for (int i = 0; i < 256; i++)
            {
                PaletteSelect.Items.Add(i);
            }
            SetPalette();
            this.PaletteSelect.Text = "0";

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

                g.DrawImage(_graphics.TileDataCache[i], new Rectangle(incX * 32, incY * 32, 32, 32), new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);

                if (i == _selectedTileIndex)
                {
                    g.DrawRectangle(Pens.White, new Rectangle((incX * 32) - 1, (incY * 32) - 1, 34, 34));
                }
                else { g.DrawRectangle(Pens.Black, new Rectangle((incX * 32) - 1, (incY * 32) - 1, 34, 34)); }

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
                this.PaletteSelect.Text = _graphics.TileToPaletteMap[_selectedTileIndex].ToString();
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
            oldData[(ly * 8) + lx] = (byte)_paletteIndex;

            _graphics.SetTileData(_selectedTileIndex, oldData);
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


            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    var sx = Math.Floor(((double)x / 8.0) * TileEditPictureBox.ClientRectangle.Width);
                    var sy = Math.Floor(((double)y / 8.0) * TileEditPictureBox.ClientRectangle.Height);
                    Color c = Color.Transparent;

                    var colorIndex = _graphics.GetTileData(_selectedTileIndex)[y * 8 + x];
                    if (colorIndex == 1) { c = Palette1Button.BackColor; }
                    if (colorIndex == 2) { c = Palette2Button.BackColor; }
                    if (colorIndex == 3) { c = Palette3Button.BackColor; }
                    using (var cb = new SolidBrush(c))
                    {
                        e.Graphics.FillRectangle(cb, new Rectangle((int)sx, (int)sy, TileEditPictureBox.ClientRectangle.Width / 8, TileEditPictureBox.ClientRectangle.Height / 8));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)sx, (int)sy, TileEditPictureBox.ClientRectangle.Width / 8, TileEditPictureBox.ClientRectangle.Height / 8));
                    }
                }
            }

            e.Graphics.DrawRectangle(Pens.DarkRed, e.ClipRectangle);

            var coordinates = TileEditPictureBox.PointToClient(Cursor.Position);


            var lx = (int)Math.Floor(((double)coordinates.X / (double)(this.TileEditPictureBox.ClientRectangle.Width)) * 8.0);
            var ly = (int)Math.Floor(((double)coordinates.Y / (double)(this.TileEditPictureBox.ClientRectangle.Height)) * 8.0);

            e.Graphics.DrawRectangle(Pens.Green, new Rectangle(
                (int)(lx * TileEditPictureBox.ClientRectangle.Width / 8),
                (int)(ly * TileEditPictureBox.ClientRectangle.Height / 8),
                (int)(TileEditPictureBox.ClientRectangle.Width / 8),
                (int)(TileEditPictureBox.ClientRectangle.Height / 8)));


        }

     

        private void PaletteSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            _graphics.SetTilePalette(_selectedTileIndex,
                int.Parse(this.PaletteSelect.Text.ToString()));



            var pal = _graphics.GetPalette(_graphics.TileToPaletteMap[_selectedTileIndex]);

            Palette1Button.BackColor = Color.FromArgb(255, pal.c1.r, pal.c1.g, pal.c1.b);
            Palette2Button.BackColor = Color.FromArgb(255, pal.c2.r, pal.c2.g, pal.c2.b);
            Palette3Button.BackColor = Color.FromArgb(255, pal.c3.r, pal.c3.g, pal.c3.b);

        }

        public void ColorPickerClicked(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (((Button)sender).Name == nameof(Palette1Button))
                {
                    _paletteIndex = 1;

                }
                else
                if (((Button)sender).Name == nameof(Palette2Button))
                {
                    _paletteIndex = 2;

                }
                else
                if (((Button)sender).Name == nameof(Palette3Button))
                {
                    _paletteIndex = 3;

                }
                else { _paletteIndex = 0; }
            }
            else if (e.Button == MouseButtons.Right)
            {
                var cd = new ColorDialog();
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    var clr = cd.Color;

                    var pal = _graphics.GetPalette(_graphics.TileToPaletteMap[_selectedTileIndex]);
                    var newPal = new TilePalette()
                    {
                        c1 = pal.c1,
                        c2 = pal.c2,
                        c3 = pal.c3
                    };
                    if (((Button)sender).Name == nameof(Palette1Button))
                    {
                        newPal.c1 = new RGB() { r = clr.R, g = clr.G, b = clr.B };
                        Palette1Button.BackColor = clr;


                    }
                    if (((Button)sender).Name == nameof(Palette2Button))
                    {
                        newPal.c2 = new RGB() { r = clr.R, g = clr.G, b = clr.B };
                        Palette2Button.BackColor = clr;


                    }
                    if (((Button)sender).Name == nameof(Palette3Button))
                    {
                        newPal.c3 = new RGB() { r = clr.R, g = clr.G, b = clr.B };
                        Palette3Button.BackColor = clr;


                    }
                    _graphics.SetPalette(_graphics.TileToPaletteMap[_selectedTileIndex], newPal);

                }
            }
        }



        private void newTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newGraphics = new MicrobeGraphics();
            _graphics.Deserialize(newGraphics.Serialize());
            TilesetPath = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Microbe Graphics Format (*.micgfx)|*.micgfx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _graphics.Deserialize(File.ReadAllText(ofd.FileName));
                _selectedTileIndex = 0;
                this.PaletteSelect.Text = _graphics.TileToPaletteMap[_selectedTileIndex].ToString();
                SetPalette();
                TilesetPath = ofd.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TilesetPath))
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                File.WriteAllText(TilesetPath, _graphics.Serialize());
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Microbe Graphics Format (*.micgfx)|*.micgfx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                File.WriteAllText(sfd.FileName, _graphics.Serialize());
                TilesetPath = sfd.FileName;

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
