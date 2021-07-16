using System;

namespace ValidationAttributesAndService.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class BaseValidationAttribute : Attribute
    {
        public string FailureMessage { get; set; } = "An error occurred during the validation.";

        public abstract bool Validate(object obj);
    }
}
