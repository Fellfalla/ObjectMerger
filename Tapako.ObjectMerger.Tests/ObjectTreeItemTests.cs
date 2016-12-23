using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tapako.ObjectMerger;
using Tapako.ObjectMergerTests.ExtensionMethods;
using Tapako.ObjectMergerTests.TestClasses;
using Tapako.TestClasses;

namespace Tapako.ObjectMergerTests
{
    [TestClass]
    public class ObjectTreeItemTests
    {
        [TestMethod]
        public void CreateTreeProperly()
        {
            var first = new ClassWithRecursion();
            first.Name = "First";
            var second = new ClassWithRecursion();
            second.Name = "Second";

            first.Subclass = second;

            var sourceTree = new ObjectTreeItem(first);
            sourceTree.CreateTree();
            Trace.WriteLine(sourceTree.ToFormattedString());
            Assert.IsNull(sourceTree.Parent);
            Assert.IsNotNull(sourceTree.Childs);

            Assert.IsTrue(IEnumerableExtensions.Any(sourceTree.Childs));
            Assert.AreEqual(2, sourceTree.Childs.Count);

            Assert.AreEqual(first, sourceTree.Item);
            Assert.IsTrue(sourceTree.Childs.Any(item => item.Item == second));

            foreach (var objectTreeItem in sourceTree.Childs)
            {
                Assert.AreEqual(sourceTree, objectTreeItem.Parent);
            }
        }

        [TestMethod]
        //  [ExpectedException(typeof(AssertFailedException))]
        public void TreeContainsCorrectRecuriveTreeItems()
        {
            var first = new ExtendedClassWithRecursion();
            first.Name = "first";
            var second = new ExtendedClassWithRecursion();
            second.Name = "second";
            var third = new ClassWithRecursion();
            third.Name = "third";


            first.Subclass = second;
            second.Subclass = first;
            first.AnotherSubclass = third;
            third.Subclass = second;

            var sourceTree = new ObjectTreeItem(first);
            sourceTree.CreateTree();
            Trace.WriteLine(string.Join("\n", sourceTree.RecursionObjectTreeItems.Select(item => item.Parent.Item)));

            Assert.AreEqual(2, sourceTree.RecursionObjectTreeItems.Count);
            Assert.IsTrue(sourceTree.RecursionObjectTreeItems.Any(item => item.Parent.Item == second));
            Assert.IsFalse(sourceTree.RecursionObjectTreeItems.Any(item => item.Parent.Item == first));
            Assert.IsFalse(sourceTree.RecursionObjectTreeItems.Any(item => item.Parent.Item == third));

        }

        [TestMethod]
        //  [ExpectedException(typeof(AssertFailedException))]
        public void SelfReferencingObjectIsProperlyCreated()
        {
            var first = new ClassWithRecursion();
            first.Name = "first";

            first.Subclass = first;

            var sourceTree = new ObjectTreeItem(first);
            sourceTree.CreateTree();
            Trace.WriteLine(sourceTree.ToFormattedString());

            Assert.AreEqual(1, sourceTree.RecursionObjectTreeItems.Count);
            Assert.IsTrue(sourceTree.RecursionObjectTreeItems.Any(item => item.Parent.Item == first));
            Assert.AreSame(sourceTree.Item, sourceTree.Childs.First(item => item.Item == sourceTree.Item).Item);
        }

        [TestMethod]
        public void TreeCanHandleGuid()
        {
            var instance = new ClassWithMembers<Guid>(new Guid(), new Guid());

            var treeItem = new ObjectTreeItem(instance);

            treeItem.CreateTree();

            Trace.WriteLine(treeItem.ToFormattedString());
        }


        [TestMethod]
        public void TreeCanHandleGuidArray()
        {
            var instance = new ClassWithMembers<Guid[]>(new Guid[] {new Guid(), new Guid()}, new Guid[] { new Guid(), new Guid()});

            var treeItem = new ObjectTreeItem(instance);

            treeItem.CreateTree();

            Trace.WriteLine(treeItem.ToFormattedString());
        }

