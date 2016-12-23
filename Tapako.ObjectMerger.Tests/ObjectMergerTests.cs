using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tapako.ObjectMerger;
using Tapako.TestClasses;

namespace Tapako.ObjectMergerTests
{
    [TestClass()]
    public class ObjectMergerTests
    {

        //private void AllFieldsAreEqual(IDevice expectedDevice, IDevice actualDevice)
        //{
        //    foreach (var field in typeof(IDevice).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
        //    {
        //        Assert.AreEqual(field.GetValue(expectedDevice), field.GetValue(actualDevice));

        //    }
        //}

        //private void AllPropertiesAreEqual(IDevice expectedDevice, IDevice actualDevice)
        //{
        //    foreach (var property in typeof(IDevice).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
        //    {
        //        Assert.AreEqual(property.GetValue(expectedDevice), property.GetValue(actualDevice));
        //    }
        //}

        //private IDevice CreateFirstNotEmptyIDevice()
        //{
        //    var notEmptyDevice = new TapakoDevice()
        //    {
        //        //DevicePath = "Testpfad",
        //        //DriverName = "lustiger Name",
        //        IpAddress = ("192.168.1.1"),
        //        MacAddress = ("000000000000"),
        //        Manufacturer = "der lustige Mann",

        //    };

        //    return notEmptyDevice;

        //}

        //[TestMethod]
        //public void MergeEmptyDevicesShallNotThrowError()
        //{
        //    var iDevice1 = new DeviceBase();
        //    var iDevice2 = new DeviceBase();

        //    ObjectMerger.ObjectMerger.MergeObjects(iDevice1, iDevice2);

        //    ObjectMerger.ObjectMerger.MergeObjects(iDevice2, iDevice1);
        //}

        //[TestMethod]
        //[Ignore]
        //public async Task MergeNotEmptyDevicesShallNotThrowException()
        //{
        //    var a = Task.Run(async () =>
        //    {
        //        for (int i = 0; i < 50; i++)
        //        {
        //            RandomExtension.RandomExtension.MaxRecursionDepth = 5;
        //            var iDevice1 =
        //                random.GetRandom<DeviceBase>(implementations:
        //                    new[] {typeof (SkillCheckPresenceDummy), typeof (SkillMoveCartDummy)});
        //            var iDevice2 =
        //                random.GetRandom<DeviceBase>(implementations:
        //                    new[] {typeof (SkillCheckPresenceDummy), typeof (SkillMoveCartDummy)});

        //            await ObjectMerger.ObjectMerger.AsyncMergeObjects(iDevice1, iDevice2);
        //        }
        //    });
        //    await a;
        //}

        //[TestMethod]
        //[Ignore]
        //public void MergeEmptyDevicesShallCreateNewEmptyDevice()
        //{
        //    var iDevice1 = new DeviceBase();
        //    var iDevice2 = new DeviceBase();

        //    var mergedDevice = ObjectMerger.ObjectMerger.MergeObjects(iDevice1, iDevice2);

        //    AllFieldsAreEqual(iDevice1, mergedDevice);
        //    AllPropertiesAreEqual(iDevice1, mergedDevice);

        //    AllFieldsAreEqual(iDevice2, mergedDevice);
        //    AllPropertiesAreEqual(iDevice2, mergedDevice);  // aktuelles Problem is noch, dass die Getter Method z.t. neue Instanzen erzeugen, wodurch nicht nur die Vorhandenen Sachen kopiert werden
        //}


        //[TestMethod]
        //[Ignore]
        //public void MergeDevicesShallReturnValidResult()
        //{
        //    var iDevice1 = new DeviceBase();
        //    var iDevice2 = new DeviceBase();

        //    var mergedDevice = ObjectMerger.ObjectMerger.MergeObjects(iDevice1, iDevice2);

        //    AllFieldsAreEqual(mergedDevice, iDevice1);
        //    AllPropertiesAreEqual(mergedDevice, iDevice2);
        //}


        //[TestMethod]
        //[Ignore]
        //public void MergeDeviceWithSkillsShallNotThrowError()
        //{
        //    var iDevice1 = new DeviceBase();
        //    var iDevice2 = new DeviceBase();
        //    iDevice1.Skills = new SkillList();
        //    iDevice2.Skills = new SkillList();

        //    var skill1 = new SkillCheckPresenceDummy(null, new object());
        //    var skill2 = new SkillMoveCartDummy();


        //    iDevice1.Skills.Add(skill1);
        //    iDevice2.Skills.Add(skill2);

        //    var mergedDevice = ObjectMerger.ObjectMerger.MergeObjects(iDevice1, iDevice2);

        //}

        //[TestMethod]
        //public void MergeDevicesWithIdenticalConnectionsShallContainNotMoreConnections()
        //{
        //    var iDevice1 = new DeviceBase();
        //    var iDevice2 = new DeviceBase();

        //    iDevice1.Connections = new ConnectionList()
        //    {
        //        new Connection() {Name = "abc"},
        //        new Connection() {Name = "bcd" }
        //    };

