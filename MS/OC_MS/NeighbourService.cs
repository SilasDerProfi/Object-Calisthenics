using System.Collections.Generic;

namespace OC_MS
{
    static class NeighbourService
    {

        public static List<int> GetNeighbours(int index, int rowLength, int rowCount)
        {
            var neighbours = new List<int>();

            int row = index / rowLength;
            int col = index % rowLength;

            if (row > 0 && col > 0)
                neighbours.Add(index - rowLength - 1);
            if (row > 0)
                neighbours.Add(index - rowLength);
            if (row > 0 && col < rowLength - 1)
                neighbours.Add(index - rowLength + 1);

            if (col > 0)
                neighbours.Add(index - 1);
            if (col < rowLength - 1)
                neighbours.Add(index + 1);

            if (row < rowCount - 1 && col > 0)
                neighbours.Add(index + rowLength - 1);
            if (row < rowCount - 1)
                neighbours.Add(index + rowLength);
            if (row < rowCount - 1 && col < rowLength - 1)
                neighbours.Add(index + rowLength + 1);


            return neighbours;
        }
    }
}
