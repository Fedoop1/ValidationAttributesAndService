using System;
using System.Linq;
using System.Reflection;

namespace ValidationAttributesAndService.Attributes
{
    /// <summary>
    /// Attribute than define and validate range of allowable values to a some marked property.
    /// </summary>
    /// <seealso cref="ValidationAttributesAndService.Attributes.BaseValidationAttribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public class RangeValidationAttribute : BaseValidationAttribute
    {
        private readonly int lowerValidBound;
        private readonly int upperValidBound;

        /// <summary>
        /// Initializes a new instance of the <see cref="RangeValidationAttribute"/> class and set the bound to lower and upper bound values.
        /// </summary>
        /// <param name="lowerValidationBound">The lower validation bound.</param>
        /// <param name="upperValidationBound">The upper validation bound.</param>
        public RangeValidationAttribute(int lowerValidationBound, int upperValidationBound) => (this.lowerValidBound, this.upperValidBound) = (lowerValidationBound, upperValidationBound);

        /// <summary>
        /// Validates the specified object for compliance a lower and upper bounds condition.
        /// </summary>
        /// <param name="obj">The object of validation.</param>
        /// <returns>
        /// <c>True</c> if validation passed successful, otherwise <c>false</c>.
        /// </returns>
        public override bool Validate(object obj)
        {
            if (obj != null && obj is int value && value >= this.lowerValidBound && value <= this.upperValidBound)
            {
                return true;
            }

            return false;
        }
    }
}
