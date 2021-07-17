using System;
using System.Linq;

namespace ValidationAttributesAndService.Attributes
{
    public class RequiredPropertyValidationAttribute : BaseValidationAttribute
    {
        public override bool Validate(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            var propertyValues = from property in obj.GetType().GetProperties()
                                 where property.PropertyType == typeof(RequiredPropertyValidationAttribute)
                                 select property.GetValue(obj);

            foreach (var value in propertyValues)
            {
                switch (value)
                {
                    case object _ when value.GetType().IsGenericType && value == null:
                        return false;
                    case object _ when value.GetType().IsValueType && (ValueType)value == default(ValueType):
                        return false;
                    default:
                        continue;
                }
            }

            return true;
        }



            //=> obj switch
            //{
            //    null => false,
            //    _ when obj.GetType().IsGenericType => obj != null,
            //    _ when obj is ValueType vType => vType != default(ValueType),
            //};
    }
}
