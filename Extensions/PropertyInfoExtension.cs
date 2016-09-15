using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Tapako.DeviceInformationManagement.Extensions
{
    /// <summary>
    /// Extensions for PropertyInfos
    /// </summary>
    static class PropertyInfoExtension
    {

        /// <summary>
        /// Source: http://stackoverflow.com/questions/3672377/property-get-set-delegates-for-runtime-reflected-class
        /// use: getter.DynamicInvoke(myClass)
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static Delegate CreateGetter(this PropertyInfo property)
        {
            if (property.DeclaringType != null)
            {
                var objParm = Expression.Parameter(property.DeclaringType, "o");
                Type delegateType = typeof(Func<,>).MakeGenericType(property.DeclaringType, property.PropertyType);
                var lambda = Expression.Lambda(delegateType, Expression.Property(objParm, property.Name), objParm);
                return lambda.Compile();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Source: http://stackoverflow.com/questions/3672377/property-get-set-delegates-for-runtime-reflected-class
        /// setter.DynamicInvoke(myClass, "Hello");
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static Delegate CreateSetter(this PropertyInfo property)
        {
            if (property.DeclaringType != null)
            {
                var objParm = Expression.Parameter(property.DeclaringType, "o");
                var valueParm = Expression.Parameter(property.PropertyType, "value");
                Type delegateType = typeof(Action<,>).MakeGenericType(property.DeclaringType, property.PropertyType);
                var lambda = Expression.Lambda(delegateType, Expression.Assign(Expression.Property(objParm, property.Name), valueParm), objParm, valueParm);
                return lambda.Compile();
            }
            else
            {
                return null;
            }
        }
    }

    static class MemberInfoExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <param name="obj">The object whose property value will be set</param>
        /// <param name="newValue"></param>
        /// <returns>True if Set was sucessful</returns>
        public static bool SetValue(this MemberInfo memberInfo, object obj, object newValue)
        {
            if (memberInfo is PropertyInfo)
            {
                var propertyInfo = (PropertyInfo)memberInfo;

                propertyInfo.SetValue(obj, newValue);

                return true;
            }

            if (memberInfo is FieldInfo)
            {
                var fieldInfo = (FieldInfo) memberInfo;

                fieldInfo.SetValue(obj, newValue);

                return true;
            }

            return false;
        }
    }
}
