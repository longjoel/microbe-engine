﻿namespace Microbe.Engine
{
    partial class DebugVramForm
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TilePictureBox = new System.Windows.Forms.PictureBox();
            this.VramPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TilePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VramPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.TilePictureBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.VramPictureBox, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1193, 690);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // TilePictureBox
            // 
            this.TilePictureBox.BackColor = System.Drawing.Color.DimGray;
            this.TilePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TilePictureBox.Location = new System.Drawing.Point(3, 3);
            this.TilePictureBox.Name = "TilePictureBox";
            this.TilePictureBox.Size = new System.Drawing.Size(344, 684);
            this.TilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.TilePictureBox.TabIndex = 3;
            this.TilePictureBox.TabStop = false;
            // 
            // VramPictureBox
            // 
            this.VramPictureBox.BackColor = System.Drawing.Color.DimGray;
            this.VramPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VramPictureBox.Location = new System.Drawing.Point(353, 3);
            this.VramPictureBox.Name = "VramPictureBox";
            this.VramPictureBox.Size = new System.Drawing.Size(837, 684);
            this.VramPictureBox.TabIndex = 4;
            this.VramPictureBox.TabStop = false;
            // 
            // DebugVramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 690);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "DebugVramForm";
            this.ShowInTaskbar = false;
            this.Text = "Vram Viewer";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TilePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VramPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox TilePictureBox;
        private System.Windows.Forms.PictureBox VramPictureBox;
    }
}