        [TestMethod]
        public void TreeCanHandlePrimitiveArrays()
        {
            BuildArrayTree("test1", "test2");
            BuildArrayTree("");
            BuildArrayTree<string>();
            BuildArrayTree(1,2,3,4,5);
            BuildArrayTree(1.1,.15,5.15);
        }

        [TestMethod]
        public void TreeCanHandleObjectArrays()
        {
            BuildArrayTree(new object(), new object(), new object());
        }

        [TestMethod]
        public void TreeCanHandleStructArrays()
        {
            BuildArrayTree(new Struct1(), new Struct1(1,2,3,"1","2","3", new object(), null, null));
        }

        private void BuildArrayTree<T>(params T[] arrayElements)
        {
            var instance = new ClassWithMembers<T[]>(arrayElements.ToArray(), arrayElements.ToArray());
            var treeItem = new ObjectTreeItem(instance);

            treeItem.CreateTree();

            Trace.WriteLine(treeItem.ToFormattedString());
        }

        private void BuildListTree<T>(params T[] arrayElements)
        {
            var instance = new ClassWithMembers<List<T>>(arrayElements.ToList(), arrayElements.ToList());
            var treeItem = new ObjectTreeItem(instance);

            treeItem.CreateTree();

            Trace.WriteLine(treeItem.ToFormattedString());
        }


        [TestMethod]
        public void TreeCanHandleList()
        {
            var instance = new ClassWithMembers<List<string>>(new List<string>() { "test1", "test2" }, new List<string>());

            var treeItem = new ObjectTreeItem(instance);

            treeItem.CreateTree();

            Trace.WriteLine(treeItem.ToFormattedString());
        }


        delegate void Del(string str);

        [TestMethod]
        public void TreeCanHandleDelegates()
        {
            Del del = delegate (string name)
                { Console.WriteLine("Notification received for: {0}", name); };
            var instance = new ClassWithMembers<Delegate>(del);

            var treeItem = new ObjectTreeItem(instance);

            treeItem.CreateTree();

            Trace.WriteLine(treeItem.ToFormattedString());
        }

        [TestMethod]
        public void TreeCanHandleActions()
        {
            TestObjectTreeCreation<Action>(() => { }, () => { });
            TestObjectTreeCreation<Action<string>>((string a) => { }, (string a) => { });
        }

        [TestMethod]
        public void TreeCanHandleAssembly()
        {
            TestObjectTreeCreation(GetType().Assembly, GetType().Assembly);
        }

        private void TestObjectTreeCreation<T>(T property, T field)
        {
            var instance = new ClassWithMembers<T>(field, property);

            var treeItem = new ObjectTreeItem(instance);

            treeItem.CreateTree();

            Trace.WriteLine(treeItem.ToFormattedString());
        }

        [TestMethod]
        public void TreeCanHandleFunctions()
        {
            var instance1 = new ClassWithMembers<Func<string, int>>(s => 5);
            var instance2 = new ClassWithMembers<Func<string>>(() => "test", () => "test");
            var instance3 = new ClassWithMembers<Func<string>>(() => "test", () => "test");

            var treeItem1 = new ObjectTreeItem(instance1);
            var treeItem2 = new ObjectTreeItem(instance2);
            var treeItem3 = new ObjectTreeItem(instance3);

            treeItem1.CreateTree();
            treeItem2.CreateTree();
            treeItem3.CreateTree();

            Trace.WriteLine(treeItem1.ToFormattedString());
            Trace.WriteLine(treeItem2.ToFormattedString());
            Trace.WriteLine(treeItem3.ToFormattedString());
        }

