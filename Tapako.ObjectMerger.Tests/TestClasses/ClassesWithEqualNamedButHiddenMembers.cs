namespace Tapako.TestClasses
{
    public interface IEqualNamedAndHiddenMembersClass
    {
        int PropertyToCopy { get; set; }
    }

    public class ClassWithEqualNamedButHiddenMembersA : IEqualNamedAndHiddenMembersClass
    {
        public ClassWithEqualNamedButHiddenMembersA()
        {
            
        }

        public ClassWithEqualNamedButHiddenMembersA(int numberForProperty, int numberForField)
        {
            PropertyNotToCopyPrivate = numberForProperty;
            FieldNotToCopyPrivate = numberForField;
        }
        private int PropertyNotToCopyPrivate { get; set; }
        private int FieldNotToCopyPrivate { get; set; }        
        public int PropertyNotToCopyPublic { get; set; }
        public int FieldNotToCopyPublic { get; set; }

        public int PropertyToCopy { get; set; }
    }
    public class ClassWithEqualNamedButHiddenMembersB : IEqualNamedAndHiddenMembersClass
    {
        public ClassWithEqualNamedButHiddenMembersB()
        {
            
        }

        public ClassWithEqualNamedButHiddenMembersB(int numberForProperty, int numberForField)
        {
            PropertyNotToCopyPrivate = numberForProperty;
            FieldNotToCopyPrivate = numberForField;
        }
        private int PropertyNotToCopyPrivate { get; set; }
        private int FieldNotToCopyPrivate { get; set; }        
        public int PropertyNotToCopyPublic { get; set; }
        public int FieldNotToCopyPublic { get; set; }

        public int PropertyToCopy { get; set; }
    }
}