        //    iDevice2.Connections = new ConnectionList()
        //    {
        //        new Connection() {Name = "abc"},
        //        new Connection() {Name = "bcd" }
        //    };

        //    var mergedDevice = ObjectMerger.ObjectMerger.MergeObjects(iDevice1, iDevice2);

        //    Assert.AreEqual(mergedDevice, iDevice1);

        //}


        //[TestMethod]
        //[Ignore]
        //public void MergeDeviceWithSkillsToDeviceWithoutSkills()
        //{
        //    var iDevice1 = new DeviceBase();
        //    var iDevice2 = new DeviceBase();
        //    iDevice2.Skills = new SkillList();

        //    var skill1 = new SkillCheckPresenceDummy(null, new object());
        //    var skill2 = new SkillMoveCartDummy();


        //    iDevice2.Skills.Add(skill1);
        //    iDevice2.Skills.Add(skill2);

        //    var mergedDevice = ObjectMerger.ObjectMerger.MergeObjects(iDevice1, iDevice2);
        //    Assert.AreEqual(2, mergedDevice.Skills.Count());

        //}

        //[TestMethod]
        //[Ignore]
        //public void MergeDeviceBaseSkillsShallWork()
        //{
        //    var iDevice1 = new DeviceBase();
        //    var iDevice2 = new DeviceBase();
        //    iDevice1.Skills = new SkillList();
        //    iDevice2.Skills = new SkillList();

        //    var skill1 = new SkillCheckPresenceDummy(null, new object());
        //    var skill2 = new SkillMoveCartDummy();

        //    iDevice1.Skills.Add(skill1);
        //    iDevice2.Skills.Add(skill2);

        //    var mergedDevice = ObjectMerger.ObjectMerger.MergeObjects(iDevice1, iDevice2);

        //    Console.WriteLine(mergedDevice.Skills);
        //    Assert.IsTrue(mergedDevice.Skills.Contains(skill1));
        //    Assert.IsTrue(mergedDevice.Skills.Contains(skill2));
        //}

        //[TestMethod]
        //[Ignore]
        //public void MergeClassWithSkillsShallWork()
        //{
        //    var class1 = new ClassWithSkills();
        //    var class2 = new ClassWithSkills();

        //    var skill1 = new SkillCheckPresenceDummy(null, new object());
        //    var skill2 = new SkillMoveCartDummy();

        //    class1.Skills.Add(skill1);
        //    class2.Skills.Add(skill2);

        //    var mergedDevice = ObjectMerger.ObjectMerger.MergeObjects(class1, class2);

        //    Console.WriteLine("Skills: ");
        //    foreach (var skill in class1.Skills)
        //    {
        //        Console.WriteLine(skill);
        //    }

        //    Assert.IsTrue(mergedDevice.Skills.Contains(skill1));
        //    Assert.IsTrue(mergedDevice.Skills.Contains(skill2));
        //}

        //[TestMethod]
        //[Ignore]
        //public void MergeClassWithSkillsShallNotDuplicateSkillsWithDifferentInstances()
        //{
        //    var class1 = new ClassWithSkills();
        //    var class2 = new ClassWithSkills();

        //    var skill1 = new SkillMoveCartDummy();
        //    var skill2 = new SkillMoveCartDummy();

        //    class1.Skills.Add(skill1);
        //    class2.Skills.Add(skill2);

        //    var mergedDevice = ObjectMerger.ObjectMerger.MergeObjects(class1, class2);

        //    Console.WriteLine("Skills: ");
        //    foreach (var skill in class1.Skills)
        //    {
        //        Console.WriteLine(skill);
        //    }

        //    Assert.AreEqual(1, mergedDevice.Skills.Count());
        //}

        //[TestMethod]
        //[Ignore]
        //public void MergeClassWithSkillsShallNotDuplicateSkillsWithDifferentInstancesMultipleTimes()
        //{

        //    var class1 = new ClassWithSkills();
            
        //    var class2 = new ClassWithSkills();

        //    var skill1 = new SkillMoveCartDummy();
        //    var skill2 = new SkillMoveCartDummy();
        //    var skill3 = new GenericEmptyDummy(null) {CurrentSetupStep = new SetupStep { Name = "Test" } };
        //    var skill4 = new GenericEmptyDummy(null) {CurrentSetupStep = new SetupStep { Name = "Test" } };

        //    class1.Skills.Add(skill1);
        //    class1.Skills.Add(skill3);
        //    class1.Skills.Add(skill4);

        //    class2.Skills.Add(skill2);
        //    class2.Skills.Add(skill4);
        //    class2.Skills.Add(skill4);

        //    var mergedDevice = ObjectMerger.ObjectMerger.MergeObjects(class1, class2);
        //    var mergedDevice2 = ObjectMerger.ObjectMerger.MergeObjects(mergedDevice, class2);

        //    Console.WriteLine("Skills: ");
        //    foreach (var skill in mergedDevice2.Skills)
        //    {
        //        Console.WriteLine(skill);
        //    }

