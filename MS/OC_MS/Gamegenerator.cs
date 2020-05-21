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

            var r = new Random();
            var mineLocations = new HashSet<int>(mineCount);
            var neighbours = new List<int>();
            while (mineLocations.Count < mineCount)
            {
                var location = r.Next(0, mineGrid.Length);
                mineLocations.Add(location);
                mineGrid[location] = -1;
            }

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
