using Jint;
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
    public partial class DebuggerTools : Form
    {
        private Jint.Engine _engine;
        private MicrobeGraphics _graphics;
        Timer _refreshTimer;
        /// <summary>
        /// 
        /// </summary>
        public DebuggerTools() : this(null, null) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="engine"></param>
        public DebuggerTools(Jint.Engine engine, MicrobeGraphics microbeGraphics)
        {

            this.KeyPreview = true;
            _engine = engine;
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

        public void Log(string s)
        {
            DebugOutputText.AppendText(Environment.NewLine + s);
        }

        private void SubmitInputButton_Click(object sender, EventArgs e)
        {
            try
            {
                var output = _engine.Evaluate(this.ConsoleInputText.Text);
                DebugOutputText.AppendText(Environment.NewLine + output);

            }
            catch (Exception ex)
            {
                var output = ex.Message;
                DebugOutputText.AppendText(Environment.NewLine + output);

            }
        }

        private void DebuggerTools_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = true;
        }

        private void RefreshVramButton_Click(object sender, EventArgs e)
        {

        }


        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                this.Hide();
            }
        }
       
    }
}