        //    Assert.AreEqual(2, mergedDevice2.Skills.Count());
        //}

        //[TestMethod]
        //[Ignore]
        //public void MergeHandlesStrategyContextRecursion()
        //{
        //    var class1 = new ClassWithSkills();

        //    var class2 = new ClassWithSkills();

        //    var skill1 = new SkillMoveCartDummy();
        //    var skill2 = new SkillMoveCartDummy(class2);
        //    var skill3 = new GenericEmptyDummy(class1) { CurrentSetupStep = new SetupStep { Name = "Test" } };
        //    var skill4 = new GenericEmptyDummy(null) { CurrentSetupStep = new SetupStep { Name = "Test" } };

        //    class1.Skills.Add(skill1);
        //    class1.Skills.Add(skill3);
        //    class1.Skills.Add(skill4);

        //    class2.Skills.Add(skill2);
        //    class2.Skills.Add(skill4);
        //    class2.Skills.Add(skill4);

        //    var mergedDevice1 = ObjectMerger.ObjectMerger.MergeObjects(class1, class2);
        //    var mergedDevice2 = ObjectMerger.ObjectMerger.MergeObjects(class2, class1);


        //    foreach (var skill in mergedDevice1.Skills)
        //    {
        //        Assert.AreEqual(mergedDevice1, skill.Context);
        //    }

        //    foreach (var skill in mergedDevice2.Skills)
        //    {
        //        Assert.AreEqual(mergedDevice2, skill.Context);
        //    }

        //    // Validate, that there was no error
        //    Assert.IsTrue(mergedDevice1.Skills.Any());
        //    Assert.IsTrue(mergedDevice2.Skills.Any());
        //    Assert.AreEqual(2, mergedDevice2.Skills.Count());
        //}

        private string ClassWithRecursionToString(IClassWithRecursion item, int ident = 0, int limit = 10)
        {
            var builder = new StringBuilder();
            string browseName;
            string identation = "";

            for (int i = 0; i < ident; i++)
            {
                builder.Append("\t");
                identation = builder.ToString();
            }
            builder.Append(ident.ToString("0 "));

            if (item == null)
            {
                browseName = "Null";
                builder.AppendLine(browseName);
                return builder.ToString();
            }
            else
            {
                browseName = string.Format("{0}", item);
                builder.AppendLine(browseName);
                if (ident < limit)
                {
                    builder.Append(ClassWithRecursionToString(item.Subclass, ident + 1));
                }
                else
                {
                    builder.Append(identation);
                    builder.Append("\t");
                    builder.Append("...");
                }
                return builder.ToString();

            }

        }

        [TestMethod]
        //[Timeout(3000)]
        public void MergerHandlesRecursion()
        {
            var class1 = new ClassWithRecursion();
            class1.Name = "class1";
            var class2 = new ClassWithRecursion();
            class2.Name = "class2";
            var class3 = new ClassWithRecursion();
            class3.Name = "class3";
            class1.Subclass = class2;
            class2.Subclass = class3;
            class3.Subclass = class1;

            var class4 = new ClassWithRecursion();
            class4.Name = "class4";
            var class5 = new ClassWithRecursion();
            class5.Name = "class5";
            var class6 = new ClassWithRecursion();
            class6.Name = "class6";
            class4.Subclass = class4;
            class5.Subclass = class5;
            class6.Subclass = class6;

            Trace.WriteLine(ClassWithRecursionToString(class1));

            var mergedClass1 = ObjectMerger.ObjectMerger.MergeObjects(class4, class1);
            Trace.WriteLine(ClassWithRecursionToString(mergedClass1));

            var mergedClass2 = ObjectMerger.ObjectMerger.MergeObjects(class4, class1);
            Trace.WriteLine(ClassWithRecursionToString(mergedClass2));

            //                              class1      class2      class3  class1
            Assert.AreEqual(mergedClass1, mergedClass1.Subclass.Subclass.Subclass);
            Assert.AreEqual(mergedClass2, mergedClass2.Subclass.Subclass.Subclass);
        }

        [TestMethod]
        [Timeout(4000)]
        public void MergerHandlesSelfReferencing()
        {
            var class1 = new ClassWithRecursion();
            class1.Name = "class1";
            class1.Subclass = class1;

            var class2 = new ClassWithRecursion();
            class2.Name = "class2";
            class2.Subclass = class2;

            var mergedClass = ObjectMerger.ObjectMerger.MergeObjects(class1, class2);

            Trace.WriteLine("Merged Class");
            Trace.WriteLine(ClassWithRecursionToString(mergedClass));

            Trace.WriteLine("Class1 after merge");
            Trace.WriteLine(ClassWithRecursionToString(class1));

            Trace.WriteLine("Class2 after merge");
            Trace.WriteLine(ClassWithRecursionToString(class1));

            Assert.AreSame(class1, class1.Subclass);
            Assert.AreSame(class2, class2.Subclass);
            Assert.AreSame(mergedClass, mergedClass.Subclass);
        }

