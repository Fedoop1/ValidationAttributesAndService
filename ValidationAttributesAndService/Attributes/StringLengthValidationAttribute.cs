using System;

namespace ValidationAttributesAndService.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StringLengthValidationAttribute : BaseValidationAttribute
    {
        private readonly int validStringLength;

        public StringLengthValidationAttribute(int validStringLength) => this.validStringLength = validStringLength;

        public override bool Validate(object obj)
        {
            if (obj != null && obj is string value && value.Length <= this.validStringLength)
            {
                return true;
            }

            return false;
        }
    }
}
