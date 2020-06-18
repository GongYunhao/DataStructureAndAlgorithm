using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonModels
{
    public static class ListExtension
    {
        public static bool ContainsSameElement<T>(this IList<T> source, IList<T> other)
        {
            if (source == null || other == null)
                return false;
            if (source.Count != other.Count)
                return false;

            T[] sourceArray = source.ToArray();
            T[] otherArray = other.ToArray();
            Array.Sort(sourceArray);
            Array.Sort(otherArray);

            for (int i = 0; i <= source.Count - 1; i++)
            {
                if (!sourceArray[i].Equals(otherArray[i]))
                    return false;
            }

            return true;
        }
    }
}
