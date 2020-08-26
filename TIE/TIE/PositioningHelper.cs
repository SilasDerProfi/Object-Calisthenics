using System.Drawing;

namespace TIE
{
    class PositioningHelper
    {
        private Point[] _positions;
        public PositioningHelper(Size size)
        {
            _positions = new Point[19];

            var ratio = 152 / 165d;
            var startPosition = new Point(0,0);

            if (size.Height * ratio > size.Width)
            {
                var newWidth = (int)(size.Height * ratio);
                startPosition.X = (size.Width - newWidth) / 2;
                size.Width = newWidth;
            }

            if (size.Width / ratio > size.Height)
            {
                var newHeight = (int)(size.Width / ratio);
                startPosition.Y = (size.Height - newHeight) / 2;
                size.Height = newHeight;
            }

            int plateletWidth = size.Width / 4;
            int plateletHeight = size.Height / 5;

            var yPosition = new int[] { 0, plateletHeight * 1, plateletHeight * 2, plateletHeight * 3, plateletHeight * 4 };
            var yOffset = plateletHeight / 2;

            for (int i = 0; i < 19; i++)
            {
#warning zu tief eingerückt
                if (i < 3)
                    _positions[i] = new PlateletPrinter(0, yPosition[i + 1], plateletWidth, plateletHeight);

                var xPosition = (int)(plateletWidth * 0.75);
                if (i >= 3 && i < 7)
                    _positions[i] = new Point(xPosition, yOffset + yPosition[i - 3]);

                xPosition += (int)(plateletWidth * 0.75);
                if (i >= 7 && i < 12)
                    _positions[i] = new Point(xPosition, yPosition[i - 7]);

                xPosition += (int)(plateletWidth * 0.75);
                if (i >= 12 && i < 16)
                    _positions[i] = new Point(xPosition, yOffset + yPosition[i - 12]);

                xPosition += (int)(plateletWidth * 0.75);
                if (i >= 16)
                    _positions[i] = new Point(xPosition, yPosition[i - 15]);
            }
        }

        public void PlaceAt(Graphics g, Platelet platelet, int fieldIndex)
        {
            platelet.Draw(g, _positions[fieldIndex], );
        }
    }
}