        [TestMethod]
        public void RedirectionWorks()
        {
            var class1 = new ClassWithRecursion("class1");
            var class2 = new ClassWithRecursion("class2");
            var class3 = new ClassWithRecursion("class3");
            var class4 = new ClassWithRecursion("class4");
            class1.Subclass = class2;
            class2.Subclass = class3;
            class3.Subclass = class1;

            Trace.WriteLine(new ObjectTreeItem(class1).CreateTree().ToFormattedString());

            object redirection = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var redirections = ObjectMerger.ObjectMerger.RedirectRecursions(class1,redirection);
            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.AreEqual(redirection, class1.Subclass.Subclass.Subclass);

            redirection = class4;
            redirections = ObjectMerger.ObjectMerger.RedirectRecursions(redirections, redirection);
            Assert.AreEqual(redirection, class1.Subclass.Subclass.Subclass);

            redirection = class1;
            redirections = ObjectMerger.ObjectMerger.RedirectRecursions(redirections, redirection);
            Assert.AreEqual(redirection, class1.Subclass.Subclass.Subclass);
            Assert.AreEqual(class1, class3.Subclass);


        }

        [TestMethod]
        [ExpectedException(typeof(FieldAccessException))]
        [Ignore]
        public void MergerThrowsIfRecursionNotResolvable()
        {
            var class3 = new ClassWithRecursion();
            var class2 = new ClassWithNotSettableRecursion(class3);
            var class1 = new ClassWithNotSettableRecursion(class2);
            class3.Subclass = class1;

            var class6 = new ClassWithRecursion();
            var class5 = new ClassWithNotSettableRecursion(class6);
            var class4 = new ClassWithNotSettableRecursion(class5);
            class6.Subclass = class6;

            
            var mergedClass1 = ObjectMerger.ObjectMerger.MergeObjects(class1, class4);
            var mergedClass2 = ObjectMerger.ObjectMerger.MergeObjects(class4, class1);

            //                              class1      class2      class3  class1
            Assert.AreEqual(mergedClass1, mergedClass1.Subclass.Subclass.Subclass);
            Assert.AreEqual(mergedClass2, mergedClass2.Subclass.Subclass.Subclass);
        }

        //[TestMethod]
        //[Ignore]
        //public void MergeClassWithSkillsShallNotDuplicateSkills()
        //{
        //    var class1 = new ClassWithSkills();
        //    var class2 = new ClassWithSkills();

        //    var skill1 = new SkillMoveCartDummy();

        //    class1.Skills.Add(skill1);
        //    class2.Skills.Add(skill1);

        //    var mergedDevice = ObjectMerger.ObjectMerger.MergeObjects(class1, class2);

        //    Console.WriteLine("Skills: ");
        //    foreach (var skill in class1.Skills)
        //    {
        //        Console.WriteLine(skill);
        //    }

        //    Assert.AreEqual(1, mergedDevice.Skills.Count());
        //    Assert.AreSame(skill1, mergedDevice.Skills.First());
        //}

        [TestMethod]
        public void MergeEmptyUnmergeableClassShallNotThrowException()
        {
            var mergeClass1 = new UnmergeableClassForDimTests();
            var mergeClass2 = new UnmergeableClassForDimTests();

            ObjectMerger.ObjectMerger.MergeObjects(mergeClass1, mergeClass2);
        }

        /// todo: Wichtig hier ist das Testen von:
        /// - Arrays
        /// - Lists
        /// - Dictionaries
        /// - und allen anderen IEnumerable implementierenden Objekten
        [TestMethod]
        public void MergeMergeClassShallReturnValidResult()
        {
            var class1 = new MergeableClassForDimTests();
            var class2 = new MergeableClassForDimTests(1);
            var mergeControlClass = new MergeableClassForDimTests(1);
            var expectedMergeClass = new MergeableClassForDimTests(1);

            Assert.AreNotEqual(class1, class2);

            var mergedClass = ObjectMerger.ObjectMerger.MergeObjects(class1, class2);

            // Vorausgehender Test, damit sichergestellt ist, dass der Vergleich funtkioniert
            Assert.AreEqual(mergeControlClass, class2);
            Assert.IsTrue(mergeControlClass.Equals(class2, 1));

            Assert.AreEqual(expectedMergeClass, mergedClass);
        }

        [TestMethod]
        public void MergeObjectsShallNotChangeSourceObjects()
        {
            var mergeClass1 = new UnmergeableClassForDimTests();
            var mergeClass2 = new UnmergeableClassForDimTests(1);
            var expectedMergeClass = new UnmergeableClassForDimTests(1);

            var mergedClass = ObjectMerger.ObjectMerger.MergeObjects(mergeClass1, mergeClass2);

            Assert.AreEqual(expectedMergeClass, mergedClass);
            Assert.AreEqual(expectedMergeClass, mergeClass1); 

            Assert.AreEqual(expectedMergeClass, mergeClass2);
            Assert.AreNotSame(expectedMergeClass, mergeClass2); // mergeClass1 wird übergeben und sollte nicht verändert werden 
        }

