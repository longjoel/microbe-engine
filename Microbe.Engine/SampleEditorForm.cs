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
    public partial class SampleEditorForm : Form
    {
        public MicrobeAudio Audio { get; set; }

        public SampleEditorForm() : this(null) { }

        private int _lastIndex = 0;

        public SampleEditorForm(MicrobeAudio audio)
        {
            Audio = audio;
            InitializeComponent();

        }

        protected override void OnLoad(EventArgs e)
        {
            if (Audio != null)
            {

                // populate the note options
                foreach (var n in Audio.Notes)
                {
                    SineNote.Items.Add(n);
                    TriangleNote.Items.Add(n);
                    SquareNote.Items.Add(n);
                }

                for (int i = 0; i < 256; i++)
                {
                    this.PickSampleListBox.Items.Add(i.ToString());
                }

                LoadSample(0);

            }



            base.OnLoad(e);
        }

        private void PickSampleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            var samples = BuildSamplesFromGrid();
            Audio.SetSample( this._lastIndex,int.Parse(SegmentLengthTextBox.Value.ToString()), samples.ToArray());
            this._lastIndex = int.Parse(this.PickSampleListBox.Text);
            LoadSample(int.Parse((this.PickSampleListBox.Text)));

        }


        void LoadSample(int index)
        {
            var sample = Audio.Samples[index];
            this.SegmentLengthTextBox.Value = sample.IntervalMS;
            this.SamplesDataGrid.Rows.Clear();

            foreach (var s in sample.SampleSegments)
            {
                var r = new DataGridViewRow();
                r.CreateCells(SamplesDataGrid);

                r.Cells[0].Value = s.sn;
                r.Cells[1].Value = s.sv * 100.0;
                r.Cells[2].Value = s.sqn;
                    
                r.Cells[3].Value = s.sqv * 100.0;
                r.Cells[4].Value = s.tn;
                r.Cells[5].Value = s.tv * 100.0;
                r.Cells[6].Value = s.nv * 100.0;
                SamplesDataGrid.Rows.Add(r);
                
            }

        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            List<SampleSegment> samples = BuildSamplesFromGrid();

            Audio.SetSample(int.Parse((this.PickSampleListBox.SelectedValue ?? "0").ToString()), (int)this.SegmentLengthTextBox.Value, samples.ToArray());
            Audio.PlayEffect(int.Parse((this.PickSampleListBox.SelectedValue ?? "0").ToString()));
        }

        private List<SampleSegment> BuildSamplesFromGrid()
        {
            var samples = new List<SampleSegment>();

            var getVal = new Func<DataGridViewRow, string, string, string>((row, name, defaultVal) =>
            {

                var cell = row.Cells[name];
                if (cell != null)
                {
                    if (cell.Value != null)
                    {

                        return cell.Value.ToString();
                    }
                }


                return defaultVal;
            });

            foreach (DataGridViewRow row in SamplesDataGrid.Rows)
            {
                if (row != null && !row.IsNewRow)
                {
                    samples.Add(new SampleSegment
                    {
                        nv = double.Parse(getVal(row, nameof(NoiseVol), "0")) / 100.0,
                        sn = getVal(row, nameof(SineNote), "C1"),

                        sv = double.Parse(getVal(row, nameof(SineVolume), "0")) / 100.0,

                        sqn = getVal(row, nameof(SquareNote), "C1"),

                        sqv = double.Parse(getVal(row, nameof(SquareVol), "0")) / 100.0,

                        tn = getVal(row, nameof(TriangleNote), "C1"),

                        tv = double.Parse(getVal(row, nameof(TriangleVol), "0")) / 100.0,
                    });
                }
            }

            return samples;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {

        }

        private void ExportButton_Click(object sender, EventArgs e)
        {

        }

        private void ImportButton_Click(object sender, EventArgs e)
        {

        }
    }
}
