namespace Core
{
    using System;
    using System.Collections.Generic;

    internal class Shuffler
    {
        internal void Shuffle<T>(IList<T> array)
        {
            var random = new Random();
            var n = array.Count;
            while (n > 1)
            {
                var k = random.Next(n--);
                var temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}