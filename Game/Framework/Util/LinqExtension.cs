using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Util
{
    public static class LinqExtension
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
                yield return item;
            }
        }

        // https://stackoverflow.com/questions/38562688/force-ienumerablet-to-evaluate-without-calling-toarray-or-tolist
        public static void Evaluate<T>(this IEnumerable<T> enumerable)
        {
            // evaluate every element of enumerable now
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            enumerable.All(component => true);
        }
    }
}