using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tapako.TestClasses;

namespace Tapako.ObjectMergerTests
{
    [TestClass]
    public class UnmergableClassForDimTestsTest
    {
        [TestMethod]
        public void EqualsWorksWithInitializedClasses()
        {
            UnmergeableClassForDimTests class1 = new UnmergeableClassForDimTests(1);
            UnmergeableClassForDimTests class2 = new UnmergeableClassForDimTests(1);

            Assert.IsTrue(class1.Equals(class2));
            Assert.AreEqual(class1, class2);
        }

        [TestMethod]
        public void EqualsWorksUninitializedClasses()
        {
            UnmergeableClassForDimTests class1 = new UnmergeableClassForDimTests();
            UnmergeableClassForDimTests class2 = new UnmergeableClassForDimTests();

            Assert.IsTrue(class1.Equals(class2));
            Assert.AreEqual(class1, class2);
        }

        [TestMethod]
        public void EqualsIsFalseWithDifferentClasses()
        {
            UnmergeableClassForDimTests class1 = new UnmergeableClassForDimTests(1);
            UnmergeableClassForDimTests class2 = new UnmergeableClassForDimTests(2);

            Assert.AreNotEqual(class1, class2);
        }


    }
}
