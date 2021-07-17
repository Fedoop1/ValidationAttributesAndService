using NUnit.Framework;
using NLog;
using System.IO;
using System.Collections.Generic;

namespace ValidationAttributesAndService.Tests
{
    internal class ValidationAttributeServiceTests
    {
        private LogFactory loggerFactory;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.loggerFactory = LogManager.LoadConfiguration("nlog.config");
        }

        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.ValidValidationAttributeSource))]
        public void Validate_ValidData_ReturnTrue(object obj) => Assert.IsTrue(ValidationAttributeService.Validate(obj));

        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.InvalidValidationAttributeSource))]
        public void Validate_InvalidData_ReturnFalse(object obj) => Assert.IsFalse(ValidationAttributeService.Validate(obj));

        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.SetOfInvalidValidationAttributeRecords))]
        public void Validate_InvalidData_ReturnFalseWriteToLogFile(IEnumerable<object> setOfObjects)
        {
            const string LogFileName = "ValidationAttributesTests.log";

            if(File.Exists(LogFileName))
            {
                File.Delete(LogFileName);
            }

            foreach (var @object in setOfObjects)
            {
                ValidationAttributeService.Validate(@object, loggerFactory.GetLogger("fileLogger"));
            }
            
            Assert.IsTrue(File.Exists(LogFileName));
        }

    }
}
