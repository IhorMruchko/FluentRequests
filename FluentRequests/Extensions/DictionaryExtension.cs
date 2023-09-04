using System.Collections.Generic;

namespace FluentRequests.Lib.Extensions
{
    public static class DictionaryExtension
    {
        public static TKey GetKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TValue value)
        {
            foreach(var key in dictionary.Keys)
                if (dictionary[key].Equals(value)) return key;
            return default;
        }
    }
}
