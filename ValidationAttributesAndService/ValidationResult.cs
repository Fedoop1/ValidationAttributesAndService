using System;
using System.Collections.Generic;
using ValidationAttributesAndService.Attributes;

namespace ValidationAttributesAndService
{
    /// <summary>
    /// Class "container" than store information about validation by <see cref="BaseValidationAttribute"/>.
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> class with all information about validation.
        /// </summary>
        /// <param name="obj">Object of validation.</param>
        /// <param name="isValid">If validation if successful <c>true</c>, otherwise <c>false</c>.</param>
        /// <param name="failureMessages">The failure messages collection.</param>
        /// <param name="invalidAttributes">The invalid attributes collection.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws when validation object is null
        /// or
        /// Throws when failure messages is null
        /// or
        /// Throws when invalid attributes is null.
        /// </exception>
        public ValidationResult(object obj, bool isValid, IEnumerable<string> failureMessages, IEnumerable<BaseValidationAttribute> invalidAttributes)
        {
            this.IsValid = isValid;
            this.ValidationObject = obj ?? throw new ArgumentNullException(nameof(obj), "Validation object can't be null");
            this.FailureMessages = failureMessages ?? throw new ArgumentNullException(nameof(failureMessages), "Failure messages can't be null");
            this.InvalidAttributes = invalidAttributes ?? throw new ArgumentNullException(nameof(invalidAttributes), "Invalid attributes can't be null");
        }

        /// <summary>
        /// Gets the validation object.
        /// </summary>
        /// <value>
        /// The validation object.
        /// </value>
        public object ValidationObject { get; }

        /// <summary>
        /// Gets a value indicating whether validation object is valid.
        /// </summary>
        /// <value>
        ///  <c>true</c> if validation is successful; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; }

        /// <summary>
        /// Gets the failure messages.
        /// </summary>
        /// <value>
        /// The collection failure messages.
        /// </value>
        public IEnumerable<string> FailureMessages { get; }

        /// <summary>
        /// Gets the invalid attributes.
        /// </summary>
        /// <value>
        /// The collection invalid attributes.
        /// </value>
        public IEnumerable<BaseValidationAttribute> InvalidAttributes { get; }
    }
}
