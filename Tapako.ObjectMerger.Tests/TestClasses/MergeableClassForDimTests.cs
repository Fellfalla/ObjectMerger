using System;

// ReSharper disable BaseObjectGetHashCodeCallInGetHashCode
// ReSharper disable BaseObjectEqualsIsObjectEquals

namespace Tapako.TestClasses
{
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
    public class MergeableClassForDimTests
    {
        private static int value1 = 1;
        private static int value2 = 2;


        #region Fields

        // private
        private int field1;
        private static int field3;

        // internal
        internal int field5;
        internal static int field7;


        // public
        public int field9;
        public static int field11;
        #endregion


        #region Properties


        // private
        private int Property1 { get; set; }
        public MergeableClassForDimTests PrivateRecursiveProperty { get; set; }


        // internal
        internal int Property4 { get; set; }

        internal int Property7 { private get; set; }
        internal int Property8 { get; private set; }
        public MergeableClassForDimTests InternalRecursiveProperty { get; set; }


        // public
        public int Property10 { get; set; }
        public int Property13 { private get; set; }
        public int Property14 { get; private set; }
        #endregion
        public MergeableClassForDimTests PublicRecursiveProperty { get; set; }


        public MergeableClassForDimTests()
        {
            
        }

        public MergeableClassForDimTests(int value)
        {
            //private
            field1 = value;
            field3 = value;

            //internal
            field5 = value;
            field7 = value;

            //public
            field9 = value;
            field11 = value;

            //private
            Property1 = value;

            //internal
            Property4 = value;
            Property7 = value;
            Property8 = value;

            //public
            Property10 = value;
            Property13 = value;
            Property14 = value;
        }

        /// <summary>
        /// Erstellt 3 neue Objekte mit den selben werten
        /// </summary>
        /// <param name="value"></param>
        public void SetPrivateRecursiveTestObject(int value )
        {
            Type t = typeof(MergeableClassForDimTests);
            PrivateRecursiveProperty = (MergeableClassForDimTests) Activator.CreateInstance(t, value);
            InternalRecursiveProperty = (MergeableClassForDimTests)Activator.CreateInstance(t, value);
            PublicRecursiveProperty = (MergeableClassForDimTests)Activator.CreateInstance(t, value);
        }

        public override bool Equals(object obj)
        {
            if (GetType() == obj.GetType())
            {
                return Equals(obj as MergeableClassForDimTests);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(MergeableClassForDimTests obj)
        {
            if (
                field1 == obj.field1 &&
                field5 == obj.field5 &&
                field9 == obj.field9 &&
                Property1 == obj.Property1 &&
                Property4 == obj.Property4 &&
                Property7 == obj.Property7 &&
                Property8 == obj.Property8 &&
                Property10 == obj.Property10 &&
                Property13 == obj.Property13 &&
                Property14 == obj.Property14
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(MergeableClassForDimTests obj, int staticValue)
        {
            // Es muss mit einem Extra wert getestet werden, ob die statischen Werte verändert wurden
            if (
                field1 == obj.field1 &&
                field3 == staticValue &&
                field7 == staticValue &&
                field9 == obj.field9 &&
                field11 == staticValue &&
                Property1 == obj.Property1 &&
                Property4 == obj.Property4 &&
                Property7 == obj.Property7 &&
                Property8 == obj.Property8 &&
                Property10 == obj.Property10 &&
                Property13 == obj.Property13 &&
                Property14 == obj.Property14
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
