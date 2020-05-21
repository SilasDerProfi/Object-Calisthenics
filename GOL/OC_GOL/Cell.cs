using System;

namespace OC_GOL
{
    class Cell
    {
        private bool _isAlive;

        public Cell(bool isAlive)
        {
            _isAlive = isAlive;
        }

        public void Transform(Cell[] neighbours)
        {
            int neighbourCount = 0;

            foreach(var neighbour in neighbours)
                neighbourCount += Convert.ToInt32(neighbour?._isAlive);

            _isAlive = neighbourCount == 3 || _isAlive && neighbourCount == 2;
        }

        public void Print() => Console.Write(_isAlive ? "X " : ". ");
    }
}
