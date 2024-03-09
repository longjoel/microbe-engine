namespace Microbe.Engine
{
    partial class SampleEditorForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PickSampleListBox = new System.Windows.Forms.ListBox();
            this.SamplesDataGrid = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SegmentLengthTextBox = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PlayButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.SineNote = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SineVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TriangleNote = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TriangleVol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SquareNote = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SquareVol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiseVol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SamplesDataGrid)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentLengthTextBox)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 223F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.PickSampleListBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SamplesDataGrid, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1520, 852);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // PickSampleListBox
            // 
            this.PickSampleListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PickSampleListBox.FormattingEnabled = true;
            this.PickSampleListBox.ItemHeight = 20;
            this.PickSampleListBox.Location = new System.Drawing.Point(3, 51);
            this.PickSampleListBox.Name = "PickSampleListBox";
            this.PickSampleListBox.Size = new System.Drawing.Size(217, 734);
            this.PickSampleListBox.TabIndex = 0;
            // 
            // SamplesDataGrid
            // 
            this.SamplesDataGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SamplesDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.SamplesDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SamplesDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.SamplesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SamplesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SineNote,
            this.SineVolume,
            this.TriangleNote,
            this.TriangleVol,
            this.SquareNote,
            this.SquareVol,
            this.NoiseVol});
            this.SamplesDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SamplesDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.SamplesDataGrid.Location = new System.Drawing.Point(226, 51);
            this.SamplesDataGrid.Name = "SamplesDataGrid";
            this.SamplesDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.SamplesDataGrid.RowHeadersWidth = 62;
            this.SamplesDataGrid.RowTemplate.Height = 28;
            this.SamplesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.SamplesDataGrid.Size = new System.Drawing.Size(1291, 734);
            this.SamplesDataGrid.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.SegmentLengthTextBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(226, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1291, 42);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Segment Length (ms):";
            // 
            // SegmentLengthTextBox
            // 
            this.SegmentLengthTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SegmentLengthTextBox.Location = new System.Drawing.Point(176, 3);
            this.SegmentLengthTextBox.Name = "SegmentLengthTextBox";
            this.SegmentLengthTextBox.Size = new System.Drawing.Size(120, 26);
            this.SegmentLengthTextBox.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel2.Controls.Add(this.PlayButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.StopButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ExportButton, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.ImportButton, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(226, 791);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1291, 58);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // PlayButton
            // 
            this.PlayButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayButton.Location = new System.Drawing.Point(3, 3);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(122, 52);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            // 
            // StopButton
            // 
            this.StopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopButton.Location = new System.Drawing.Point(131, 3);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(122, 52);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // ExportButton
            // 
            this.ExportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExportButton.Location = new System.Drawing.Point(1038, 3);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(122, 52);
            this.ExportButton.TabIndex = 2;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            // 
            // ImportButton
            // 
            this.ImportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImportButton.Location = new System.Drawing.Point(1166, 3);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(122, 52);
            this.ImportButton.TabIndex = 3;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            // 
            // SineNote
            // 
            this.SineNote.HeaderText = "Sine Note";
            this.SineNote.MinimumWidth = 8;
            this.SineNote.Name = "SineNote";
            this.SineNote.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SineNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SineVolume
            // 
            this.SineVolume.HeaderText = "Sine Volume";
            this.SineVolume.MinimumWidth = 8;
            this.SineVolume.Name = "SineVolume";
            // 
            // TriangleNote
            // 
            this.TriangleNote.HeaderText = "Triangle Note";
            this.TriangleNote.MinimumWidth = 8;
            this.TriangleNote.Name = "TriangleNote";
            this.TriangleNote.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TriangleNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TriangleVol
            // 
            this.TriangleVol.HeaderText = "Triangle Volume";
            this.TriangleVol.MinimumWidth = 8;
            this.TriangleVol.Name = "TriangleVol";
            // 
            // SquareNote
            // 
            this.SquareNote.HeaderText = "Square Note";
            this.SquareNote.MinimumWidth = 8;
            this.SquareNote.Name = "SquareNote";
            this.SquareNote.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SquareNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SquareVol
            // 
            this.SquareVol.HeaderText = "Square Volume";
            this.SquareVol.MinimumWidth = 8;
            this.SquareVol.Name = "SquareVol";
            // 
            // NoiseVol
            // 
            this.NoiseVol.HeaderText = "Noise Volume";
            this.NoiseVol.MinimumWidth = 8;
            this.NoiseVol.Name = "NoiseVol";
            // 
            // SampleEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 852);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SampleEditorForm";
            this.Text = "SampleEditorForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SamplesDataGrid)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentLengthTextBox)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox PickSampleListBox;
        private System.Windows.Forms.DataGridView SamplesDataGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown SegmentLengthTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.DataGridViewComboBoxColumn SineNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn SineVolume;
        private System.Windows.Forms.DataGridViewComboBoxColumn TriangleNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn TriangleVol;
        private System.Windows.Forms.DataGridViewComboBoxColumn SquareNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn SquareVol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiseVol;
    }
}