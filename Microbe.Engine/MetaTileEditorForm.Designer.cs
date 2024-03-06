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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Palette3Button = new System.Windows.Forms.Button();
            this.Palette2Button = new System.Windows.Forms.Button();
            this.Palette1Button = new System.Windows.Forms.Button();
            this.PaletteSelect = new System.Windows.Forms.ComboBox();
            this.ClearColor = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TileSelectorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TileEditPictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.716536F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.1516F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.8484F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1268, 788);
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
            this.splitContainer1.Size = new System.Drawing.Size(1262, 696);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // TileSelectorPictureBox
            // 
            this.TileSelectorPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TileSelectorPictureBox.Location = new System.Drawing.Point(0, 0);
            this.TileSelectorPictureBox.Name = "TileSelectorPictureBox";
            this.TileSelectorPictureBox.Size = new System.Drawing.Size(234, 696);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 705);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1262, 80);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.Palette3Button, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.Palette2Button, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.Palette1Button, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.PaletteSelect, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ClearColor, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(759, 68);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // Palette3Button
            // 
            this.Palette3Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Palette3Button.Location = new System.Drawing.Point(607, 3);
            this.Palette3Button.Name = "Palette3Button";
            this.Palette3Button.Size = new System.Drawing.Size(149, 62);
            this.Palette3Button.TabIndex = 4;
            this.Palette3Button.UseVisualStyleBackColor = true;
            this.Palette3Button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorPickerClicked);
            // 
            // Palette2Button
            // 
            this.Palette2Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Palette2Button.Location = new System.Drawing.Point(456, 3);
            this.Palette2Button.Name = "Palette2Button";
            this.Palette2Button.Size = new System.Drawing.Size(145, 62);
            this.Palette2Button.TabIndex = 3;
            this.Palette2Button.UseVisualStyleBackColor = true;
            this.Palette2Button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorPickerClicked);
            // 
            // Palette1Button
            // 
            this.Palette1Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Palette1Button.Location = new System.Drawing.Point(305, 3);
            this.Palette1Button.Name = "Palette1Button";
            this.Palette1Button.Size = new System.Drawing.Size(145, 62);
            this.Palette1Button.TabIndex = 0;
            this.Palette1Button.UseVisualStyleBackColor = true;
            this.Palette1Button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorPickerClicked);
            // 
            // PaletteSelect
            // 
            this.PaletteSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PaletteSelect.FormattingEnabled = true;
            this.PaletteSelect.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14"});
            this.PaletteSelect.Location = new System.Drawing.Point(3, 20);
            this.PaletteSelect.Name = "PaletteSelect";
            this.PaletteSelect.Size = new System.Drawing.Size(145, 28);
            this.PaletteSelect.TabIndex = 1;
            this.PaletteSelect.SelectedIndexChanged += new System.EventHandler(this.PaletteSelect_SelectedIndexChanged);
            // 
            // ClearColor
            // 
            this.ClearColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearColor.Location = new System.Drawing.Point(154, 3);
            this.ClearColor.Name = "ClearColor";
            this.ClearColor.Size = new System.Drawing.Size(145, 62);
            this.ClearColor.TabIndex = 2;
            this.ClearColor.Text = "Clear";
            this.ClearColor.UseVisualStyleBackColor = true;
            this.ClearColor .MouseClick += new System.Windows.Forms.MouseEventHandler(this.ColorPickerClicked);
           
            // 
            // MetaTileEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 788);
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
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox TileSelectorPictureBox;
        private System.Windows.Forms.PictureBox TileEditPictureBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Palette1Button;
        private System.Windows.Forms.ComboBox PaletteSelect;
        private System.Windows.Forms.Button Palette3Button;
        private System.Windows.Forms.Button Palette2Button;
        private System.Windows.Forms.Button ClearColor;
    }
}