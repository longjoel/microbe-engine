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
        public MetaTileEditorForm()
        {
            InitializeComponent();
            TileSelectorPictureBox.Invalidate();
        }

        private void TileSelectorPictureBox_Paint(object sender, PaintEventArgs e)
        {
            using (var g = e.Graphics) {

                g.Clear(Color.LightBlue);
            
            }
        }
    }
}
