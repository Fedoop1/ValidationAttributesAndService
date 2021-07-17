using System;
using System.Linq;
using System.Reflection;

namespace ValidationAttributesAndService.Attributes
{
    public class RangeValidationAttribute : BaseValidationAttribute
    {
        private readonly int lowerValidBound;
        private readonly int upperValidBound;

        public RangeValidationAttribute(int lowerValidationBound, int upperValidationBound) => (this.lowerValidBound, this.upperValidBound) = (lowerValidationBound, upperValidationBound);

        public override bool Validate(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            var propertyValues = from property in obj.GetType().GetProperties()
                           where property.PropertyType == typeof(RangeValidationAttribute)
                           select property.GetValue(obj);

            foreach (var value in propertyValues)
            {
                if ((int)value < this.lowerValidBound && (int)value > this.upperValidBound)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
