﻿using System;
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

                for (int i = 0; i < 256; i++) {
                    this.PickSampleListBox.Items.Add(i.ToString());
                }
            }


            base.OnLoad(e);
        }
    }
}
