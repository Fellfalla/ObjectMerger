using System;
using Akomi.Logger;
using KellermanSoftware.CompareNetObjects;

namespace Tapako.DeviceInformationManagement.Extensions
{
    /// <summary>
    /// Extension methods for objects
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns a bool which depends on the objects content.
        /// True will be returned, if the object was isntanziated by the default constructor without modifying any members
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsDefaultConstructed<T>(this T obj)
        {
            //var constructor = obj.GetType().GetConstructor(Type.EmptyTypes);
            //constructor.Invoke(null);
            object defaultConstructed = default(T);
            try
            {
                defaultConstructed = Activator.CreateInstance(obj.GetType());
            }
            catch (MissingMethodException)
            {
                // If no default constructor is available -> For shure no pure and dumb initialization
                return false;
            }
            catch (MemberAccessException)
            {
                Logger.Debug(
                    "Cannot test if instance of \"{0}\" was default constructed due to access limitations of \"{1}\".",
                    obj, obj.GetType().Name);
            }

            if (defaultConstructed.Equals(obj))
            {
                // Falls der standardvergleich true zurückgibt, sind die beiden objekte auf jeden fall schonmal gleich
                return true;
            }

            // Make Deep Compare
            CompareLogic compareLogic = new CompareLogic();
            return compareLogic.Compare(obj, defaultConstructed).AreEqual;
        }

        /// <summary>
        /// Executes a deep comparison
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsDeepEqual<T>(this T obj, T other)
        {
            if (object.ReferenceEquals(obj, other))
            {
                return true;
            }

            CompareLogic compareLogic = new CompareLogic();
            return compareLogic.Compare(obj, other).AreEqual;
        }


    }
}
