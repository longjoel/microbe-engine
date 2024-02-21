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

        /// <summary>
        /// 
        /// </summary>
        public DebuggerTools() : this(null) { }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="engine"></param>
        public DebuggerTools(Jint.Engine engine)
        {
            _engine = engine;
            InitializeComponent();
        }

        private void SubmitCodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                var output = _engine.Evaluate(this.ConsoleInputText.Text);
                this.ConsoleOutputText.Text += Environment.NewLine + output.ToString();

            }
            catch (Exception ex) {
                this.ConsoleOutputText.Text += Environment.NewLine + ex.Message.ToString();

            }

            this.ConsoleOutputText.ScrollToCaret();
            //this.ConsoleInputText.Clear();
        }
    }
}
