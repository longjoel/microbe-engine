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
    public partial class DebugVramForm : Form
    {
        private MicrobeGraphics _graphics;
        Timer _refreshTimer;
        /// <summary>
        /// 
        /// </summary>
        public DebugVramForm() : this(null) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="engine"></param>
        public DebugVramForm( MicrobeGraphics microbeGraphics)
        {

            this.KeyPreview = true;
            _graphics = microbeGraphics;
            _refreshTimer = new Timer();

            _refreshTimer.Interval = 100;
            _refreshTimer.Tick += _refreshTimer_Tick;

            InitializeComponent();

            _refreshTimer.Start();

        }

        private void _refreshTimer_Tick(object sender, EventArgs e)
        {
            this.TilePictureBox.Image = _graphics.DEBUG_GetTileData();
            this.TilePictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            this.VramPictureBox.Image = _graphics.DEBUG_GetVram();
            this.VramPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }


       

        private void DebuggerTools_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = true;
        }

      

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                this.Hide();
            }
        }
    }
}
