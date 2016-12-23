using System;

namespace Tapako.ObjectMerger.Attributes
{
    public abstract class BoolAttributeBase : Attribute
    {
        protected BoolAttributeBase(bool value)
        {
            Value = value;
        }

        public BoolAttributeBase()
        {
            Value = DefaultValue;
        }

        public bool Value { get; set; }

        /// <summary>
        ///     The Default value is given, if no attached Attribute will be found.
        ///     A value unequal to the default value will be returned, if just one value in a Attribute collection is unequal to
        ///     it.
        /// </summary>
        public static bool DefaultValue
        {
            get { return true; }
        }
    }
}