        [TestMethod]
        public void TreeCanHandleIpAddress()
        {
            var instance = new ClassWithMembers<IPAddress>(new IPAddress(19216811), new IPAddress(19216811));

            var treeItem = new ObjectTreeItem(instance);

            treeItem.CreateTree();

            Trace.WriteLine(treeItem.ToFormattedString());
        }

        [TestMethod]
        public void TreeCanHandleIpAddressArray()
        {
            BuildArrayTree(new IPAddress(19216811), new IPAddress(192168120));
        }
        [TestMethod]
        public void TreeCanHandleIpAddressList()
        {
            BuildListTree(new IPAddress(19216811), new IPAddress(192168120));
        }


        [TestMethod]
        public void TreeCanHandleOwnList()
        {
            var instance = new ClassWithMembers<OwnListClass>(new OwnListClass() { "test1", "test2" }, new OwnListClass());

            var treeItem = new ObjectTreeItem(instance);

            treeItem.CreateTree();

            Trace.WriteLine(treeItem.ToFormattedString());
        }


        [TestMethod]
        public void TreeCanHandleOwnGenericList()
        {
            var instance = new ClassWithMembers<OwnGenericListClass<string>>(new OwnGenericListClass<string>() { "test1", "test2" }, new OwnGenericListClass<string>());

            var treeItem = new ObjectTreeItem(instance);

            treeItem.CreateTree();

            Trace.WriteLine(treeItem.ToFormattedString());
        }

        private IEnumerable<string> CreateString()
        {
            for (int i = 0; i < 4; i++)
            {
                yield return string.Concat(Enumerable.Repeat("string",i));
            }
        }

        [TestMethod]
        public void TreeCanHandleEnumberable()
        {
  
            var action = new Func<IEnumerable<string>>(CreateString);

            var instance = new ClassWithMembers<IEnumerable<string>>(action.Invoke(), new List<string>());

            var treeItem = new ObjectTreeItem(instance);

            treeItem.CreateTree();

            Trace.WriteLine(treeItem.ToFormattedString());
        }

        [TestMethod]
        public void RecursiveItemsAreOnlyRecursiveItemsTest()
        {
            var first = new ExtendedClassWithRecursion();
            first.Name = "first";
            var second = new ExtendedClassWithRecursion();
            second.Name = "second";
            var third = new ClassWithRecursion();
            third.Name = "third";

            first.Subclass = second;
            second.Subclass = first;
            first.AnotherSubclass = third;
            third.Subclass = second;

            var sourceTree = new ObjectTreeItem(first);
            sourceTree.CreateTree();

            foreach (var recursiveSourceTreeItem in sourceTree.RecursionObjectTreeItems)
            {
               
                //if (!ReferenceEquals(recursiveSourceTreeItem.Parent.Item, first))
                if (recursiveSourceTreeItem.Item != first)
                {
                    // Tree contains errors, if recursive tree items does not contain root as any of their child
                    Trace.TraceInformation(sourceTree.ToFormattedString());
                    throw new Exception("<<<< BUG IN OBJECT TREE>>>>>\n" +
                                        "In: \"" + recursiveSourceTreeItem.Item + "\"\n" +
                                        "Expected Item: \"" + first + "\"\n" +
                                        "Actual Items: \"" + recursiveSourceTreeItem.ToFormattedString());
                }
           

            }
        }

        [TestMethod]
      //  [ExpectedException(typeof(AssertFailedException))]
        public void ToFormattedStringTest()
        {
            var first = new ExtendedClassWithRecursion();
            first.Name = "first";
            var second = new ExtendedClassWithRecursion();
            second.Name = "second";
            var third = new ClassWithRecursion();
            third.Name = "third";


            first.Subclass = second;
            second.Subclass = first;
            first.AnotherSubclass = third;
            third.Subclass = second;

            var sourceTree = new ObjectTreeItem(first);
            sourceTree.CreateTree();
            Trace.WriteLine(sourceTree.ToFormattedString());
        }


    }
}
