using Tapako.ObjectMerger.Attributes;

namespace Tapako.TestClasses
{
    public class ClassWithIsNotMergeableSubClass
    {
        public NotMergeableSubClass NotMergeableSubClass;
        
        public ClassWithIsNotMergeableSubClass(NotMergeableSubClass notMergeableSubClass)
        {
            NotMergeableSubClass = notMergeableSubClass;
        }
    }

    [IsMergeable(false)]
    public class NotMergeableSubClass
    {
        
    }
}
