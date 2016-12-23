using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tapako.ObjectMerger.Attributes;
using Tapako.ObjectMerger.Extensions;
using Tapako.ObjectMerger.Miscellanous;

namespace Tapako.ObjectMerger
{
    /// <summary>
    /// Dieser Klasse übernimmt das Zusammenführen von Informationen 2er Klasseninstanzen in eine einzige Instanz.
    /// </summary>
    public static class ObjectMerger
    {
        private static bool _copyEqualValues = true;

        /// <summary>
        /// Gibt an, ob z.b. zwei Listen, welche identische Strings enthalten, erweitert werden oder nicht
        /// </summary>
        public static bool CopyEqualValues
        {
            get { return _copyEqualValues; }
            set { _copyEqualValues = value; }
        }


        /// <summary>
        /// Merged eine Liste von Objekten
        /// </summary>
        /// <param name="obj">All informations will be merged into this object</param>
        /// <param name="mergingObjects"></param>
        /// <returns></returns>
        public static T MergeObjects<T>(T obj, params object[] mergingObjects)
        {
            //mergedDevice = MergeObjectFields(destinationObject, sourceObject);
            //mergedDevice = MergeObjectProperties(mergedDevice, sourceObject);
            foreach (var item in mergingObjects)
            {
                obj = MergeObjects(obj, item);
            }

            return obj;
        }

        /// <summary>
        /// Merges objects asynchronously
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="destination"></param>
        /// <param name="mergingObjects"></param>
        /// <returns></returns>
        public static async Task<T1> AsyncMergeObjects<T1>(T1 destination, params object[] mergingObjects)
        {
            return await Task.Run(() => MergeObjects(destination, mergingObjects));
        }

        /// <summary>
        /// Replaces recursive references from any child object to <paramref name="rootObject"/> in the <paramref name="rootObject"/> object hierarchy with references 
        /// to <paramref name="to"/>.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="rootObject"></param>
        /// <returns>All ObjectTreeItems which have been redirected to <paramref name="to"/></returns>
        public static List<ObjectTreeItem> RedirectRecursions(object rootObject, object to)
        {
            var sourceTree = new ObjectTreeItem(rootObject);
            var resultList = new List<ObjectTreeItem>();
            sourceTree.CreateTree();
            foreach (var recursiveSourceTreeItem in sourceTree.RecursionObjectTreeItems)
            {
                if (!ReferenceEquals(recursiveSourceTreeItem.Item, rootObject))
                {
                    Trace.TraceInformation(sourceTree.ToFormattedString());
                    throw new Exception("<<<< BUG IN OBJECT TREE>>>>>\nExpected Item: \"" + rootObject+ "\". Actual Item: \"" + recursiveSourceTreeItem.Parent.Item + "\".");
                }

                if (recursiveSourceTreeItem.MemberInfo.SetValue(recursiveSourceTreeItem.Parent.Item, to))
                {
                    resultList.Add(recursiveSourceTreeItem);
                }

            }
            return resultList;
        }

        /// <summary>
        /// Restores the recursive pointer to <paramref name="to"/> for all <paramref name="itemsToRedirect"/>
        /// </summary>
        /// <param name="itemsToRedirect"></param>
        /// <param name="to"></param>
        public static List<ObjectTreeItem> RedirectRecursions(IEnumerable<ObjectTreeItem> itemsToRedirect, object to)
        {
            var resultList = new List<ObjectTreeItem>();
            foreach (var redirectedItem in itemsToRedirect)
            {
                if (redirectedItem.MemberInfo.SetValue(redirectedItem.Parent.Item, to))
                {
                    resultList.Add(redirectedItem);
                }
            }
            return resultList;
        }


