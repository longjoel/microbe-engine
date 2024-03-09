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
        public SampleEditorForm()
        {
            InitializeComponent();
        }
    }
}