        [TestMethod]
        public void MergeObjectsShallMergeLists()
        {
            var object1 = new List<int> { 1, 2, 3 };
            var object2 = new List<int> { 4, 5, 6 };

            var expectedMergeClass = new List<int> { 1, 2, 3, 4, 5, 6 }; ;

            List<int> mergedClass = ObjectMerger.ObjectMerger.MergeObjects(object1, object2);

            Assert.IsTrue(expectedMergeClass.SequenceEqual(mergedClass));
            Assert.IsFalse(object1.SequenceEqual(mergedClass));
            Assert.IsFalse(object2.SequenceEqual(mergedClass));
        }

        [TestMethod]
        [Timeout(500)]
        [Ignore]
        public void MergeObjectsShallMergeArrays()
        {
            var object1 = new int[] { 1, 2, 3 };
            var object2 = new int[] { 4, 5, 6 };

            var object3 = new string[] { "test1", "test2", "lamalamadingong" };
            var object4 = new string[] { "test1", "test1", "test2", "agrg", "tesag" };


            var expectedMergeClass1 = new int[] { 1, 2, 3, 4, 5, 6 }; ;
            var expectedMergeClass2 = new string[] { "test1", "test2", "lamalamadingong", "test1", "test1", "test2", "agrg", "tesag" }; ;

            int[] mergedClass1 = ObjectMerger.ObjectMerger.MergeObjects(object1, object2);
            string[] mergedClass2 = ObjectMerger.ObjectMerger.MergeObjects(object3, object4);

            Assert.IsTrue(expectedMergeClass1.SequenceEqual(mergedClass1), "Expected: [{0}] \nActual: [{1}]", string.Join(", ", expectedMergeClass1), string.Join(", ", mergedClass1));
            Assert.IsTrue(expectedMergeClass2.SequenceEqual(mergedClass2), "Eventuell wurden identische Strings nicht gemerged.\nExpected: [{0}] \nActual: [{1}]", string.Join(", ", expectedMergeClass2), string.Join(", ", mergedClass2)); // todo: hier werden identische Strings nicht kopiert, analysiere, ob das so sein soll oder nicht!!!
            Assert.IsFalse(object1.SequenceEqual(mergedClass1));
            Assert.IsFalse(object2.SequenceEqual(mergedClass1));
        }

        [TestMethod]
        public void MergeObjectsShallMergeDictionaries()
        {
            var dictionary1 = new Dictionary<string, int>()
            {
                { "testKey1" , 1},
                { "anotherTestKey1", 2 }
            };
            var dictionary2 = new Dictionary<string, int>()
            {
                { "testKey2" , 3},
                { "anotherTestKey2", 4 }
            };

            var expectedMergeClass = new Dictionary<string, int>()
            {
                { "testKey1" , 1},
                { "anotherTestKey1", 2 },
                { "testKey2" , 3},
                { "anotherTestKey2", 4 }
            };

            var mergedClass = ObjectMerger.ObjectMerger.MergeObjects(dictionary1, dictionary2);

            Assert.IsTrue(expectedMergeClass.SequenceEqual(mergedClass));
            Assert.IsFalse(dictionary1.SequenceEqual(mergedClass));
            Assert.IsFalse(dictionary2.SequenceEqual(mergedClass));
        }


        //[TestMethod]
        //public void MergeObjectsShallMergeComplexDictionaries()
        //{
        //    var address1 = new Address {Street = "Utzenbichl"};

        //    var address2 = new Address
        //    {
        //        City = "München",
        //        StreetNumber = "51b"
        //    };
        //    // München wegen "ü"

        //    var address3 = new Address
        //    {
        //        City = "München",
        //        Street = "Utzenbichl",
        //        StreetNumber = "51b"
        //    };

        //    var address4 = new Address();

        //    var dictionary1 = new Dictionary<object, object>()
        //    {
        //        { "address1" , address1},
        //        { "address2", address2 }
        //    };
        //    var dictionary2 = new Dictionary<object, object>()
        //    {
        //        { "address3" , address3},
        //        { "addres4", address4 }
        //    };

        //    var expectedMergeClass = new Dictionary<object, object>()
        //    {
        //        { "address1" , address1},
        //        { "address2", address2 },
        //        { "address3" , address3},
        //        { "addres4", address4 }
        //    };

        //    var mergedClass = ObjectMerger.ObjectMerger.MergeObjects(dictionary1, dictionary2);

        //    Assert.IsTrue(expectedMergeClass.SequenceEqual(mergedClass));
        //    Assert.IsFalse(dictionary1.SequenceEqual(mergedClass));
        //    Assert.IsFalse(dictionary2.SequenceEqual(mergedClass));
        //}


        [TestMethod]
        public void MergeObjectsOverrideString()
        {
            string string1 = "Hallo";
            string string2 = "Tester";

            var expectedMergeClass = "Tester";

            var mergedClass = ObjectMerger.ObjectMerger.MergeObjects(string1, string2);

            Assert.AreEqual(expectedMergeClass, mergedClass);
            Assert.IsFalse(string1.SequenceEqual(mergedClass));
            Assert.IsTrue(string2.SequenceEqual(mergedClass));
        }

