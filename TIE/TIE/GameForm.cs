using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TIE.Data;
using TIE.Extensions;

namespace TIE
{
    public class GameForm : Form
    {
        private readonly List<Platelet> _platelets = new List<Platelet>();
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
            g.FillRectangle(Brushes.Black, 0, 0, pb.Width, pb.Height);

            var positioningHelper = new PositioningHelper(pb.Image.Size);

            for(int fieldIndex = 0; fieldIndex < 19; fieldIndex++)
                positioningHelper.Draw(g, p, fieldIndex);

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
            pb.Paint += PaintPlatelets;
            pb.MouseClick += Place;
            //Cursor.Hide();
        }

        private void Place(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var positioningHelper = new PositioningHelper(this.ClientSize);
                var mousePosition = PointToClient(Cursor.Position);

                for (int i = 0; !positioningHelper.PlaceAt( _platelets[i], mousePosition); i++) ;
            }
        }

        private void PaintPlatelets(object sender, PaintEventArgs e)
        {
            var positioningHelper = new PositioningHelper(this.ClientSize);
            var mousePosition = PointToClient(Cursor.Position);
            
            for (int i = 0; !positioningHelper.Draw(e.Graphics, _platelets[i], mousePosition); i++) ;
        }
    }
}
