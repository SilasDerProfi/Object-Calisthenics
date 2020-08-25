using System;
using System.Collections.Generic;
using System.Linq;

namespace TIE.Extensions
{
    static class ListExtensions
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// Shuffles a List using <see cref="System.Random"/>
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            var size = list.Count;
            for (var index = 0; index < size; index++)
            {
                var newIndex = random.Next(size);
                var item = list.ElementAt(index);

                list[index] = list[newIndex];
                list[newIndex] = item;
            }
        }
    }
}
