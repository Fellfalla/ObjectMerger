using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapako.ObjectMergerTests.ExtensionMethods
{
    /// <summary>
    /// 
    /// </summary>
    static class IEnumerableExtensions
    {
        /// <summary>
        /// Source: Akomi.Utilities.IEnumerableExtensions
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static int GetCount(this IEnumerable enumerable)
        {
            ICollection c = enumerable as ICollection;
            if (c != null)
                return c.Count;

            int result = 0;
            var enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                result++;

            }
            return result;
        }
        
        /// <summary>
        /// Source: Akomi.Utilities.IEnumerableExtensions
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool Any(this IEnumerable enumerable)
        {
            int count = enumerable.GetCount();
            return count > 0;
        }
    }
}
