using System;

namespace ValidationAttributesAndService.Attributes
{
    public class RequiredPropertyValidationAttribute : BaseValidationAttribute
    {
        public override bool Validate(object obj) => obj switch
        {
            null => false,
            _ when obj.GetType().IsGenericType => obj != null,
            _ when obj is ValueType vType => vType != default(ValueType),
        };
    }
}
