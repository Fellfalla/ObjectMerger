// ReSharper disable InconsistentNaming
namespace Tapako.TestClasses
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    /// <summary>
    /// Dies ist eine Klasse, mit der getestet werden kann, ob das Mergen der Klassen funktioniert.
    /// 
    /// Hierzu müssen einige Dinge getestet werden:
    /// - private setter
    /// - public setter
    /// - private getter
    /// - public getter
    /// - static fields
    /// - static properties
    /// - readonly
    /// - rekursionen (Objekte im objekt)
    /// </summary>
    public class UnmergeableClassForDimTests
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        private static int value1 = 1;
        private static int value2 = 2;


        #region Fields

        // private
        private int field1;
        private readonly int field2;
        private static int field3;
        private const int field4 = 1;

        // internal
        internal int field5;
        internal readonly int field6;
        internal static int field7;
        internal const int field8 = 1;


        // public
        public int field9;
        public readonly int field10;
        public static int field11;
        public const int field12 = 1;

        #endregion


        #region Properties
        private int _property2;
        private int _property5;
        private int _property11;

        // private
        private int Property1 { get; set; }

        private int Property2
        {
            set { _property2 = value; }
        }

        private int _property3;

        private int Property3
        {
            get { return _property3; }
        }


        // internal
        internal int Property4 { get; set; }

        internal int Property5
        {
            set { _property5 = value; }
        }

        private int _property6;
        internal int Property6 { get { return _property6; } }

        internal int Property7 { private get; set; }
        internal int Property8 { get; private set; }

        // public
        public int Property10 { get; set; }

        public int Property11
        {
            set { _property11 = value; }
        }

        private int _property12;
        public int Property12 { get { return _property12; } }

        public int Property13 { private get; set; }
        public int Property14 { get; private set; }
        #endregion

        public UnmergeableClassForDimTests RekursiveProperty { get; set; }


        public UnmergeableClassForDimTests()
        {
            
        }

        public UnmergeableClassForDimTests(int value)
        {
            field1 = value;
            field2 = value;
            field3 = value;
            // const field4 = value;
            field5 = value;
            field6 = value;
            field7 = value;
            // const field8 = value;
            field9 = value;
            field10 = value;
            field11 = value;
            // const field12 = value;


            Property1 = value;
            Property2 = value;
            _property3 = value;
            Property4 = value;
            Property5 = value;
            _property6 = value;
            Property7 = value;
            Property8 = value;
            Property10 = value;
            Property11 = value;
            _property12 = value;
            Property13 = value;
            Property14 = value;
        }

        public override bool Equals(object obj)
        {
            if (GetType() == obj.GetType())
            {
                return Equals(obj as UnmergeableClassForDimTests);
            }
            return base.Equals(obj);
        }

        public bool Equals(UnmergeableClassForDimTests obj)
        {
            if (
                field1 == obj.field1 &&
                field2 == obj.field2 &&
                field5 == obj.field5 &&
                field6 == obj.field6 &&
                field9 == obj.field9 &&
                field10 == obj.field10 &&
                Property1 == obj.Property1 &&
                _property2 == obj._property2 &&
                Property3 == obj.Property3 &&
                Property4 == obj.Property4 &&
                _property5 == obj._property5 &&
                Property6 == obj.Property6 &&
                Property7 == obj.Property7 &&
                Property8 == obj.Property8 &&
                Property10 == obj.Property10 &&
                _property11 == obj._property11 &&
                Property12 == obj.Property12 &&
                Property13 == obj.Property13 &&
                Property14 == obj.Property14 &&
                RekursiveProperty == obj.RekursiveProperty
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(UnmergeableClassForDimTests obj, int staticValue)
        {
            // Die const felder wurden ausgelassen, da diese klassenweit immer gleich sind
            // ebenso muss mit einem Extra wert getestet werden, ob die statischen werte verändert wurden
            if (
                field1 == obj.field1 &&
                field2 == obj.field2 &&
                field3 == staticValue &&
                field5 == obj.field5 &&
                field6 == obj.field6 &&
                field7 == staticValue &&
                field9 == obj.field9 &&
                field10 == obj.field10 &&
                field11 == staticValue &&
                Property1 == obj.Property1 &&
                _property2 == obj._property2 &&
                Property3 == obj.Property3 &&
                Property4 == obj.Property4 &&
                _property5 == obj._property5 &&
                Property6 == obj.Property6 &&
                Property7 == obj.Property7 &&
                Property8 == obj.Property8 &&
                Property10 == obj.Property10 &&
                _property11 == obj._property11 &&
                Property12 == obj.Property12 &&
                Property13 == obj.Property13 &&
                Property14 == obj.Property14 &&
                RekursiveProperty == obj.RekursiveProperty
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
