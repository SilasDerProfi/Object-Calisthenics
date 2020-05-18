using System;
using System.Linq;
using System.Collections.Generic;

namespace OC_GOL
{
    public class GameGrid
    {
        private readonly Cell[,] _cells;

        public GameGrid(uint size)
        {
            _cells = new Cell[size, size];
        }

        private int GetSize() => (int)Math.Sqrt(_cells.Length);

        public void Populate(bool[] seed = null)
        {
            if (seed?.Length != _cells.Length)
            {
                var seedList = GetRandomSeed();
                seed = seedList.ToArray();
            }

            for (int i = 0; i < seed.Length; i++)
                _cells[i / GetSize(), i % GetSize()] = new Cell(seed[i]);
        }

        private IEnumerable<bool> GetRandomSeed()
        {
            Random random = new Random(GetSize());
            for (int i = 0; i < _cells.Length; i++)
                yield return random.Next(0, 5) == 0;
        }

        internal void Print()
        {
            for (int i = 0; i < GetSize(); i++)
                PrintRow(i, GetSize());
        }

        private void PrintRow(int row, int size)
        {
            for (int cell = 0; cell < size; cell++)
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
                this._cells[row, cell].Transform(neighbours);
            }
        }

        /// <summary>
        /// Das ist kake. Ganze Klasse evtl. auf 50 Zeilen
        /// </summary>
        private Cell[] GetNeighbours(int row, int cell, Cell[,] clone)
        {
            Cell[] neighbours = new Cell[GetSize()];

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
