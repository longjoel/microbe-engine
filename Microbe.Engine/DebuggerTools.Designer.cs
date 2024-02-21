namespace Microbe.Engine
{
    partial class DebuggerTools
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ConsoleOutputText = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ConsoleInputText = new System.Windows.Forms.TextBox();
            this.SubmitCodeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(533, 403);
            this.splitContainer1.SplitterDistance = 259;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ConsoleOutputText);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(259, 403);
            this.splitContainer2.SplitterDistance = 269;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // ConsoleOutputText
            // 
            this.ConsoleOutputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleOutputText.Location = new System.Drawing.Point(0, 0);
            this.ConsoleOutputText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ConsoleOutputText.MaximumSize = new System.Drawing.Size(4, 261);
            this.ConsoleOutputText.Multiline = true;
            this.ConsoleOutputText.Name = "ConsoleOutputText";
            this.ConsoleOutputText.ReadOnly = true;
            this.ConsoleOutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConsoleOutputText.Size = new System.Drawing.Size(4, 261);
            this.ConsoleOutputText.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ConsoleInputText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SubmitCodeButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 131);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ConsoleInputText
            // 
            this.ConsoleInputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleInputText.Location = new System.Drawing.Point(2, 2);
            this.ConsoleInputText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ConsoleInputText.Multiline = true;
            this.ConsoleInputText.Name = "ConsoleInputText";
            this.ConsoleInputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConsoleInputText.Size = new System.Drawing.Size(255, 85);
            this.ConsoleInputText.TabIndex = 0;
            // 
            // SubmitCodeButton
            // 
            this.SubmitCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitCodeButton.Location = new System.Drawing.Point(207, 91);
            this.SubmitCodeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SubmitCodeButton.Name = "SubmitCodeButton";
            this.SubmitCodeButton.Size = new System.Drawing.Size(50, 38);
            this.SubmitCodeButton.TabIndex = 1;
            this.SubmitCodeButton.Text = ">>";
            this.SubmitCodeButton.UseVisualStyleBackColor = true;
            this.SubmitCodeButton.Click += new System.EventHandler(this.SubmitCodeButton_Click);
            // 
            // DebuggerTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 403);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DebuggerTools";
            this.Text = "DebuggerTools";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox ConsoleOutputText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox ConsoleInputText;
        private System.Windows.Forms.Button SubmitCodeButton;
    }
}