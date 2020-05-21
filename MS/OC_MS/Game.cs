using System;
using System.Windows.Forms;

namespace OC_MS
{
    public partial class Game : Form
    {
        private int _mineCount = 15;
        private readonly int _sizeX;
        public Game(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            ClientSize = new System.Drawing.Size(sizeX * 40, sizeY * 40);
            Text = $"Minesweeper ({_mineCount})";

            var mineGrid = Gamegenerator.Generate(sizeX, sizeY, _mineCount);
            for (int cellCount = 0; cellCount < sizeX * sizeY; cellCount++)
            {
                var newCell = new Cell(mineGrid[cellCount]);
                newCell.Width = 40;
                newCell.Height = 40;
                newCell.Name = $"{cellCount}";
                newCell.Location = new System.Drawing.Point((cellCount / sizeX) * 40, (cellCount % sizeX) * 40);
                newCell.Font = new System.Drawing.Font(newCell.Font.FontFamily, 18);
                newCell.BackgroundImageLayout = ImageLayout.Zoom;
                Controls.Add(newCell);
            }
        }

        public void UpdateAmount(bool decrease)
        {
            _mineCount += decrease ? -1 : 1;
            this.Text = $"Minesweeper ({_mineCount})";
        }

        public void RevealNeighbours(string name)
        {
            Int32.TryParse(name, out int index);
            var neighbours = NeighbourService.GetNeighbours(index, _sizeX, Controls.Count / _sizeX);

            foreach(var neighbourIndex in neighbours)
                (Controls[neighbourIndex] as Button).PerformClick();
        }
    }
}