        [TestMethod]
        public void MergeRekursiveObjectsShallNotThrowError()
        {
            var class1 = new MergeableClassForDimTests();
            class1.SetPrivateRecursiveTestObject(5);

            var class2 = new MergeableClassForDimTests(1);
            class2.SetPrivateRecursiveTestObject(3);

            var expectedMergeClass = new MergeableClassForDimTests(1);
            expectedMergeClass.SetPrivateRecursiveTestObject(3);

            // Teste ob das ohne absturz durchläuft
            ObjectMerger.ObjectMerger.MergeObjects(class1, class2);
        }

        [TestMethod]
        public void MergeRecursiveObjectsShallReturnValidResult()
        {
            var class1 = new MergeableClassForDimTests();
            class1.SetPrivateRecursiveTestObject(5);

            var class2 = new MergeableClassForDimTests(1);
            class2.SetPrivateRecursiveTestObject(3);

            var class2Controll = new MergeableClassForDimTests(1);
            class2Controll.SetPrivateRecursiveTestObject(3);

            var expectedMergeClass = new MergeableClassForDimTests(1);
            expectedMergeClass.SetPrivateRecursiveTestObject(3);

            Assert.AreNotEqual(class1, class2);

            var mergedClass = ObjectMerger.ObjectMerger.MergeObjects(class1, class2);

            // Vorausgehender Test, damit sichergestellt ist, dass der Vergleich funtkioniert
            Assert.AreEqual(class2Controll, class2);

            Assert.IsTrue(class2Controll.Equals(class2, 3));

            Assert.AreEqual(expectedMergeClass, mergedClass);

            Assert.IsNotNull(expectedMergeClass.PrivateRecursiveProperty);
            Assert.IsNotNull(expectedMergeClass.InternalRecursiveProperty);
            Assert.IsNotNull(expectedMergeClass.PublicRecursiveProperty);
            Assert.IsNotNull(mergedClass.PrivateRecursiveProperty);
            Assert.IsNotNull(mergedClass.InternalRecursiveProperty);
            Assert.IsNotNull(mergedClass.PublicRecursiveProperty);

            Assert.AreEqual(expectedMergeClass.PrivateRecursiveProperty, mergedClass.PrivateRecursiveProperty);
            Assert.AreEqual(expectedMergeClass.InternalRecursiveProperty, mergedClass.InternalRecursiveProperty);
            Assert.AreEqual(expectedMergeClass.PublicRecursiveProperty, mergedClass.PublicRecursiveProperty);
        }

        [TestMethod]
        public void MergeShouldNotCopyNewMembers()
        {
            var testInterfaceClass = new TestInterfaceClass();

            var testInterfaceClassWithAdditionalProperties = new TestInterfaceClassWithAdditionalCode();

            var mergedClass = ObjectMerger.ObjectMerger.MergeObjects(testInterfaceClass as ITestInterface,
                testInterfaceClassWithAdditionalProperties as ITestInterface);

            Assert.IsNull(mergedClass as TestInterfaceClassWithAdditionalCode);

        }

        [TestMethod]
        public void MergeShouldNotCorruptInterfaceFunction()
        {
            var testInterfaceClass = new TestInterfaceClass();

            var testInterfaceClassWithAdditionalProperties = new TestInterfaceClassWithAdditionalCode();

            var mergedClass = ObjectMerger.ObjectMerger.MergeObjects(testInterfaceClass as ITestInterface,
                testInterfaceClassWithAdditionalProperties as ITestInterface);

            mergedClass.DoNothing();
        }

        [TestMethod]
        public void MergerCannotHandleFunctionDelegates()
        {
            var a = new ActionClass();
            var b = new ActionClass();

            ActionClass ab = ObjectMerger.ObjectMerger.MergeObjects(a, b);
            a.Instance = "A";
            b.Instance = "B";

            Console.WriteLine(ab.Instance + " is referenced!");         // -> Referenz auf A
            ab.DoAction.Invoke();                   // -> Referenz auf B !!!
        }

        class ActionClass
        {
            public Action DoAction { get; set; }
            public string Instance { get; set; }

            void InternalActionA()
            {
                Console.WriteLine(Instance + " is referenced!");
            }

            public ActionClass()
            {
                DoAction = InternalActionA;
            }
        }

        [TestMethod]
        public void MergeDifferentClassesShallNotOverrideUncommonMembersWithSameName()
        {
            var a = new ClassWithEqualNamedButHiddenMembersA(1, 1);
            var b = new ClassWithEqualNamedButHiddenMembersB(2, 2);

            a.PropertyNotToCopyPublic = 1;
            a.FieldNotToCopyPublic = 1;
            a.PropertyToCopy = 1;

            b.PropertyNotToCopyPublic = 2;
            b.FieldNotToCopyPublic = 2;
            b.PropertyToCopy = 2;

            var result = ObjectMerger.ObjectMerger.MergeObjects((IEqualNamedAndHiddenMembersClass)a, b);
            var castedResult = (ClassWithEqualNamedButHiddenMembersA)result;

            Assert.AreEqual(2, result.PropertyToCopy);

            PrivateObject privateObject = new PrivateObject(result);
            Assert.AreEqual(1, privateObject.GetProperty("PropertyNotToCopyPrivate"));
            Assert.AreEqual(1, privateObject.GetProperty("FieldNotToCopyPrivate"));
            Assert.AreEqual(1, castedResult.FieldNotToCopyPublic);
            Assert.AreEqual(1, castedResult.PropertyNotToCopyPublic);

        }

