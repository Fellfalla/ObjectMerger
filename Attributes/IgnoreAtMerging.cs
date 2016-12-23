using System;
using System.ComponentModel;

namespace Tapako.ObjectMerger.Attributes
{
    /// <summary>
    ///     This attribute inidcates, if the assigned Class can be merged.
    ///     The attributes value should be false, if the correlating class contains Methods, which are referenced by overridden
    ///     Methods of a inherited class or interface.
    ///     Methods can't be copied from one class to another.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class IgnoreAtMerging : BoolAttributeBase
    {
        public double Version = 1.0;

        public IgnoreAtMerging(bool isMergeable)
            : base(isMergeable)
        {
        }

        public IgnoreAtMerging()
        {
        }

        [DefaultValue(false)]
        public new static bool DefaultValue
        {
            get { return false; }
        }
    }
}