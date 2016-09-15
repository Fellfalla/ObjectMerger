using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tapako.DeviceInformationManagement.Extensions;

namespace Tapako.DeviceInformationManagement.Miscellanous
{
    /// <summary>
    /// This Class holds some Additional functionalities to Merge Objects
    /// </summary>
    internal static class MergingHelper
    {

        /// <summary>
        /// Merge von 2 Dictionaries
        /// </summary>
        /// <param name="destinationList">Das Dictionaries, das erweitert wird</param>
        /// <param name="sourceList">Das Dictionaries, das die Quellobjekte enthält</param>
        /// <returns></returns>
        internal static Dictionary<TKey, TValue> MergeDictionaries<TKey, TValue>(Dictionary<TKey, TValue> destinationList, Dictionary<TKey, TValue> sourceList)
        {
            return destinationList.Merge(sourceList);
        }

        /// <summary>
        /// Merge von 2 IEnumerables
        /// </summary>
        /// <param name="destinationList">Das Enumerable, das erweitert wird</param>
        /// <param name="sourceList">Das Enumerable, das die Quellobjekte enthält</param>
        /// <param name="duplicatesAllowed"></param>
        /// <returns></returns>
        internal static IEnumerable<TItems> MergeIEnumerables<TItems>(IEnumerable<TItems> destinationList, IEnumerable<TItems> sourceList, bool duplicatesAllowed = true)
        {
            if (sourceList != null && destinationList != null)
            {
                Type commonType = destinationList.GetType().FindEqualTypeWith(sourceList.GetType());
                IEnumerable<TItems> mergedEnumerable;
                
                if (duplicatesAllowed)
                {
                    mergedEnumerable = destinationList.Concat(sourceList);
                }

                else // falls keine duplikate erlaubt sind
                {
                    mergedEnumerable = destinationList.Union(sourceList, new DeepEqualityComparer<TItems>());
                }

                if (commonType.IsArray)
                {
                    return mergedEnumerable.ToArray();
                }
                else if(typeof(IList).IsAssignableFrom(commonType))
                {
                    return mergedEnumerable.ToList();
                }

                return mergedEnumerable;
            }
            return destinationList;
        }
    }

    internal class DeepEqualityComparer<T> : IEqualityComparer<T>
    {
        /// <summary>
        /// Bestimmt, ob die angegebenen Objekte gleich sind.
        /// Wird nur aufgerufen, falls GetHashCode nicht bereits unterschiedliche Werte zurückgeliefert hat
        /// </summary>
        /// <returns>
        /// true, wenn die angegebenen Objekte gleich sind, andernfalls false.
        /// </returns>
        /// <param name="x">Das erste zu vergleichende Objekt vom Typ <typeparamref name="T"/>.</param>
        /// <param name="y">Das zweite zu vergleichende Objekt vom Typ <typeparamref name="T"/>.</param>
        public bool Equals(T x, T y)
        {
            if (x is IEqualityComparer<T>)
            {
                return ((IEqualityComparer<T>) x).Equals(x, y);
            }

            return x.IsDeepEqual(y) || x.Equals(y);
        }

        /// <summary>
        /// Gibt einen Hashcode für das angegebene Objekt zurück.
        /// </summary>
        /// <returns>
        /// Ein Hashcode für das angegebene Objekt.
        /// </returns>
        /// <param name="obj">Das <see cref="T:System.Object"/>, für das ein Hashcode zurückgegeben werden soll.</param><exception cref="T:System.ArgumentNullException">Der Typ von <paramref name="obj"/> ist ein Referenztyp, und <paramref name="obj"/> ist null.</exception>
        public int GetHashCode(T obj)
        {
            return true.GetHashCode(); // do not break after HashCode is not the same
        }
    }

}
