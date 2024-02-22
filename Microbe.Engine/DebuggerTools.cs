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

        public void Log(string s) {
            DebugOutputText.AppendText(Environment.NewLine + s);
        }

        private void SubmitInputButton_Click(object sender, EventArgs e)
        {
            try {
                var output = _engine.Evaluate(this.ConsoleInputText.Text);
                DebugOutputText.AppendText(Environment.NewLine + output);
            
            } catch (Exception ex) {
                var output = ex.Message;
                DebugOutputText.AppendText(Environment.NewLine + output);

            }
        }
    }
}
