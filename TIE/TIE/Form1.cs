using System.Drawing;
using System.Windows.Forms;

namespace TIE
{
    public class Form1 : Form
    {
        public Form1()
        {
            var p = new Platelet(8, 9, 7);

            PictureBox pb = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill,
                BackColor = Color.Black,
                Image = new Bitmap(760 * 4, 660 * 5)
            };

            using (var g = Graphics.FromImage(pb.Image))
            {
                var yPosition = new int[] {0, 660 * 1, 660 * 2, 660 * 3 , 660 * 4 };
                var yOffset = 660 / 2;

                g.FillRectangle(Brushes.Black, 0, 0, pb.Width, pb.Height);

                g.DrawImage(p.display, 0, yPosition[1], 760, 660);
                g.DrawImage(p.display, 0, yPosition[2], 760, 660);
                g.DrawImage(p.display, 0, yPosition[3], 760, 660);
                
                var xPosition = (int)(760 * 0.75);

                g.DrawImage(p.display, xPosition, yOffset + yPosition[0], 760, 660);
                g.DrawImage(p.display, xPosition, yOffset + yPosition[1], 760, 660);
                g.DrawImage(p.display, xPosition, yOffset + yPosition[2], 760, 660);
                g.DrawImage(p.display, xPosition, yOffset + yPosition[3], 760, 660);

                xPosition += (int)(760 * 0.75);

                g.DrawImage(p.display, xPosition, yPosition[0], 760, 660);
                g.DrawImage(p.display, xPosition, yPosition[1], 760, 660);
                g.DrawImage(p.display, xPosition, yPosition[2], 760, 660);
                g.DrawImage(p.display, xPosition, yPosition[3], 760, 660);
                g.DrawImage(p.display, xPosition, yPosition[4], 760, 660);

                xPosition += (int)(760 * 0.75);

                g.DrawImage(p.display, xPosition, yOffset + yPosition[0], 760, 660);
                g.DrawImage(p.display, xPosition, yOffset + yPosition[1], 760, 660);
                g.DrawImage(p.display, xPosition, yOffset + yPosition[2], 760, 660);
                g.DrawImage(p.display, xPosition, yOffset + yPosition[3], 760, 660);

                xPosition += (int)(760 * 0.75);

                g.DrawImage(p.display, xPosition, yPosition[1], 760, 660);
                g.DrawImage(p.display, xPosition, yPosition[2], 760, 660);
                g.DrawImage(p.display, xPosition, yPosition[3], 760, 660);
            }

            this.Controls.Add(pb);

            //var stringPlatelets = TIE.Properties.Resources.Platelets.Split(Environment.NewLine);

            //var platelets = new List<Platelet>();

            //foreach (var platelet in stringPlatelets)
            //{
            //    var values = platelet.Split(';');
            //    var leftValue = Int32.Parse(values[0]);
            //    var centerValue = Int32.Parse(values[1]);
            //    var rightValue = Int32.Parse(values[2]);
            //    var plateletObject = new Platelet(leftValue, centerValue, rightValue);
            //    platelets.Add(plateletObject);
            //}
        }
    }
}
