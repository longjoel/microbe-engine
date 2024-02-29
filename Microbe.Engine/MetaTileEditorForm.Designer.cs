namespace Microbe.Engine
{
    partial class MetaTileEditorForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TileSelectorPictureBox = new System.Windows.Forms.PictureBox();
            this.TileEditPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TileSelectorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileEditPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.716536F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.1516F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.8484F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1270, 735);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TileSelectorPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TileEditPictureBox);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 649);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // TileSelectorPictureBox
            // 
            this.TileSelectorPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TileSelectorPictureBox.Location = new System.Drawing.Point(0, 0);
            this.TileSelectorPictureBox.Name = "TileSelectorPictureBox";
            this.TileSelectorPictureBox.Size = new System.Drawing.Size(234, 649);
            this.TileSelectorPictureBox.TabIndex = 0;
            this.TileSelectorPictureBox.TabStop = false;
            this.TileSelectorPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.TileSelectorPictureBox_Paint);
            this.TileSelectorPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TileSelectorPictureBox_MouseClick);
            // 
            // TileEditPictureBox
            // 
            this.TileEditPictureBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TileEditPictureBox.Location = new System.Drawing.Point(0, 0);
            this.TileEditPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.TileEditPictureBox.Name = "TileEditPictureBox";
            this.TileEditPictureBox.Size = new System.Drawing.Size(800, 800);
            this.TileEditPictureBox.TabIndex = 0;
            this.TileEditPictureBox.TabStop = false;
            this.TileEditPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.TileEditPictureBox_Paint);
            this.TileEditPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TileEditPictureBox_MouseDown);
            this.TileEditPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TileEditPictureBox_MouseMove);
            this.TileEditPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TileEditPictureBox_MouseUp);
            // 
            // MetaTileEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 735);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "MetaTileEditorForm";
            this.Text = "MetaTileEditorForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TileSelectorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileEditPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox TileSelectorPictureBox;
        private System.Windows.Forms.PictureBox TileEditPictureBox;
    }
}