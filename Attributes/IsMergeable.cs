using System;

namespace Tapako.ObjectMerger.Attributes
{
    /// <summary>
    ///     This attribute inidcates, if the assigned Class can be merged.
    ///     The attributes value should be false, if the correlating class contains Methods, which are referenced by overridden
    ///     Methods of a inherited class or interface.
    ///     Methods can't be copied from one class to another.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property |AttributeTargets.Field| AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct)]
    public class IsMergeable : BoolAttributeBase
    {
        public double Version = 1.0;

        public IsMergeable(bool isMergeable) : base(isMergeable)
        {
        }

        public IsMergeable()
        {
        }

        public new static bool DefaultValue
        {
            get { return true; }
        }
    }
}