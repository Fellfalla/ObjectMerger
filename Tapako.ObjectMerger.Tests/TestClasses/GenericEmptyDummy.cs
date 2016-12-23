namespace Tapako.TestClasses
{
    public class GenericEmptyDummy : GenericBaseClass<InputDummy, OutputDummy>
    {
        private string _name;
        private string _usid;

        public GenericEmptyDummy(IComponent context, string usid = "1", string name = "test") : base (context)
        {
            _usid = usid;
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public string USID
        {
            get { return _usid; }
        }

    }
}