        /// <summary>
        /// Fügt Informationen von mehreren Objekten in ein neues Objekt ein
        /// ACHTUNG !!!! Diese Funktion verändert im momentanen Zustand den Übergabeparameter !!!!
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static T1 MergeObjects<T1>(T1 destination, object source, object parent = null)
        {
            T1 result; // = Activator.CreateInstance<T>();

            if (ReferenceEquals(destination, source))
            {
                return destination;
            }
            else if (destination == null && source == null)
            {
                return default(T1);
            }
            else if (source == null)
            {
                return destination;
            }
            else if (destination == null)
            {
                return (T1) source;
            }

            // Replace one Object if they aren't Mergeable
            else if (!destination.GetType().EvaluateAttribute<IsMergeable>(IsMergeable.DefaultValue))
                //!AttributeEvaluator.IsMergeable(new Type[]{destination.GetType()})) // Falls die übergebenen Klassen nicht mit dem IsMergeable attribut assoziiert wurden
            {
                // If destination is default constructed, do copy new one
                if (destination.IsDefaultConstructed() && !source.IsDefaultConstructed())
                {
                    ObjectMergerLogger.GetInstance().Debug("Overriding \"{0}\" with new value \"{1}\"", destination, source);
                    return (T1) source;
                }

                // If source is default constructed do not copy new one
                else if (source.IsDefaultConstructed())
                {
                    return destination;
                }

                // if nothing is default, take the new one
                else
                {
                    return (T1) source;
                }
            }

            Type destinationType = destination.GetType();
            Type sourceType = source.GetType();
            Type commonType = destinationType.FindEqualTypeWith(sourceType);


            // Resolve hierarchy recursions
            var redirectedSourceItems = RedirectRecursions(source, null);
            var redirectedDestinationItems = RedirectRecursions(destination, null);

            // Falls das Objekt ein Primitiver datentyp ist
            // Wird als erstes abgeprüft, da dies der häufigste Fall ist
            if (destinationType.IsValueType)
            {
                // Falls der Datentyp Primitive ist, wird der neue Wert genommen
                result = (T1) source;
            }

            else if (destinationType == typeof (string))
                // Da Strings vom Type IEnumerable<Char> sind, müssen diese vorher abgefangen werden
            {
                result = (T1) source;
            }

            else if (typeof (MemberInfo).IsAssignableFrom(commonType)) // Member Infos machen immer wieder probleme
            {
                string parentString = parent != null ? parent.ToString() : "unknown parent";
                string memberString = ((MemberInfo) source).Name;

                ObjectMergerLogger.GetInstance().Warning("Member info \"{0}\" in \"{1}\" was copied", memberString, parentString);
                result = (T1) source;
            }

            else if (typeof (Delegate).IsAssignableFrom(commonType))
                // Delegaten können zwar kopiert werden, sind aber evtl. nicht sinnvoll, da sie ihren ursprünglichen Besitzer referenzieren
            {
                string parentString = parent != null ? parent.ToString() : "unknown parent";
                string memberString = ((Delegate) source).Method.Name;

                ObjectMergerLogger.GetInstance().Warning(
                    "Member info \"{0}\" in \"{1}\" was copied. \n The Reference to its original parent may remain.",
                    memberString, parentString);
                result = (T1) source;
            }

            else if (commonType.IsGenericType && typeof (Dictionary<,>) == commonType.GetGenericTypeDefinition())
                //Dictionaries behandeln
            {
                Type enumerationType1 = commonType.GetGenericArguments()[0];
                Type enumerationType2 = commonType.GetGenericArguments()[1];
                // I want to create a List<?> containing the existing
                // object, but strongly typed to the "right" type depending
                // on the type of the value of x
                MethodInfo method = typeof (MergingHelper).GetMethod("MergeDictionaries",
                    BindingFlags.NonPublic | BindingFlags.Static); // todo: String per referenz ermitteln
                //MethodInfo method = SymbolExtensions.GetMethodInfo(() => MergingHelper.MergeDictionaries<T,T>(destination, source));

                method = method.MakeGenericMethod(new Type[] {enumerationType1, enumerationType2});
                var mergedIEnumerable = method.Invoke(null, new[] {destination, source});

                result = (T1) mergedIEnumerable;
            }

            // Allgemeine Methode für Listen
            else if (typeof (ICollection).IsAssignableFrom(commonType))
                //(destinationType == typeof(IEnumerable<object>))
            {
                Type enumerationType = destinationType.GetEnumerableType();

                MethodInfo method = typeof (MergingHelper).GetMethod("MergeIEnumerables",
                    BindingFlags.NonPublic | BindingFlags.Static); // todo: String per referenz ermitteln
                //MethodInfo method =
                //    SymbolExtensions.GetMethodInfo(() => MergingHelper.MergeIEnumerables(destination, source, true));

                // Sowohl der Container, als auch die beinhalteten Elemente müssen Duplizierung zulassen
                bool duplicatesAllowed =
                    destinationType.EvaluateAttribute<DuplicatesAllowed>(DuplicatesAllowed.DefaultValue) &&
                    enumerationType.EvaluateAttribute<DuplicatesAllowed>(DuplicatesAllowed.DefaultValue);

                method = method.MakeGenericMethod(new Type[] {enumerationType});
                var mergedIEnumerable = method.Invoke(null,
                    new[] {destination, source, duplicatesAllowed});
                // todo : Attribute Container übergeben, damit das flexibler ist

                if (commonType.GetConstructor(new[] {mergedIEnumerable.GetType()}) != null)
                {
                    result = (T1) Activator.CreateInstance(commonType, new object[] {mergedIEnumerable});
                }
                else
                {
                    result = (T1) mergedIEnumerable;
                }
            }


            // Ansonsten ist der Datentyp weder Primitiv noch eine Liste, somit mir rekursiv weiter das Standardverfahren angewendet
            else
            {
                result = MergeObjectFields(destination, source);
                result = MergeObjectProperties(result, source);
            }

            RedirectRecursions(redirectedDestinationItems, destination);
            RedirectRecursions(redirectedSourceItems, source);

            return result;
        }

