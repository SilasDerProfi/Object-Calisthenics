
using System;

namespace OC_GOL
{
    public class Game
    {
        private readonly GameGrid _grid;
        private uint _generation = 1;

        public Game(bool[] seed = null, uint size = 8)
        {
            _grid = new GameGrid(size);
            _grid.Populate(seed);
            Print();
        }

        public void Transform()
        {
            _generation++;
            _grid.Transform();
        }

        public void Print()
        {
            Console.WriteLine($"Generation {_generation}");
            _grid.Print();
        }
    }
}
