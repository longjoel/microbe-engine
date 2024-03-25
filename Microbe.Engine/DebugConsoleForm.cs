using ICSharpCode.TextEditor.Document;
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

        public string ConsoleInputText { get { 
            return this.textEditorControl1.Text;
            } set { 
            var txt = value;
               this.textEditorControl1.Text = txt;
            } 
             }

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

        protected override void OnLoad(EventArgs e)
        {
            Invalidate();
            this.Width = this.Width + 1;
            
            textEditorControl1.Document.HighlightingStrategy = ICSharpCode.TextEditor.Document.HighlightingStrategyFactory.CreateHighlightingStrategy("JavaScript");
            textEditorControl1.Document.FoldingManager.FoldingStrategy = new IndentFoldingStrategy();
            textEditorControl1.Document.FoldingManager.UpdateFoldings(null, null);


            base.OnLoad(e);
        }



        public void Log(string s)
        {
            DebugOutputText.AppendText(Environment.NewLine + s);
        }

        private void SubmitInputButton_Click(object sender, EventArgs e)
        {
            try
            {
                var output = _engine.Evaluate(this.ConsoleInputText);
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
            this.ConsoleInputText = "";
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
                this.ConsoleInputText = System.IO.File.ReadAllText(this.ScriptFileName);
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
                System.IO.File.WriteAllText(this.ScriptFileName, this.ConsoleInputText);
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
                System.IO.File.WriteAllText(this.ScriptFileName, this.ConsoleInputText);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aPIDocsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
