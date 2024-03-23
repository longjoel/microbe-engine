using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microbe.Engine.Components
{
    public partial class MEButton : UserControl
    {
        public MEButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Transparent);
            if (DesignMode)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Red), 0, 0, Width - 1, Height - 1);
            }
            else
            {
                e.Graphics.DrawEllipse(new Pen(Color.Black), 0, 0, Width - 1, Height - 1);

            }
            base.OnPaint(e);
        }
    }
}