        /// <summary>
        /// Weiß nicht o dieser Test so viel sinn macht, heraus kommt momentan der Type des Ersten Objektes
        /// Und das ist eigentlich auch gut, wenn dieser Test fehlschlägt
        /// </summary>
        [TestMethod]
        public void MergeDifferentClassesWithDatatypeParameterWorks()
        {
            var a = new ClassWithEqualNamedButHiddenMembersA(1, 2);
            var b = new ClassWithEqualNamedButHiddenMembersB(5, 6);

            a.PropertyNotToCopyPublic = 3;
            a.FieldNotToCopyPublic = 4;
            a.PropertyToCopy = 10;

            b.PropertyNotToCopyPublic = 7;
            b.FieldNotToCopyPublic = 8;
            b.PropertyToCopy = 20;

            IEqualNamedAndHiddenMembersClass result = ObjectMerger.ObjectMerger.MergeObjects(a, b);

            Assert.AreEqual(a.GetType(), result.GetType());
            Assert.AreNotEqual(b.GetType(), result.GetType());

        }

        /// <summary>
        /// Dies wird voraussichtlich nicht funktionieren, ich Verweise auf 
        /// http://stackoverflow.com/questions/32873004/passing-attributes-of-a-auto-implemented-property-to-its-field/32875227?noredirect=1#comment53583956_32875227
        /// </summary>
        [TestMethod]
        public void IsNotMergeablePropertiesShallBeCopiedAndNotMerged()
        {
            int[] notMergeableArray1 = new int[] { 1, 2, 3 };
            int[] mergeableArray1 = new int[] { 1, 2, 3 };
            int[] notMergeableArray2 = new int[] { 4, 5, 6 };
            int[] mergeableArray2 = new int[] { 4, 5, 6 };

            var a = new ClassWithIsNotMergeableProperty(notMergeableArray1, mergeableArray1);
            var b = new ClassWithIsNotMergeableProperty(notMergeableArray2, mergeableArray2);

            a = ObjectMerger.ObjectMerger.MergeObjects(a, b);

            Assert.AreEqual(notMergeableArray2, a.NotMergableArray);
        }

        [TestMethod]
        public void IsNotMergeableFieldsShallBeCopiedAndNotMerged()
        {
            int[] notMergeableArray1 = new int[] { 1, 2, 3 };
            int[] notMergeableArray2 = new int[] { 4, 5, 6 };

            var a = new ClassWithIsNotMergeableField(notMergeableArray1);
            var b = new ClassWithIsNotMergeableField(notMergeableArray2);

            a = ObjectMerger.ObjectMerger.MergeObjects(a, b);

            Assert.AreEqual(notMergeableArray2, a.NotMergableArray);
        }

        [TestMethod]
        [Ignore]
        public void IsNotMergeableClassesShallBeCopiedAndNotMerged()
        {
            NotMergeableSubClass subClass1 = new NotMergeableSubClass();
            NotMergeableSubClass subClass2 = new NotMergeableSubClass();

            var a = new ClassWithIsNotMergeableSubClass(subClass1);
            var b = new ClassWithIsNotMergeableSubClass(subClass2);

            a = ObjectMerger.ObjectMerger.MergeObjects(a, b);

            Assert.AreEqual(subClass2, a.NotMergeableSubClass);
            Assert.AreNotEqual(subClass1, a.NotMergeableSubClass);
        }

        [TestMethod]
        public void MergeableArrayPropertiesShallBeMerged()
        {
            int[] mergeableArray1 = new int[] { 1, 2, 3 };
            int[] mergeableArray2 = new int[] { 4, 5, 6, 7 };

            int[] arrayResult = new int[] { 1, 2, 3, 4, 5, 6, 7 };


            var a = new ClassWithMergeableProperty(mergeableArray1);
            var b = new ClassWithMergeableProperty(mergeableArray2);

            a = ObjectMerger.ObjectMerger.MergeObjects(a, b);


            Assert.IsTrue(arrayResult.SequenceEqual(a.MergeableProperty));
        }

        [TestMethod]
        public void MergeableArrayFieldsShallBeMerged()
        {
            int[] mergeableArray1 = new int[] { 1, 2, 3 };
            int[] mergeableArray2 = new int[] { 4, 5, 6, 7 };

            int[] arrayResult = new int[] { 1, 2, 3, 4, 5, 6, 7 };


            var a = new ClassWithMergeableField(mergeableArray1);
            var b = new ClassWithMergeableField(mergeableArray2);

            a = ObjectMerger.ObjectMerger.MergeObjects(a, b);

            Assert.IsTrue(arrayResult.SequenceEqual(a.MergableArray));
        }

