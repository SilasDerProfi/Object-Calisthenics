using System;
using System.Drawing;

namespace TIE.Extensions
{
    public static class PointExtensions
    {
        /// <summary>
        /// Calculates the distance of two <see cref="Point"/>s using the Pythagorean theorem
        /// </summary>
        public static decimal CalculateDistance(this Point pointA, Point pointB)
        {
            var adjacent = pointA.X - pointB.X;
            var opposite = pointA.Y - pointB.Y;

            var adjacentSquare = adjacent * adjacent;
            var oppositeSquare = opposite * opposite;

            var hypotenuse = (decimal)Math.Sqrt(adjacentSquare + oppositeSquare);
            return hypotenuse;
        }
    }
}
