using System;

namespace ValidationAttributesAndService.Attributes
{
    public class RangeValidationAttribute : BaseValidationAttribute
    {
        private readonly int lowerValidBound;
        private readonly int upperValidBound;

        public RangeValidationAttribute(int lowerValidationBound, int upperValidationBound) => (this.lowerValidBound, this.upperValidBound) = (lowerValidationBound, upperValidationBound);

        public override bool Validate(object obj) => (int)obj >= this.lowerValidBound && (int)obj <= this.upperValidBound;
    }
}