        [TestMethod]
        public void MergeableClassesShallBeMerged()
        {
            int value1 = 1;
            int value2 = 2;

            MergeableSubClass subClass1 = new MergeableSubClass(value1);
            MergeableSubClass subClass2 = new MergeableSubClass(value2);

            var a = new ClassWithMergeableSubClass(subClass1);
            var b = new ClassWithMergeableSubClass(subClass2);

            a = ObjectMerger.ObjectMerger.MergeObjects(a, b);

            Assert.AreEqual(value2, a.MergeableSubClass.Value); // Der Wert aus Klasse 2 soll übernommen werden
            Assert.AreNotEqual(subClass2, a.MergeableSubClass); // Die neue Klasse soll nicht kopiert werden
        }


        //[TestMethod]
        //public void TwoDifferentIDevicesShallBeMerged()
        //{
        //    string testName = "TestName";
        //    string testModel = "testModel";


        //    DeviceBase dev1 = new DeviceBase();
        //    dev1.PresentationData = new PresentationData();
        //    dev1.Identification = new Identification();
        //    dev1.PresentationData.BrowseName = testName;
        //    var dev2 = new DeviceBase();
        //    dev2.Identification = new Identification();
        //    dev2.Identification.ModelNumber = testModel;

        //    IDevice result = ObjectMerger.ObjectMerger.MergeObjects(dev2, dev1);
        //    Assert.AreEqual(testName, result.GetBrowseName());
        //    Assert.AreEqual(testModel, result.Identification.ModelNumber);
        //}

        //[TestMethod]
        //[Ignore]
        //public void DeviceStrategysShallNotCopiedIfNotExisting_1()
        //{
        //    DeviceBase dev1 = new DeviceBase();
        //    DeviceBase dev2 = new DeviceBase();
        //    dev2.Skills.Add(new ConcreteTestStrategy(dev2));

        //    IDevice result = ObjectMerger.ObjectMerger.MergeObjects(dev2, dev1);

        //    //result.SearchForSubDevices.InputArguments[StrategyBase.ArgumentKeywords.ParentObject.ToString()] = result;
        //    //result.SearchForSubDevices.Execute();

        //    result.Skills.GetSkill<ConcreteTestStrategy>().Execute();

        //    Assert.AreEqual(ConcreteTestStrategy.BrowseNameResult, result.GetBrowseName());

        //}

        //[TestMethod]
        //[Ignore]
        //public void DeviceStrategysShallNotCopiedIfNotExisting_2()
        //{
        //    DeviceBase dev1 = new DeviceBase();
        //    DeviceBase dev2 = new DeviceBase();
        //    dev1.Skills.Add(new ConcreteTestStrategy(dev1));

        //    IDevice result = ObjectMerger.ObjectMerger.MergeObjects(dev2, dev1);

        //    //result.SearchForSubDevices.InputArguments[StrategyBase.ArgumentKeywords.ParentObject.ToString()] = result;
        //    //result.SearchForSubDevices.Execute();

        //    result.Skills.GetSkill<ConcreteTestStrategy>().Execute();

        //    Assert.AreEqual(ConcreteTestStrategy.BrowseNameResult, result.GetBrowseName());

        //}

        //[TestMethod]
        //[Ignore]
        //public void DeviceStrategysShallBeOverriddenAndNotMerged()
        //{
        //    DeviceBase dev1 = new DeviceBase();
        //    dev1.Skills.Add(new ConcreteTestStrategy(dev1));
        //    //dev1.SearchForSubDevices = new ConcreteTestStrategy();

        //    DeviceBase dev2 = new DeviceBase();
        //    dev2.Skills.Add(new ConcreteTestStrategy2(dev2));
        //    //dev2.SearchForSubDevices = new ConcreteTestStrategy2();
            
        //    IDevice result = ObjectMerger.ObjectMerger.MergeObjects(dev2, dev1);
        //    var searcher = result.Skills.GetSkills<SkillSearchForSubdevicesBase>().ToArray();

        //    Assert.AreEqual(2, searcher.Length);
        //    foreach (var skillSearchForSubdevicesBase in searcher)
        //    {
        //        skillSearchForSubdevicesBase.Execute();
        //    }

        //    //result.SearchForSubDevices.InputArguments[StrategyBase.ArgumentKeywords.ParentObject.ToString()] = result;
        //    //result.SearchForSubDevices.Execute();

        //    if (dev1.Identification != null)
        //    {
        //        Assert.AreNotEqual(ConcreteTestStrategy.BrowseNameResult, dev1.GetBrowseName(), "Die referenz auf dev 1 der Strategy wurde nicht auf eine referenz auf result geändert");
        //    }

        //    Assert.IsNotNull(result.Identification);
        //    Assert.AreEqual(ConcreteTestStrategy.BrowseNameResult, result.GetBrowseName());
        //}

    }

}