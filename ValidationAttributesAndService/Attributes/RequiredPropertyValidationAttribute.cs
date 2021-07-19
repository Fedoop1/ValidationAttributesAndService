using System;
using System.Linq;

namespace ValidationAttributesAndService.Attributes
{
    /// <summary>
    /// Attribute than define and validate whether a value assigned to a some marked property.
    /// </summary>
    /// <seealso cref="BaseValidationAttribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredPropertyValidationAttribute : BaseValidationAttribute
    {
        /// <summary>
        /// Validates the specified object for assigned value condition.
        /// </summary>
        /// <param name="obj">The object of validation.</param>
        /// <returns>
        /// <c>True</c> if validation passed successful, otherwise <c>false</c>.
        /// </returns>
        public override bool Validate(object obj) => obj is not null;
    }
}
