using System;

namespace OC_GOL
{
    public class GameGrid
    {
        private readonly Cell[,] _cells;

        public GameGrid(uint size)
        {
            _cells = new Cell[size + 2, size + 2];
        }

        private int GetSize() => _cells.GetUpperBound(0) - 1;
        private int GetLength() => GetSize() * GetSize();
        private int GetRow(int i) => i / GetSize() + 1;
        private int GetColumn(int i) => i % GetSize() + 1;

        public void Populate(bool[] seed)
        {
            for (int i = 0; i < GetLength(); i++)
                _cells[GetRow(i), GetColumn(i)] = new Cell(seed[i]);
        }

        internal void Print()
        {
            for (int i = 1; i < GetSize(); i++)
                PrintRow(i);
        }

        private void PrintRow(int row)
        {
            for (int column = 1; column < GetSize(); column++)
                _cells[row, column].Print();

            Console.WriteLine();
        }

        internal void Transform()
        {
            Cell[,] clone = (Cell[,])_cells.Clone();

            for (int i = 0; i < GetLength(); i++)
            {
                Cell[] neighbours = GetNeighbours(GetRow(i), GetColumn(i), clone);
                _cells[GetRow(i), GetColumn(i)].Transform(neighbours);
            }
        }

        private Cell[] GetNeighbours(int row, int column, Cell[,] clone) => new Cell[]
        {
            clone[row, column - 1], clone[row, column + 1], clone[row - 1, column - 1],
            clone[row - 1, column], clone[row - 1, column + 1], clone[row + 1, column - 1],
            clone[row + 1, column], clone[row + 1, column + 1]
        };
    }
}
