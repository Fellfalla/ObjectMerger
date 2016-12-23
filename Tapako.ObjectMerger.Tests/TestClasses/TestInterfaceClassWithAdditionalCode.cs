// ReSharper disable InconsistentNaming
namespace Tapako.TestClasses
{
    public class TestInterfaceClassWithAdditionalCode : ITestInterface
    {
        public int InterfaceProperty { get; set; }

        public string newPublicProperty { get; set; }
        internal string newInternalProperty { get; set; }
        private string newPrivateProperty { get; set; }

        public string NewPublicField;
        internal string NewInternalField;
        private string newPrivateField;

        public TestInterfaceClassWithAdditionalCode()
        {
            newPrivateField = "private Field";
        }

        public TestInterfaceClassWithAdditionalCode(string newPrivateField)
        {
            this.newPrivateField = newPrivateField;
        }

        public void DoNothing()
        {
            DoNothingBehindNothing();
        }

        private void DoNothingBehindNothing()
        {
            return;
        }
    }
}