        /// <summary>
        /// Kombiniert alle in Feldern enthaltenen Informationen der Objekte, Falls diese im verlangten Datentyp definiert wurden
        /// </summary>
        /// <param name="destinationObject"></param>
        /// <param name="sourceObject"></param>
        /// <returns></returns>
        private static T1 MergeObjectFields<T1>(T1 destinationObject, object sourceObject)
        {
            var sourceObjectType = sourceObject.GetType();
            var destinationObjectType = destinationObject.GetType();
            var commonType = destinationObjectType.FindEqualTypeWith(sourceObjectType);

            // Für jedes Feld des verlangten Datentypen
            //foreach (var field in commonType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static ).Where((field) => !field.IsLiteral))
            // todo: Achtung, da hier Compilergenerierte Felder ausgeschlossen werden, kann die Funktionalität bei anderen Compilern beeinträchtigt sein (Backed Fields werden dann nicht ausgeschlossen)

            var fields = commonType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttribute<CompilerGeneratedAttribute>() == null);

            foreach (var fieldInfo in fields)
            {
                SetFieldValue(destinationObject, sourceObject, fieldInfo);
            }

            //Parallel.ForEach(fields, (field) =>
            //{
            //    SetFieldValue(destinationObject, sourceObject, field);
            //});
            return destinationObject;
        }

        /// <summary>
        /// Legt <paramref name="field"/> in <paramref name="destinationObject"/> auf den Wert <paramref name="sourceObject"/>
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="destinationObject"></param>
        /// <param name="sourceObject"></param>
        /// <param name="field"></param>
        private static void SetFieldValue<T1>(T1 destinationObject, object sourceObject, FieldInfo field)
        {
            if (field.EvaluateAttribute<IgnoreAtMerging>(IgnoreAtMerging.DefaultValue)) // If true this field is ignored
            {
                return;
            }

            if (!field.EvaluateAttribute<IsMergeable>(IsMergeable.DefaultValue))
            {
                field.SetValue(destinationObject, field.GetValue(sourceObject));
            }

            else if (field.GetValue(destinationObject) == null)
            {
                // Falls das Feld im Ziel nicht initialisiert ist -> kopieren
                field.SetValue(destinationObject, field.GetValue(sourceObject));
            }

            else if (field.GetValue(sourceObject) != null && field.GetValue(destinationObject) != null)
            {
                // Falls beide Felder informationen enthalten -> zusammenführen versuchen
                var mergedInformation = MergeObjects(field.GetValue(destinationObject), field.GetValue(sourceObject));
                field.SetValue(destinationObject, mergedInformation);
            }
        }


