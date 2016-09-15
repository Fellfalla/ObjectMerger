using System.Collections.Generic;

namespace Tapako.DeviceInformationManagement.Extensions
{
    /// <summary>
    /// Extension Methods for <see cref="Dictionary{TKey,TValue}"/>
    /// </summary>
    public static class DictionaryExtensionMethods
    {
        /// <summary>
        /// Merges 2 Dictionaries into a new one
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict1"></param>
        /// <param name="dict2"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> Merge<TKey, TValue>(this Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        {
            Dictionary<TKey, TValue> mergedDictionary = new Dictionary<TKey, TValue>();
            foreach (var item in dict1)
            {
                mergedDictionary[item.Key] = item.Value;
            }
            foreach (var item in dict2)
            {
                mergedDictionary[item.Key] = item.Value;
            }
            return mergedDictionary;
        }
    }
}
