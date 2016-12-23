using Tapako.ObjectMerger.Attributes;

namespace Tapako.TestClasses
{
    public class ClassWithMergeableSubClass
    {
        public MergeableSubClass MergeableSubClass;
        
        public ClassWithMergeableSubClass(MergeableSubClass mergeableSubClass)
        {
            MergeableSubClass = mergeableSubClass;
        }
    }

    [IsMergeable(true)]
    public class MergeableSubClass
    {
        public MergeableSubClass(int value)
        {
            Value = value;
        }

        public int Value;
    }

    public interface IClassWithRecursion
    {
        IClassWithRecursion Subclass { get; }
    }

    [IsMergeable(true)]
    public class ClassWithRecursion : IClassWithRecursion
    {
        public ClassWithRecursion()
        {
            
        }

        public ClassWithRecursion(string name)
        {
            Name = name;
        }

        [IsMergeable(true)]
        public IClassWithRecursion Subclass { get; set; }

        public string Name = "ClassWithRecursion";

        public override string ToString()
        {
            return Name;
        }
    }

    [IsMergeable(true)]
    public class ExtendedClassWithRecursion : IClassWithRecursion
    {


        [IsMergeable(true)]
        public IClassWithRecursion Subclass { get; set; }

        [IsMergeable(true)]
        public IClassWithRecursion AnotherSubclass { get; set; }

        public string Name = "ExtendedClassWithRecursion";

        public override string ToString()
        {
            return Name;
        }
    }

    [IsMergeable(true)]
    public class ClassWithNotSettableRecursion : IClassWithRecursion
    {
        public ClassWithNotSettableRecursion(IClassWithRecursion subclass)
        {
            Subclass = subclass;
        }
        [IsMergeable(true)]
        public IClassWithRecursion Subclass { get; private set; }

        public string Name = "ClassWithNotSettableRecursion";

        public override string ToString()
        {
            return Name;
        }
    }
}
