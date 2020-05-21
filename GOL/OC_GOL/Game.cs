using System;
using System.Collections.Generic;
using System.Linq;

namespace OC_GOL
{
    public class Game
    {
        private readonly GameGrid _grid;
        private uint _generation = 1;

        public Game(bool[] seed = null, uint size = 8)
        {
            if (seed?.Length != size * size)
            {
                var seedList = GetRandomSeed(size);
                seed = seedList.ToArray();
            }

            _grid = new GameGrid(size, seed);

            Print();
        }

        private IEnumerable<bool> GetRandomSeed(uint size)
        {
            uint cellCount = size * size;
            
            // 20 % leben zu beginn
            Random random = new Random((int)size);
            for (int i = 0; i < cellCount; i++)
                yield return random.Next(0, 5) == 0;
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
