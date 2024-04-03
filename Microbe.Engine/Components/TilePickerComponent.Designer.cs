namespace Microbe.Engine.Components
{
    partial class TilePickerComponent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tileScroll = new System.Windows.Forms.VScrollBar();
            this.TileRenderContainer = new System.Windows.Forms.PictureBox();
            this.SelectedRangeLabel = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TileRenderContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tileScroll, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TileRenderContainer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SelectedRangeLabel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(329, 764);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tileScroll
            // 
            this.tileScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.tileScroll.Location = new System.Drawing.Point(303, 0);
            this.tileScroll.Maximum = 64;
            this.tileScroll.Name = "tileScroll";
            this.tileScroll.Size = new System.Drawing.Size(26, 458);
            this.tileScroll.TabIndex = 0;
            this.tileScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tileScroll_Scroll);
            // 
            // TileRenderContainer
            // 
            this.TileRenderContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TileRenderContainer.Location = new System.Drawing.Point(8, 8);
            this.TileRenderContainer.Margin = new System.Windows.Forms.Padding(8);
            this.TileRenderContainer.Name = "TileRenderContainer";
            this.TileRenderContainer.Size = new System.Drawing.Size(287, 442);
            this.TileRenderContainer.TabIndex = 1;
            this.TileRenderContainer.TabStop = false;
            this.TileRenderContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.TileRenderContainer_Paint);
            this.TileRenderContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TileRenderContainer_MouseDown);
            this.TileRenderContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TileRenderContainer_MouseMove);
            this.TileRenderContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TileRenderContainer_MouseUp);
            // 
            // SelectedRangeLabel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.SelectedRangeLabel, 2);
            this.SelectedRangeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectedRangeLabel.Location = new System.Drawing.Point(3, 461);
            this.SelectedRangeLabel.Multiline = true;
            this.SelectedRangeLabel.Name = "SelectedRangeLabel";
            this.SelectedRangeLabel.ReadOnly = true;
            this.SelectedRangeLabel.Size = new System.Drawing.Size(323, 300);
            this.SelectedRangeLabel.TabIndex = 2;
            // 
            // TilePickerComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TilePickerComponent";
            this.Size = new System.Drawing.Size(329, 764);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TileRenderContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.VScrollBar tileScroll;
        private System.Windows.Forms.PictureBox TileRenderContainer;
        private System.Windows.Forms.TextBox SelectedRangeLabel;
    }
}
