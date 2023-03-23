using System;
using System.Collections.Generic;

namespace AdventOfCode.Helpers
{
    public static class DictionaryExtensions
    {
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = updateValueFactory(key, dictionary[key]);
            }
            else
            {
                dictionary.Add(key, addValue);
            }
        }
    }
}
