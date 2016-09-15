using System;
using System.Collections.Generic;
using System.Reflection;
using Akomi.InformationModel.Attributes;
using ExtensionMethodsCollection;

namespace Tapako.ObjectMerger.Miscellanous
{
    internal static class AttributeEvaluator
    {
        /// <summary>
        /// Extension Method for memberInfo.
        /// This Method looks if any of the attached Attributes Contains false as value. Otherwise true will be returned
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <param name="defaultValue">This should be the Default value of TAttribute</param>
        /// <returns>true, if the object-instance is mergeable</returns>
        internal static bool EvaluateAttribute<TAttribute>(this MemberInfo memberInfo, bool defaultValue = true) where TAttribute : BoolAttributeBase
        {

            Attribute[] attrs = Attribute.GetCustomAttributes(memberInfo, true);  // Reflection.            

            return attrs.EvaluateAttribute<TAttribute>(defaultValue);

        }

        /// <summary>
        /// Extension Method for memberInfo.
        /// This Method looks if any of the attached Attributes Contains false as value. Otherwise true will be returned
        /// </summary>
        /// <param name="type"></param>
        /// <param name="defaultValue">This should be the Default value of TAttribute</param>
        /// <returns>true, if the object-instance is mergeable</returns>
        internal static bool EvaluateAttribute<TAttribute>(this Type type, bool defaultValue = true) where TAttribute: BoolAttributeBase
        {

            var attrs = type.GetCustomAttributesIncludingBaseInterfaces<TAttribute>();  // Reflection.            

            return attrs.EvaluateAttribute<TAttribute>(defaultValue);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="attributes"></param>
        /// <param name="defaultValue">This should be the Default value of TAttribute</param>
        /// <returns>Default return value is true for Attributes, which weren't found. For true All TAttribute.Value has to be true. </returns>
        internal static bool EvaluateAttribute<TAttribute>(this IEnumerable<Attribute> attributes, bool defaultValue = true) where TAttribute:BoolAttributeBase
        {
            bool returnValue = defaultValue;
            foreach (Attribute attr in attributes)
            {
                var boolAttr = attr as TAttribute;
                if (boolAttr != null)
                {
                    if (boolAttr.Value == defaultValue) // todo: diese zeile hat einige Tests kaputt gemacht
                    {
                        returnValue = defaultValue; //returnValue = boolAttr.Value;
                    }
                    else // im Value steht false, somit ist ein Teil als nicht Mergeable gekennzeichnet
                    {
                        return boolAttr.Value;
                    }
                }
            }
            return returnValue;
        }

    }
}
