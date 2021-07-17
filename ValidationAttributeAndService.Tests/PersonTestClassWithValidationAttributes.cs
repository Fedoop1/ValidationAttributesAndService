using ValidationAttributesAndService.Attributes;

namespace ValidationAttributesAndService.Tests
{
    internal class PersonTestClassWithValidationAttributes
    {
        [StringLengthValidation(12, FailureMessage = "Name length is invalid. Maximum available length is 10")]
        public string Name { get; set; }

        [StringLengthValidation(15, FailureMessage = "Second name length is invalid. Maximum available length is 15")]
        public string LastName { get; set; }

        [RangeValidation(18, 75, FailureMessage = "Age range is invalid. Person can't be younger 18 and older 75")]
        public int Age { get; set; }

        [RequiredPropertyValidation]
        public char Sex { get; set; }

        [RangeValidation(150, 210, FailureMessage = "Height is invalid. You can't be shorter than 150cm and higher than 210cm")]
        public int Height { get; set; }

        public float Weight { get; set; }
    }
}
