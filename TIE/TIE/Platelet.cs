using System;
using System.Drawing;
using System.Windows.Forms;
using TIE.Data;

namespace TIE
{
    internal class Platelet
    {
        private readonly Bitmap display;

        public Platelet(PlateletValue leftValue = null, PlateletValue centerValue = null, PlateletValue rightvalue = null)
        {
            if ((leftValue == null || centerValue == null || rightvalue == null))
            {
                display = Properties.Resources.hexagon;
                return;
            }

            display = Properties.Resources.hexagonColored;


            var colors = new Color[] { Color.Gray, Color.Fuchsia, Color.DarkOrchid, Color.DarkRed, Color.LightBlue, Color.Red, Color.LimeGreen, Color.Orange, Color.Yellow };
            var slashColor = colors[leftValue - 1];
            using var graphics = Graphics.FromImage(display);

            // Slash
            using var pen = new Pen(slashColor, 80);
            graphics.DrawLine(pen, 95, 500, 670, 170);

            // Backslash
            pen.Color = colors[rightvalue - 1];
            graphics.DrawLine(pen, 90, 165, 663, 496);

            // Vertical
            pen.Color = colors[centerValue - 1];
            graphics.DrawLine(pen, 380, 0, 380, 660);
        }

        internal void Draw(Graphics g, int v1, int v2, int v3, int v4) => g.DrawImage(display, v1, v2, v3, v4);

        internal bool Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}