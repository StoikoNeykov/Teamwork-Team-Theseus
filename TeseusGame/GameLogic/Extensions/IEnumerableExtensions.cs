namespace GameLogic.Extensions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// IEnumerable Extensions
    /// </summary>
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
            return collection;
        }
    }
}
