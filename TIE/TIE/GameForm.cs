using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using TIE.Data;
using TIE.Extensions;

namespace TIE
{
    public class GameForm : Form
    {
        private List<Platelet> _platelets = new List<Platelet>();
        public GameForm()
        {
            PictureBox pb = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left,
                Location = new Point(0, 0),
                Size = this.ClientSize,
                BackColor = Color.Black,
                Image = new Bitmap(760 * 4, 660 * 5)
            };

            var p = new Platelet();
            using var g = Graphics.FromImage(pb.Image);

            var yPosition = new int[] { 0, 660 * 1, 660 * 2, 660 * 3, 660 * 4 };
            var yOffset = 660 / 2;

            g.FillRectangle(Brushes.Black, 0, 0, pb.Width, pb.Height);

            p.Draw(g, 0, yPosition[1], 760, 660);
            p.Draw(g, 0, yPosition[1], 760, 660);
            p.Draw(g, 0, yPosition[2], 760, 660);
            p.Draw(g, 0, yPosition[3], 760, 660);

            var xPosition = (int)(760 * 0.75);
            p.Draw(g, xPosition, yOffset + yPosition[0], 760, 660);
            p.Draw(g, xPosition, yOffset + yPosition[1], 760, 660);
            p.Draw(g, xPosition, yOffset + yPosition[2], 760, 660);
            p.Draw(g, xPosition, yOffset + yPosition[3], 760, 660);

            xPosition += (int)(760 * 0.75);
            p.Draw(g, xPosition, yPosition[0], 760, 660);
            p.Draw(g, xPosition, yPosition[1], 760, 660);
            p.Draw(g, xPosition, yPosition[2], 760, 660);
            p.Draw(g, xPosition, yPosition[3], 760, 660);
            p.Draw(g, xPosition, yPosition[4], 760, 660);

            xPosition += (int)(760 * 0.75);
            p.Draw(g, xPosition, yOffset + yPosition[0], 760, 660);
            p.Draw(g, xPosition, yOffset + yPosition[1], 760, 660);
            p.Draw(g, xPosition, yOffset + yPosition[2], 760, 660);
            p.Draw(g, xPosition, yOffset + yPosition[3], 760, 660);

            xPosition += (int)(760 * 0.75);
            p.Draw(g, xPosition, yPosition[1], 760, 660);
            p.Draw(g, xPosition, yPosition[2], 760, 660);
            p.Draw(g, xPosition, yPosition[3], 760, 660);

            this.Controls.Add(pb);

            var stringPlatelets = Properties.Resources.Platelets.Split(Environment.NewLine);

            foreach (var platelet in stringPlatelets)
            {
                var values = platelet.Split(';');
                var leftValue = (PlateletValue)Int32.Parse(values[0]);
                var centerValue = (PlateletValue)Int32.Parse(values[1]);
                var rightValue = (PlateletValue)Int32.Parse(values[2]);
                var plateletObject = new Platelet(leftValue, centerValue, rightValue);
                _platelets.Add(plateletObject);
            }
            _platelets.Shuffle();

            pb.MouseMove += (sender, e) => ((Control)sender).Invalidate();
            pb.Paint += Paint;
        }

        private void Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; _platelets[i].Draw(e.Graphics); i++) ;
        }
    }
}
