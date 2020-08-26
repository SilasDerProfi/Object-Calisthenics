using System.Drawing;
using System.Linq;
using TIE.Extensions;

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

        internal PlateletPrinter(int x, int y, int width, int height)
        {
            _location = new Point(x,y);
            _size = new Size(width, height);
        }

        internal void DrawImage(Graphics g, Bitmap display)
        {
            g.DrawImage(display, _location.X, _location.Y, _size.Width, _size.Height);
        }

        internal decimal CalculateMinimumInnerCornerDistance(Point position)
        {
            var topLeft = _location;
            var topRight = new Point(_location.Y, _location.X + _size.Width);
            var bottomLeft = new Point(_location.Y + _size.Height, _location.X);
            var bottomRight = new Point(_location.Y + _size.Height, _location.X + _size.Width);

            if (topLeft.Y > position.Y || topLeft.X > position.X || bottomRight.X > position.X || bottomRight.Y > position.Y)
                return decimal.MaxValue;

            var distances = new decimal[4];
            distances[0] = position.CalculateDistance(topLeft);
            distances[1] = position.CalculateDistance(topRight);
            distances[2] = position.CalculateDistance(bottomLeft);
            distances[3] = position.CalculateDistance(bottomRight);

            return distances.Min();
        }
    }
}