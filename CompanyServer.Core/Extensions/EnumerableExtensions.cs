﻿namespace CompanyServer.Core.Extensions;

public static class EnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T> items, Action<T> callback)
    {
        foreach (var item in items)
        {
            callback(item);
        }
    }
}