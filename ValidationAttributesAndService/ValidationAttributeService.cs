using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using ValidationAttributesAndService.Attributes;

namespace ValidationAttributesAndService
{
    public static class ValidationAttributeService
    {
        public static bool Validate(object obj, ILogger logger)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger), "Logger is null");
            }

            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj), "Vlidation object is null");
            }

            bool objectIsValid = true;

            foreach (var attribute in obj.GetType().GetCustomAttributes(false).OfType<BaseValidationAttribute>())
            {
                if (!attribute.Validate(obj))
                {
                    logger.Error($"Failed validation of the attribute {attribute.GetType().Name}.\n Failure message: {attribute.FailureMessage}.");
                    objectIsValid = false;
                }
            }

            return objectIsValid;
        }

        public static bool Validate(object obj) => Validate(obj, null);
    }
}
