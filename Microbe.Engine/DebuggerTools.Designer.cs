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
            this.VramViewer = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SubmitInputButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DebugOutputText = new System.Windows.Forms.TextBox();
            this.ConsoleInputText = new ICSharpCode.TextEditor.TextEditorControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RefreshVramButton = new System.Windows.Forms.Button();
            this.TilePictureBox = new System.Windows.Forms.PictureBox();
            this.VramPictureBox = new System.Windows.Forms.PictureBox();
            this.VramViewer.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TilePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VramPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // VramViewer
            // 
            this.VramViewer.Controls.Add(this.tabPage1);
            this.VramViewer.Controls.Add(this.tabPage2);
            this.VramViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VramViewer.Location = new System.Drawing.Point(0, 0);
            this.VramViewer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.VramViewer.Name = "VramViewer";
            this.VramViewer.SelectedIndex = 0;
            this.VramViewer.Size = new System.Drawing.Size(1522, 865);
            this.VramViewer.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1514, 832);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Console";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.SubmitInputButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 5);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1506, 822);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // SubmitInputButton
            // 
            this.SubmitInputButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitInputButton.Location = new System.Drawing.Point(1390, 729);
            this.SubmitInputButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SubmitInputButton.Name = "SubmitInputButton";
            this.SubmitInputButton.Size = new System.Drawing.Size(112, 88);
            this.SubmitInputButton.TabIndex = 0;
            this.SubmitInputButton.Text = ">>";
            this.SubmitInputButton.UseVisualStyleBackColor = true;
            this.SubmitInputButton.Click += new System.EventHandler(this.SubmitInputButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 5);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DebugOutputText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ConsoleInputText);
            this.splitContainer1.Size = new System.Drawing.Size(1498, 714);
            this.splitContainer1.SplitterDistance = 356;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // DebugOutputText
            // 
            this.DebugOutputText.BackColor = System.Drawing.SystemColors.ControlDark;
            this.DebugOutputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DebugOutputText.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebugOutputText.Location = new System.Drawing.Point(0, 0);
            this.DebugOutputText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DebugOutputText.Multiline = true;
            this.DebugOutputText.Name = "DebugOutputText";
            this.DebugOutputText.ReadOnly = true;
            this.DebugOutputText.Size = new System.Drawing.Size(1498, 356);
            this.DebugOutputText.TabIndex = 0;
            // 
            // ConsoleInputText
            // 
            this.ConsoleInputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleInputText.IsReadOnly = false;
            this.ConsoleInputText.Location = new System.Drawing.Point(0, 0);
            this.ConsoleInputText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConsoleInputText.Name = "ConsoleInputText";
            this.ConsoleInputText.Size = new System.Drawing.Size(1498, 352);
            this.ConsoleInputText.TabIndex = 0;
            this.ConsoleInputText.Text = "setString(0,0,\"Hello World\");";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1514, 832);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tile and Vram Viewer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.RefreshVramButton, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.TilePictureBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.VramPictureBox, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1508, 826);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tile Memory";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(874, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Video Memory";
            // 
            // RefreshVramButton
            // 
            this.RefreshVramButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshVramButton.Location = new System.Drawing.Point(1339, 765);
            this.RefreshVramButton.Name = "RefreshVramButton";
            this.RefreshVramButton.Size = new System.Drawing.Size(166, 58);
            this.RefreshVramButton.TabIndex = 2;
            this.RefreshVramButton.Text = "Refresh";
            this.RefreshVramButton.UseVisualStyleBackColor = true;
            this.RefreshVramButton.Click += new System.EventHandler(this.RefreshVramButton_Click);
            // 
            // TilePictureBox
            // 
            this.TilePictureBox.BackColor = System.Drawing.Color.DimGray;
            this.TilePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TilePictureBox.Location = new System.Drawing.Point(3, 67);
            this.TilePictureBox.Name = "TilePictureBox";
            this.TilePictureBox.Size = new System.Drawing.Size(344, 692);
            this.TilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.TilePictureBox.TabIndex = 3;
            this.TilePictureBox.TabStop = false;
            // 
            // VramPictureBox
            // 
            this.VramPictureBox.BackColor = System.Drawing.Color.DimGray;
            this.VramPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VramPictureBox.Location = new System.Drawing.Point(353, 67);
            this.VramPictureBox.Name = "VramPictureBox";
            this.VramPictureBox.Size = new System.Drawing.Size(1152, 692);
            this.VramPictureBox.TabIndex = 4;
            this.VramPictureBox.TabStop = false;
            // 
            // DebuggerTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1522, 865);
            this.ControlBox = false;
            this.Controls.Add(this.VramViewer);
            this.Name = "DebuggerTools";
            this.Text = "DebuggerTools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebuggerTools_FormClosing);
            this.VramViewer.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TilePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VramPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl VramViewer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button SubmitInputButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ICSharpCode.TextEditor.TextEditorControl ConsoleInputText;
        private System.Windows.Forms.TextBox DebugOutputText;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RefreshVramButton;
        private System.Windows.Forms.PictureBox TilePictureBox;
        private System.Windows.Forms.PictureBox VramPictureBox;
    }
}