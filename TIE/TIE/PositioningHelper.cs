using System;
using System.Drawing;
using System.Linq;

namespace TIE
{
    class PositioningHelper
    {
        private readonly PlateletPrinter[] _positions;

        public PositioningHelper(Size size)
        {
            _positions = new PlateletPrinter[19];

            // width/height ratio
            // breite muss geringer sein...
            var ratio = 152 / 165d; 
            var startPosition = new Point(0,0);

            var expectedWidth = (int)(size.Height * ratio);
            var expectedHeight = (int)(size.Width / ratio);

            if(size.Height > expectedHeight)
            {
                startPosition.Y = size.Height - expectedHeight;
                size.Height = expectedHeight;
            }

            if(size.Width > expectedWidth)
            {
                startPosition.X = size.Width - expectedWidth;
                size.Width = expectedWidth;
            }

            int plateletWidth = size.Width / 4;
            int plateletHeight = size.Height / 5;

            var yPosition = new int[] { 0 + startPosition.Y, plateletHeight * 1 + startPosition.Y, plateletHeight * 2 + startPosition.Y, plateletHeight * 3 + startPosition.Y, plateletHeight * 4 + startPosition.Y };
            var yOffset = plateletHeight / 2;

            for (int i = 0; i < 19; i++)
            {
#warning zu tief eingerückt
                var xPosition = startPosition.X;
                if (i < 3)
                    _positions[i] = new PlateletPrinter(xPosition, yPosition[i + 1], plateletWidth, plateletHeight);

                xPosition += (int)(plateletWidth * 0.75);
                if (i >= 3 && i < 7)
                    _positions[i] = new PlateletPrinter(xPosition, yOffset + yPosition[i - 3], plateletWidth, plateletHeight);

                xPosition += (int)(plateletWidth * 0.75);
                if (i >= 7 && i < 12)
                    _positions[i] = new PlateletPrinter(xPosition, yPosition[i - 7], plateletWidth, plateletHeight);

                xPosition += (int)(plateletWidth * 0.75);
                if (i >= 12 && i < 16)
                    _positions[i] = new PlateletPrinter(xPosition, yOffset + yPosition[i - 12], plateletWidth, plateletHeight);

                xPosition += (int)(plateletWidth * 0.75);
                if (i >= 16)
                    _positions[i] = new PlateletPrinter(xPosition, yPosition[i - 15], plateletWidth, plateletHeight);
            }
        }

        public bool PlaceAt(Platelet platelet, int fieldIndex)
        {
            return platelet.Place(_positions[fieldIndex]);
        }

        public bool PlaceAt(Platelet platelet, Point position)
        {
            var x = _positions.OrderBy(p =>
            {
#warning name to long
                return p.CalculateMinimumInnerCornerDistance(position);
            });

            var best = x.FirstOrDefault();

            if (best != null)
                return platelet.Place(best);

            return false;
        }

        internal bool Draw(Graphics graphics, Platelet platelet, Point mousePosition)
        {
            var x = _positions.OrderBy(p =>
            {
#warning name to long
                return p.CalculateMinimumInnerCornerDistance(mousePosition);
            });

            var best = x.FirstOrDefault();

            return platelet.Draw(graphics, best);
        }

        public bool Draw(Graphics g, Platelet platelet, int fieldIndex)
        {
            return platelet.Draw(g, _positions[fieldIndex]);
        }
    }
}
