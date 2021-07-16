using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributesAndService.Attributes
{
    public class StringLengthValidationAttribute : BaseValidationAttribute
    {
        private readonly int validStringLength;

        public StringLengthValidationAttribute(int validStringLength) => this.validStringLength = validStringLength;

        public override bool Validate(object obj)
        {
            if (obj is string value && value != null)
            {
                return value.Length == this.validStringLength;
            }

            return false;
        }
    }
}
