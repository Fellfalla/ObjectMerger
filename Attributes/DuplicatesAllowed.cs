using System;

namespace Tapako.ObjectMerger.Attributes
{
    /// <summary>
    ///     This attribute shows, if the object applied to is allowed to exist duplicated in IEnumberables
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class DuplicatesAllowed : BoolAttributeBase
    {
        public DuplicatesAllowed(bool duplicatesAllowed) : base(duplicatesAllowed)
        {
        }

        /// <summary>
        ///     Default constructor for serialization
        /// </summary>
        public DuplicatesAllowed()
        {
        }

        public new static bool DefaultValue
        {
            get { return false; }
        }
    }
}