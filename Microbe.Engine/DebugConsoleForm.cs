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
    public partial class DebugConsoleForm : Form
    {
        private Jint.Engine _engine;

        private string _scriptFileName;
        public string ScriptFileName { get { 
            return _scriptFileName;
            } private set {
            _scriptFileName = value;
                this.Text = "Debug Console - " + _scriptFileName;
            } }

        /// <summary>
        /// 
        /// </summary>
        public DebugConsoleForm() : this(null) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="engine"></param>
        public DebugConsoleForm(Jint.Engine engine)
        {

            this.KeyPreview = true;
            _engine = engine;
            ScriptFileName = "";
            InitializeComponent();


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

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                this.Hide();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ConsoleInputText.Text = "";
            this.DebugOutputText.Text = "";
            this.ScriptFileName = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Javascript Files|*.js";
            openFileDialog.Title = "Open a Javascript File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.ScriptFileName = openFileDialog.FileName;
                this.ConsoleInputText.Text = System.IO.File.ReadAllText(this.ScriptFileName);
                this.DebugOutputText.Text = "";

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
          if(this.ScriptFileName == "")
            {
               saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                System.IO.File.WriteAllText(this.ScriptFileName, this.ConsoleInputText.Text);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Javascript Files|*.js";
            saveFileDialog.Title = "Save a Javascript File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.ScriptFileName = saveFileDialog.FileName;
                System.IO.File.WriteAllText(this.ScriptFileName, this.ConsoleInputText.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