        /// <summary>
        /// Kombiniert alle in Properties enthaltenen Informationen der Objekte, falls diese im verlangten Datentypen existieren
        /// Info: Diese Methode muss nicht benutzt werden, da die Felder bereits durch MergeObjectFields übertragen werden !
        /// Achtung !!! Falls diese Methode benutzt wird, kann es sein, dass Objekte zwei mal gemerged werden. Dies für vorallem bei IEnumerables zu problemen.
        /// How to speed up: http://www.codeproject.com/Articles/584720/ExpressionplusbasedplusPropertyplusGettersplusandp
        /// </summary>
        /// <param name="destinationObject"></param>
        /// <param name="sourceObject"></param>
        /// todo: rausschmeissen dieser Methode
        /// <returns></returns>
        private static T MergeObjectProperties<T>(T destinationObject, object sourceObject)
        {
            var sourceObjectType = sourceObject.GetType();
            var destinationObjectType = destinationObject.GetType();
            var commonType = destinationObjectType.FindEqualTypeWith(sourceObjectType);

            var properties = commonType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic |
                                                      BindingFlags.Instance)
                //.Where(f => f.GetCustomAttribute<CompilerGeneratedAttribute>() != null) // Only auto-properties
                .Where(prop => prop.CanWrite && prop.CanRead).AsParallel().AsUnordered();

            foreach (var propertyInfo in properties)
            {
                SetPropertyValue(destinationObject, sourceObject, propertyInfo);
            }

            //Parallel.ForEach(properties, (property) => 
            //{
            //});
            return destinationObject;
        }

        /// <summary>
        /// Legt <paramref name="property"/> in <paramref name="destinationObject"/> auf den Wert von <paramref name="sourceObject"/>
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="destinationObject"></param>
        /// <param name="sourceObject"></param>
        /// <param name="property"></param>
        private static void SetPropertyValue<T1>(T1 destinationObject, object sourceObject, PropertyInfo property)
        {
            try
            {
                if (property.EvaluateAttribute<IgnoreAtMerging>(IgnoreAtMerging.DefaultValue))
                    // If true This property is ignored
                {
                    return;
                }

                if (!property.EvaluateAttribute<IsMergeable>(IsMergeable.DefaultValue))
                    //!AttributeEvaluator.IsMergeable(Attribute.GetCustomAttributes(property)))
                {
                    property.SetValue(destinationObject, property.GetValue(sourceObject, null), null);
                }

                // Falls die Property im Ziel nicht initialisiert ist -> kopieren
                else if (property.GetValue(destinationObject) == null) // Irgendein ISKills lässt das hier abstürzen
                {
                    property.SetValue(destinationObject, property.GetValue(sourceObject, null), null);
                }
                // Falls beide Properties informationen enthalten -> zusammenführen versuchen
                else if (property.GetValue(sourceObject) != null && property.GetValue(destinationObject) != null)
                {
                    var initialValue = property.GetValue(destinationObject);
                    var mergedInformation = MergeObjects(initialValue, property.GetValue(sourceObject));

                    if (!initialValue.Equals(mergedInformation)) // Only set if value is new
                    {
                        property.SetValue(destinationObject, mergedInformation, null);
                    }
                }
            }
            catch (TargetInvocationException e)
            {
                Debug.WriteLine(e);
            }
            catch (TargetParameterCountException e)
            {
                Debug.WriteLine(e);
            }
            catch (Exception exception)
            {
                ObjectMergerLogger.GetInstance().Error(exception);
            }
        }
    }
}