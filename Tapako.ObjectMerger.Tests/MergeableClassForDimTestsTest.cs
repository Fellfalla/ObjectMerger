using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tapako.TestClasses;

namespace Tapako.ObjectMergerTests
{
    [TestClass]
    public class MergeableClassForDimTestsTest
    {
        [TestMethod]
        public void EqualsWorksWithInitializedClasses()
        {
            MergeableClassForDimTests class1 = new MergeableClassForDimTests(1);
            MergeableClassForDimTests class2 = new MergeableClassForDimTests(1);

            Assert.IsTrue(class1.Equals(class2));
            Assert.AreEqual(class1, class2);
        }

        [TestMethod]
        public void EqualsWorksUninitializedClasses()
        {
            MergeableClassForDimTests class1 = new MergeableClassForDimTests();
            MergeableClassForDimTests class2 = new MergeableClassForDimTests();

            Assert.IsTrue(class1.Equals(class2));
            Assert.AreEqual(class1, class2);
        }

        [TestMethod]
        public void EqualsIsFalseWithDifferentClasses()
        {
            MergeableClassForDimTests class1 = new MergeableClassForDimTests(1);
            MergeableClassForDimTests class2 = new MergeableClassForDimTests(2);

            Assert.AreNotEqual(class1, class2);
        }


    }
}
