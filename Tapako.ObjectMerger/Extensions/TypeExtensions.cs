using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapako.ObjectMerger.Extensions
{
    internal static class TypeExtensions
    {
        /// <summary>
        /// Source: http://stackoverflow.com/questions/1846671/determine-if-collection-is-of-type-ienumerablet
        /// </summary>
        /// <param name="type"></param>
        /// <param name="genericArgumentNumber"></param>
        /// <returns></returns>
        public static Type GetEnumerableType(this Type type, int genericArgumentNumber = 0)
        {
            foreach (Type intType in type.GetInterfaces())
            {
                if (intType.IsGenericType
                    && intType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    return intType.GetGenericArguments()[genericArgumentNumber];
                }
            }
            return null;
        }

        /// <summary>
        /// Source: Akomi.Utilities.ExtensionMethods
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<TAttribute> GetCustomAttributesIncludingBaseInterfaces<TAttribute>(this Type type) where TAttribute : Attribute
        {
            var attributeType = typeof (TAttribute);
            return
                type.GetCustomAttributes(attributeType, true)
                    .Union(
                        type.GetInterfaces()
                            .SelectMany(interfaceType => interfaceType.GetCustomAttributes(attributeType, true)))
                    .Distinct()
                    .Cast<TAttribute>();
        }
    }
}
