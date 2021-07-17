using System;

namespace ValidationAttributesAndService.Attributes
{
    /// <summary>
    /// Base attribute that describe validation behavior of a marked properties.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class BaseValidationAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the failure message that raising when validation failed.
        /// </summary>
        /// <value>
        /// The failure message value.
        /// </value>
        public string FailureMessage { get; set; } = "An error occurred during the validation";

        /// <summary>
        /// Validates the specified object for compliance a certain condition.
        /// </summary>
        /// <param name="obj">The object of validation.</param>
        /// <returns><c>True</c> if validation passed successful, otherwise <c>false</c>.</returns>
        public abstract bool Validate(object obj);
    }
}
