using System;
using Tapako.ObjectMerger.Attributes;

namespace Tapako.ObjectMergerTests.TestClasses
{
    public class ClassWithMembers<T>
    {
        public ClassWithMembers()
        {
            try
            {
                InstanciatedProperty = Activator.CreateInstance<T>();
                InstanciatedField = Activator.CreateInstance<T>();
                MemberInstancesWereAutoCreated = true;
            }
            catch (Exception)
            {
                MemberInstancesWereAutoCreated = false;
            }
        }

        public ClassWithMembers(T fieldInstance = default(T), T propertyInstance = default(T))
        {
            MemberInstancesWereAutoCreated = false;
            InstanciatedField = fieldInstance;
            InstanciatedProperty = propertyInstance;
        }

        public readonly bool MemberInstancesWereAutoCreated;

        public T InstanciatedProperty { get; set; }
        public T InstanciatedField;
        public T Property { get; set; }
        public T Field;
    }
    public class ClassWithUnmergeableMembers<T>
    {
        public ClassWithUnmergeableMembers()
        {
            try
            {
                InstanciatedProperty = Activator.CreateInstance<T>();
                InstanciatedField = Activator.CreateInstance<T>();
                MemberInstancesWereAutoCreated = true;
            }
            catch (Exception)
            {
                MemberInstancesWereAutoCreated = false;
            }
        }
        public ClassWithUnmergeableMembers(T fieldInstance = default(T), T propertyInstance = default(T))
        {
            MemberInstancesWereAutoCreated = false;
            InstanciatedField = fieldInstance;
            InstanciatedProperty = propertyInstance;
        }

        public readonly bool MemberInstancesWereAutoCreated;

        [IsMergeable(false)]
        public T InstanciatedProperty { get; set; }

        [IsMergeable(false)]
        public T InstanciatedField;

        [IsMergeable(false)]
        public T Property { get; set; }

        [IsMergeable(false)]
        public T Field;
    }

    public class ClassWithMergeableMembers<T>
    {
        public ClassWithMergeableMembers()
        {
            try
            {
                InstanciatedProperty = Activator.CreateInstance<T>();
                InstanciatedField = Activator.CreateInstance<T>();
                MemberInstancesWereAutoCreated = true;
            }
            catch (Exception)
            {
                MemberInstancesWereAutoCreated = false;
            }
        }

        public ClassWithMergeableMembers(T fieldInstance = default(T), T propertyInstance = default(T))
        {
            MemberInstancesWereAutoCreated = false;
            InstanciatedField = fieldInstance;
            InstanciatedProperty = propertyInstance;
        }

        public readonly bool MemberInstancesWereAutoCreated;

        [IsMergeable(true)]
        public T InstanciatedProperty { get; set; }

        [IsMergeable(true)]
        public T InstanciatedField;

        [IsMergeable(true)]
        public T Property { get; set; }

        [IsMergeable(true)]
        public T Field;
    }
}
