using System;
using System.Drawing;

namespace TIE
{
    internal class PlateletPrinter
    {
        private readonly Point _location;
        private readonly Size _size;

        internal PlateletPrinter(Point location, Size size)
        {
            _location = location;
            _size = size;
        }

        internal void DrawImage(Graphics g, Bitmap display)
        {
            g.DrawImage(display, _location.X, _location.Y, _size.Width, _size.Height);
        }
    }
}
