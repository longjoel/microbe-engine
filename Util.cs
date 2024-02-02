using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microbe_engine
{
    internal class Util
    {
        public static Rectangle ScaleRectangle(Rectangle source, Rectangle target)
        {
            double sourceAspectRatio = (double)source.Width / source.Height;
            double targetAspectRatio = (double)target.Width / target.Height;

            double scale = Math.Min(target.Width / (double)source.Width, target.Height / (double)source.Height);

            int adjustedWidth = (int)(source.Width * scale);
            int adjustedHeight = (int)(source.Height * scale);

            int x = target.X + (target.Width - adjustedWidth) / 2;
            int y = target.Y + (target.Height - adjustedHeight) / 2;

            return new Rectangle(x, y, adjustedWidth, adjustedHeight);
        }
    }
}
