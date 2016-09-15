using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Akomi.Logger;
using ExtensionMethodsCollection;

namespace Tapako.DeviceInformationManagement
{
    /// <summary>
    /// This item is used to create a hierarchy representation of a object hierarchy
    /// </summary>
    public class ObjectTreeItem
    {
        /// <summary>
        /// List of recursions pointing to <see cref="Item"/>
        /// </summary>
        public readonly List<ObjectTreeItem> RecursionObjectTreeItems = new List<ObjectTreeItem>();

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="item"></param>
        public ObjectTreeItem(object item)
        {
            Item = item;
        }

        /// <summary>
        /// This Methods is used to Generate the complete tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public ObjectTreeItem CreateTree(ObjectTreeItem root = null)
        {
            //if (treeItem == null)
            //{
            //    return null;
            //}

            if (root == null)
            {
                root = this;
            }

            foreach (var child in CreateChildLayer())
            {
                if (child == null)
                {
                    throw new NullReferenceException();
                }

                Childs.Add(child);

                if (ReferenceEquals(child.Item, root.Item))
                {
                    root.RecursionObjectTreeItems.Add(child);
                }
                else
                {
                    child.CreateTree(root);
                }

            }

            return root;
        }

        private IEnumerable<ObjectTreeItem> CreateChildLayer()
        {
            if (Item == null)
            {
                yield break;
            }
            else if (Item.GetType().IsPrimitive || Item is string)
            {
                yield break;
            }

            // Parse fields
            foreach (var fieldInfo in Item.GetType().GetFields())
            {
                var childValue = fieldInfo.GetValue(Item);

                var childTreeItem = new ObjectTreeItem(childValue);
                childTreeItem.Parent = this;
                childTreeItem.MemberInfo = fieldInfo;
                yield return childTreeItem;
            }

            // parse Properties
            foreach (var propertyInfo in Item.GetType().GetProperties().Where(info => info.CanRead))
            {
                object childValue = null;
                try
                {
                    childValue = propertyInfo.GetValue(Item);
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
                    Logger.Error(exception.ToString(true));
                }

                var childTreeItem = new ObjectTreeItem(childValue);
                childTreeItem.Parent = this;
                childTreeItem.MemberInfo = propertyInfo;
                yield return childTreeItem;
            }
        }

        /// <summary>
        /// The object this treeItem is contained in
        /// </summary>
        public ObjectTreeItem Parent;

        /// <summary>
        /// Information about the member in which <see cref="Item"/> is stored
        /// </summary>
        public MemberInfo MemberInfo;

        /// <summary>
        /// Objects this treeItem contains
        /// </summary>
        public List<ObjectTreeItem> Childs = new List<ObjectTreeItem>();

        /// <summary>
        /// The item this treeItem is represented by
        /// </summary>
        public readonly object Item;

        public override bool Equals(object obj)
        {
            if (obj is ObjectTreeItem)
            {
                return Item.Equals(((ObjectTreeItem) obj).Item);
            }
            else
            {
                return base.Equals(obj);
            }
            
        }

        public override int GetHashCode()
        {
            return Item.GetHashCode();
        }

        /// <summary>
        /// Create a formatted string to display the Object Tree.
        /// </summary>
        /// <param name="ident">number of tabs for current tree node</param>
        /// <param name="limit">maximal depth for tree visualization</param>
        /// <returns>string with tree elements idented by tabs</returns>
        public string ToFormattedString(int ident = 0, int limit = 10)
        {
            var builder = new StringBuilder();
            string browseName;
            string identation = "";

            // Create identation
            for (int i = 0; i < ident; i++)
            {
                builder.Append("\t");
            }

            // Add Prefix
            builder.Append(ident.ToString("0 "));

            // Add Item Name
            if (Item == null)
            {
                browseName = "Null";
            }
            else
            {
                if (MemberInfo != null)
                {
                    browseName = string.Format("{0} ({1}, {2})", Item, Item.GetType().Name, MemberInfo.MemberType);
                }
                else
                {
                    browseName = string.Format("{0} ({1})", Item, Item.GetType().Name);
                }
            }
            builder.AppendLine(browseName);

            // Add child tree
            foreach (var objectTreeItem in Childs)
            {
                if (ident < limit)
                {
                    builder.Append(objectTreeItem.ToFormattedString(ident + 1));
                }
                else
                {
                    builder.Append(identation);
                    builder.Append("\t");
                    builder.Append("...");
                }
            }
         

            return builder.ToString();
        }
    }
}