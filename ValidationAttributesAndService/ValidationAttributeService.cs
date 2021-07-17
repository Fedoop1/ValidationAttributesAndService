using System;
using System.Reflection;
using NLog;
using ValidationAttributesAndService.Attributes;

namespace ValidationAttributesAndService
{
    /// <summary>
    /// Static class that validate merked by <see cref="BaseValidationAttribute"/> properties.
    /// </summary>
    public static class ValidationAttributeService
    {
        /// <summary>
        /// Validates marked by <see cref="BaseValidationAttribute"/> properties to according some condition, in case of validation failed write error information in log.
        /// </summary>
        /// <typeparam name="T">Type of validation object.</typeparam>
        /// <param name="obj">The object of validation.</param>
        /// <param name="logger">The logger instance.</param>
        /// <returns><c>True</c> if validation passed successful, otherwise <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">
        /// Throws when logger is null
        /// or
        /// validation object is null.
        /// </exception>
        public static bool Validate<T>(T obj, ILogger logger)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger), "Logger is null");
            }

            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj), "Validation object is null");
            }

            bool objectIsValid = true;

            foreach (var property in obj.GetType().GetProperties())
            {
                foreach (var attribute in property.GetCustomAttributes<BaseValidationAttribute>(true))
                {
                    if (!attribute.Validate(property.GetValue(obj)))
                    {
                        logger.Error($"Failed validation of the attribute {attribute.GetType().Name}. Property name: {property.Name}. Property value: {property.GetValue(obj)}. Failure message: {attribute.FailureMessage}.");
                        objectIsValid = false;
                    }
                }
            }

            return objectIsValid;
        }

        /// <summary>
        /// Validates marked by <see cref="BaseValidationAttribute"/> properties to according some condition.
        /// </summary>
        /// <typeparam name="T">Type of validation object.</typeparam>
        /// <param name="obj">The validation object.</param>
        /// <returns><c>True</c> if validation passed successful, otherwise <c>false</c>.</returns>
        public static bool Validate<T>(T obj) => Validate(obj, LogManager.CreateNullLogger());
    }
}
