using System;
using System.Collections.Generic;
using System.Linq;

namespace OC_MS
{
    static class Gamegenerator
    {
        internal static int[] Generate(int sizeX, int sizeY, int mineCount)
        {
            int[] mineGrid = new int[sizeX * sizeY];

            var random = new Random();
            var mineLocations = new HashSet<int>(mineCount);
            while (mineLocations.Count < mineCount)
            {
                var location = random.Next(0, mineGrid.Length);
                mineLocations.Add(location);
                mineGrid[location] = -1;
            }

            var neighbours = new List<int>();
            foreach(var mine in mineLocations)
            {
                var currentNeighbours = NeighbourService.GetNeighbours(mine, sizeX, sizeY);
                neighbours.AddRange(currentNeighbours);
            }

            var safeNeighbours = neighbours.Where(n => mineGrid[n] >= 0);

            foreach (var neighbourIndex in safeNeighbours)
                mineGrid[neighbourIndex]++;

            return mineGrid;
        }
    }
}
