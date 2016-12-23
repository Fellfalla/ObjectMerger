using Tapako.ObjectMerger.Attributes;

namespace Tapako.TestClasses
{
    public class ClassWithIsNotMergeableProperty
    {
        [IsMergeable(false)]
        public int[] NotMergableArray { get; set; }

        public ClassWithIsNotMergeableProperty(int[] notMergeableArray, int[] mergeableArray)
        {
            NotMergableArray = notMergeableArray;
        }
    }
}
