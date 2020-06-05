using System.Drawing;

namespace TIE
{
    internal class Platelet
    {
        public Platelet(int leftValue, int centerValue, int rightvalue)
        {
            display = Properties.Resources.hexagon;

            var colors = new Color[] { Color.Gray, Color.Fuchsia, Color.DarkOrchid, Color.DarkRed, Color.LightBlue, Color.Red, Color.LimeGreen, Color.Orange, Color.Yellow };

            var slashColor = colors[leftValue - 1];
            using var graphics = Graphics.FromImage(display);
            using var pen = new Pen(slashColor, 80);

            //// Slash
            //graphics.DrawLine(pen, 92, 493, 665, 166);

            //// Backslash
            //pen.Color = colors[rightvalue - 1];
            //graphics.DrawLine(pen, 90, 165, 663, 496);

            //// Vertical
            //pen.Color = colors[centerValue - 1];
            //graphics.DrawLine(pen, 380, 0, 380, 660);
        }

        public Bitmap display;
    }
}