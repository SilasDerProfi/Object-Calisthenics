using System;

namespace OC_GOL
{
    public class GameGrid
    {
        private readonly Cell[,] _cells;

        public GameGrid(uint size)
        {
            _cells = new Cell[size, size];
        }

        private int GetSize() => _cells.GetUpperBound(0)+1;

        public void Populate(bool[] seed)
        {
            for (int i = 0; i < seed.Length; i++)
                _cells[i / GetSize(), i % GetSize()] = new Cell(seed[i]);
        }

        internal void Print()
        {
            for (int i = 0; i < GetSize(); i++)
                PrintRow(i);
        }

        private void PrintRow(int row)
        {
            for (int cell = 0; cell < GetSize(); cell++)
                _cells[row, cell].Print();

            Console.WriteLine();
        }

        internal void Transform()
        {
            Cell[,] clone = (Cell[,])_cells.Clone();

            for (int i = 0; i < _cells.Length; i++)
            {
                int row = i / GetSize();
                int cell = i % GetSize();

                Cell[] neighbours = GetNeighbours(row, cell, clone);
                _cells[row, cell].Transform(neighbours);
            }
        }

        private Cell[] GetNeighbours(int row, int cell, Cell[,] clone)
        {
            Cell[] neighbours = new Cell[8];
            
            if (cell > 0) neighbours[0] = clone[row, cell - 1];
            if (cell < GetSize() - 1) neighbours[1] = clone[row, cell + 1];
            if (row > 0 && cell > 0) neighbours[2] = clone[row - 1, cell - 1];
            if (row > 0) neighbours[3] = clone[row - 1, cell];
            if (row > 0 && cell < GetSize() - 1) neighbours[4] = clone[row - 1, cell + 1];
            if (row < GetSize() - 1 && cell > 0) neighbours[5] = clone[row + 1, cell - 1];
            if (row < GetSize() - 1) neighbours[6] = clone[row + 1, cell];
            if (row < GetSize() - 1 && cell < GetSize() - 1) neighbours[7] = clone[row + 1, cell + 1];

            return neighbours;
        }
    }
}
