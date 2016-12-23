using Tapako.ObjectMerger.Attributes;

namespace Tapako.TestClasses
{
    public class ClassWithMergeableProperty
    {
        [IsMergeable(true)]
        public int[] MergeableProperty { get; set; }

        public ClassWithMergeableProperty(int[] mergeableProperty)
        {
            MergeableProperty = mergeableProperty;
        }
    }
}
