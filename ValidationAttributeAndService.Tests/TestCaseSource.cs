using System.Collections.Generic;
using NUnit.Framework;

namespace ValidationAttributesAndService.Tests
{
    internal static class TestCaseSource
    {
        public static IEnumerable<TestCaseData> ValidValidationAttributeSource
        {
            get
            {
                yield return new TestCaseData(new PersonTestClassWithValidationAttributes() { Age = 18, Height = 175, Name = "Watson", LastName = "Coleman", Sex = 'M', Weight = 65 });
                yield return new TestCaseData(new PersonTestClassWithValidationAttributes() { Age = 25, Height = 185, Name = "Collin", LastName = "Baker", Sex = 'M', Weight = 70 });
                yield return new TestCaseData(new PersonTestClassWithValidationAttributes() { Age = 33, Height = 163, Name = "Boone", LastName = "Hill", Sex = 'M', Weight = 68 });
                yield return new TestCaseData(new PersonTestClassWithValidationAttributes() { Age = 19, Height = 190, Name = "Quintus", LastName = "Garcia", Sex = 'M', Weight = 72 });
                yield return new TestCaseData(new PersonTestClassWithValidationAttributes() { Age = 22, Height = 178, Name = "Gentry", LastName = "Martinez", Sex = 'M', Weight = 66 });
            }
        }

        public static IEnumerable<TestCaseData> InvalidValidationAttributeSource
        {
            get
            {
                yield return new TestCaseData(new PersonTestClassWithValidationAttributes() { Age = 14, Height = 125, Name = "Watson", LastName = "Coleman", Sex = 'M', Weight = 55 });
                yield return new TestCaseData(new PersonTestClassWithValidationAttributes() { Age = 110, Height = 140, Name = "Collin", LastName = "Baker", Sex = 'M', Weight = 70 });
                yield return new TestCaseData(new PersonTestClassWithValidationAttributes() { Age = 33, Height = 163, Name = "Boone", Sex = 'M', Weight = 68 });
                yield return new TestCaseData(new PersonTestClassWithValidationAttributes() { Age = 19, Height = 190, LastName = "Garcia", Sex = 'M', Weight = 72 });
                yield return new TestCaseData(new PersonTestClassWithValidationAttributes() { Age = 22, Height = 250, Name = "Gentry", LastName = "Martinez", Sex = 'M', Weight = 66 });
            }
        }

        public static IEnumerable<TestCaseData> SetOfInvalidValidationAttributeRecords
        {
            get
            {
                yield return new TestCaseData(new List<PersonTestClassWithValidationAttributes>()
                {
                    new PersonTestClassWithValidationAttributes() { Age = 14, Height = 125, Name = "Watson", LastName = "Coleman", Sex = 'M', Weight = 55 },
                    new PersonTestClassWithValidationAttributes() { Age = 25, Height = 140, Name = "Collin", LastName = "Baker", Sex = 'M', Weight = 70 },
                    new PersonTestClassWithValidationAttributes() { Age = 33, Height = 163, Name = "AAAAAAAAAAAAAAAAA", LastName = "Hill", Sex = 'M', Weight = 68 },
                    new PersonTestClassWithValidationAttributes() { Age = 19, Height = 190, Name = "Quintus", Sex = 'M', Weight = 72 },
                    new PersonTestClassWithValidationAttributes() { Age = 22, Height = 250, Name = "Gentry", LastName = "Martinez", Sex = 'M', Weight = 66 }
                });
            }
        }
    }
}
