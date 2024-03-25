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
            this.TileEditPictureBox = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.PaletteSelect = new System.Windows.Forms.ComboBox();
            this.Palette1Button = new System.Windows.Forms.Button();
            this.Palette2Button = new System.Windows.Forms.Button();
            this.Palette3Button = new System.Windows.Forms.Button();
            this.ClearColor = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilePickerComponent1 = new Microbe.Engine.Components.TilePickerComponent();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TileEditPictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1480, 921);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 36);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tilePickerComponent1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TileEditPictureBox);
            this.splitContainer1.Size = new System.Drawing.Size(1474, 742);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 0;
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
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.PaletteSelect);
            this.flowLayoutPanel1.Controls.Add(this.Palette1Button);
            this.flowLayoutPanel1.Controls.Add(this.Palette2Button);
            this.flowLayoutPanel1.Controls.Add(this.Palette3Button);
            this.flowLayoutPanel1.Controls.Add(this.ClearColor);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 784);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1474, 134);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // PaletteSelect
            // 
            this.PaletteSelect.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
            this.PaletteSelect.Location = new System.Drawing.Point(3, 53);
            this.PaletteSelect.Name = "PaletteSelect";
            this.PaletteSelect.Size = new System.Drawing.Size(145, 28);
            this.PaletteSelect.TabIndex = 6;
            // 
            // Palette1Button
            // 
            this.Palette1Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Palette1Button.Location = new System.Drawing.Point(154, 3);
            this.Palette1Button.Name = "Palette1Button";
            this.Palette1Button.Size = new System.Drawing.Size(128, 128);
            this.Palette1Button.TabIndex = 5;
            this.Palette1Button.UseVisualStyleBackColor = true;
            this.Palette1Button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorPickerClicked);
            // 
            // Palette2Button
            // 
            this.Palette2Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Palette2Button.Location = new System.Drawing.Point(288, 3);
            this.Palette2Button.Name = "Palette2Button";
            this.Palette2Button.Size = new System.Drawing.Size(128, 128);
            this.Palette2Button.TabIndex = 8;
            this.Palette2Button.UseVisualStyleBackColor = true;
            this.Palette2Button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorPickerClicked);
            // 
            // Palette3Button
            // 
            this.Palette3Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Palette3Button.Location = new System.Drawing.Point(422, 3);
            this.Palette3Button.Name = "Palette3Button";
            this.Palette3Button.Size = new System.Drawing.Size(128, 128);
            this.Palette3Button.TabIndex = 9;
            this.Palette3Button.UseVisualStyleBackColor = true;
            this.Palette3Button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorPickerClicked);
            // 
            // ClearColor
            // 
            this.ClearColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ClearColor.Location = new System.Drawing.Point(556, 3);
            this.ClearColor.Name = "ClearColor";
            this.ClearColor.Size = new System.Drawing.Size(128, 128);
            this.ClearColor.TabIndex = 7;
            this.ClearColor.Text = "Clear";
            this.ClearColor.UseVisualStyleBackColor = true;
            this.ClearColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorPickerClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1480, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTilesetToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newTilesetToolStripMenuItem
            // 
            this.newTilesetToolStripMenuItem.Name = "newTilesetToolStripMenuItem";
            this.newTilesetToolStripMenuItem.Size = new System.Drawing.Size(203, 34);
            this.newTilesetToolStripMenuItem.Text = "&New Tileset";
            this.newTilesetToolStripMenuItem.Click += new System.EventHandler(this.newTilesetToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(203, 34);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(203, 34);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(203, 34);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(203, 34);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tilePickerComponent1
            // 
            this.tilePickerComponent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilePickerComponent1.Graphics = null;
            this.tilePickerComponent1.Location = new System.Drawing.Point(0, 0);
            this.tilePickerComponent1.Name = "tilePickerComponent1";
            this.tilePickerComponent1.Size = new System.Drawing.Size(234, 742);
            this.tilePickerComponent1.TabIndex = 3;
            // 
            // MetaTileEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 921);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MetaTileEditorForm";
            this.ShowIcon = false;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TileEditPictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox TileEditPictureBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox PaletteSelect;
        private System.Windows.Forms.Button Palette3Button;
        private System.Windows.Forms.Button Palette2Button;
        private System.Windows.Forms.Button Palette1Button;
        private System.Windows.Forms.Button ClearColor;
        private Components.TilePickerComponent tilePickerComponent1;
    }
}