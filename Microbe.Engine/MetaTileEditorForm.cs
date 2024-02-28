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

        public MetaTileEditorForm()
        {
            _graphics = new MicrobeGraphics();
            _selectedTileIndex = 0;
         
            InitializeComponent();
        }

        private int GetCols()
        {
            return (int)Math.Floor((double)TileSelectorPictureBox.ClientRectangle.Width / 32.0);
        }

        private void TileSelectorPictureBox_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.LightBlue);
            var cols = GetCols();
            
            int incX =0;
            int incY = 0;
            
            for (int i = 0; i < 256; i++) {

                g.DrawImage(_graphics.TileDataCache[i], new Rectangle(incX * 32, incY * 32, 32, 32));

                if (i == _selectedTileIndex) {
                    g.DrawRectangle(Pens.Red, new Rectangle((incX * 32) - 1, (incY * 32) - 1, 34, 34));
                }

                incX = incX + 1;
                if (incX >= GetCols()) {
                    incX = 0;
                    incY++;
                }
                
            
            }

            TileSelectorPictureBox.Invalidate();


        }

      
        private void TileSelectorPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (int)Math.Floor((double)e.X / 32.0);
            int y = (int)Math.Floor((double)e.Y / 32.0);

            var index = (y * GetCols()) + x;
            if (index < 256)
            {
                _selectedTileIndex = index;
            }
        }
    }
}
