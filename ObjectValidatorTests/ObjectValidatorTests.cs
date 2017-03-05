using System;
using System.Collections.Generic;
using NUnit.Framework;
using ObjectValidator;
using ObjectValidator.Rules;
using ObjectValidator.rules;

namespace ObjectValidatorTests
{
    [TestFixture]
    public class ObjectValidatorTests
    {

        [Test]
        public void Range_WhenIsInRange_ShouldReturnTrue()
        {
            // arrange
            var testObject = new TestObject() { Age = 20 };
            var requiredRule = new RangeRule<int>("Age", "El campo {0} debe de de estar entre {1} y {2}", 10, 43);
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid(testObject.Age);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Range_WhenIsOutRange_ShouldReturnFalse()
        {
            // arrange
            var testObject = new TestObject() { Age = 8 };
            var requiredRule = new RangeRule<int>("Age", "El campo {0} debe de de estar entre {1} y {2}", 10, 43);
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid(testObject.Age);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Range_WhenIsNull_ShouldReturnFalse()
        {
            // arrange
            var requiredRule = new RangeRule<int>("Age", "El campo {0} debe de de estar entre {1} y {2}", 10, 43);
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid(null);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Range_WhenIsInvalidType_ShouldReturnFalse()
        {
            // arrange
            var requiredRule = new RangeRule<int>("Age", "El campo {0} debe de de estar entre {1} y {2}", 10, 43);
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid("omg");

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Min_WhenIsGreatherThanMin_ShouldReturnTrue()
        {
            // arrange
            var testObject = new TestObject() { Age = 20 };
            var requiredRule = new MinRule<int>("Age", "El campo {0} debe de de estar entre {1} y {2}", 10);

            // act
            bool result = requiredRule.IsValid(testObject.Age);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Min_WhenLessThanMin_ShouldReturnFalse()
        {
            // arrange
            var testObject = new TestObject() { Age = 8 };
            var requiredRule = new MinRule<int>("Age", "El campo {0} debe de de estar entre {1} y {2}", 10);
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid(testObject.Age);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Min_WhenIsNull_ShouldReturnFalse()
        {
            // arrange
            var requiredRule = new MinRule<int>("Age", "El campo {0} debe de de estar entre {1} y {2}", 10);

            // act
            bool result = requiredRule.IsValid(null);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Min_WhenIsInvalidType_ShouldReturnFalse()
        {
            // arrange
            var requiredRule = new MinRule<int>("Age", "El campo {0} debe de de estar entre {1} y {2}", 10);
           
            // act
            bool result = requiredRule.IsValid("omg");

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Max_WhenIsLessThanMax_ShouldReturnTrue()
        {
            // arrange
            var testObject = new TestObject() { Age = 3 };
            RuleBase requiredRule = new MaxRule<int>("Age", "El campo {0} debe de de estar entre {1} y {2}", 10);

            // act
            bool result = requiredRule.IsValid(testObject.Age);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Max_WhenGreatherThanMax_ShouldReturnFalse()
        {
            // arrange
            var testObject = new TestObject() { Age = 15 };
            var requiredRule = new MaxRule<int>("Age", "El campo {0} debe de de estar entre {1} y {2}", 10);

            // act
            bool result = requiredRule.IsValid(testObject.Age);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Max_WhenIsNull_ShouldReturnFalse()
        {
            // arrange
            var requiredRule = new MaxRule<int>("Age", "El campo {0} debe de de estar entre {1} y {2}", 10);

            // act
            bool result = requiredRule.IsValid(null);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Max_WhenIsInvalidType_ShouldReturnFalse()
        {
            // arrange
            var requiredRule = new MaxRule<int>("Age", "El campo {0} debe de de estar entre {1} y {2}", 10);

            // act
            bool result = requiredRule.IsValid("omg");

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Regex_WhenMatchRegex_ShouldReturnTrue()
        {
            // arrange
            RuleBase requiredRule = new RegexRule("Age", "El campo {0} debe de coincidir con la expresión regular {1}", "^([A-Za-z]*)$");

            // act
            bool result = requiredRule.IsValid("Rene");

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Regex_WhenDontMatchRegex_ShouldReturnFalse()
        {
            // arrange
            RuleBase requiredRule = new RegexRule("Age", "El campo {0} debe de coincidir con la expresión regular {1}", "^([A-Za-z]*)$");

            // act
            bool result = requiredRule.IsValid("Re1ne");

            // assert
            Assert.IsFalse(result);
        }


        [Test]
        public void Regex_WhenIsNull_ShouldReturnFalse()
        {
            // arrange
            RuleBase requiredRule = new RegexRule("Age", "El campo {0} debe de coincidir con la expresión regular {1}", "^([A-Za-z]*)$");

            // act
            bool result = requiredRule.IsValid(null);

            // assert
            Assert.IsFalse(result);
        }
        
        [Test]
        public void RequiredRule_WhenObjectIsNotNull_ShouldReturnTrue()
        {
            // arrange
            var testObject = new TestObject() {Name = "Nombre"};
            var requiredRule = new RequiredRule("Name","El campo {0} es requerido");
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid(testObject.Name);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RequiredRule_WhenObjectIsNull_ShouldReturnFalse()
        {
            // arrange
            var testObject = new TestObject();
            var requiredRule = new RequiredRule("Name", "El campo {0} es requerido");
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid(testObject.Name);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void RequiredRule_WhenStringIsEmptyOrSpace_ShouldReturnFalse()
        {
            // arrange
            var testObject = new TestObject() {Name = ""};
            var requiredRule = new RequiredRule("Name", "El campo {0} es requerido", true);
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid(testObject.Name);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void EmailAddressRule_WhenAValidEmailIsProvided_ShouldReturnTrue()
        {
            // arrange
            var testObject = new TestObject() { Name = "final20@gmail.com" };
            var requiredRule = new EmailAddressRule("Name", "El campo {0} no corresponde con ningun correo");
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid(testObject.Name);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void EmailAddressRule_WhenAInValidEmailIsProvided_ShouldReturnFalse()
        {
            // arrange
            var testObject = new TestObject() { Name = "final20@gma@il.com" };
            var requiredRule = new EmailAddressRule("Name", "El campo {0} no corresponde con ningun correo");
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid(testObject.Name);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void EmailAddressRule_WhenNullObjectIsProvided_ShouldReturnFalse()
        {
            // arrange
            var testObject = new TestObject() { };
            var requiredRule = new EmailAddressRule("Name", "El campo {0} no corresponde con ningun correo");
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid(testObject.Name);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void EmailAddressRule_WhenNoStringObjectIsProvided_ShouldReturnFalse()
        {
            // arrange
            var testObject = new TestObject() { };
            var requiredRule = new EmailAddressRule("Boss", "El campo {0} no corresponde con ningun correo");
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid(testObject.Boss);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void EmailAddressRule_WhenEmptyStringObjectIsProvided_ShouldReturnFalse()
        {
            // arrange
            var testObject = new TestObject() { Name = ""};
            var requiredRule = new EmailAddressRule("Name", "El campo {0} no corresponde con ningun correo");
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid(testObject.Name);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void MaxLength_WhenEmptyStringObjectIsProvided_ShouldReturnFalse()
        {
            // arrange
            var testObject = new TestObject() { Name = "" };
            var requiredRule = new MaxLengthRule("Name",25, "El campo {0} no corresponde con ningun correo");
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid(testObject.Name);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void MaxLength_WhenStringIsLargerThanMaxLength_ShouldReturnTrue()
        {
            // arrange
            var testObject = new TestObject() { Name = "asddededsdf" };
            var requiredRule = new MaxLengthRule("Name", 4, "El campo {0} no corresponde con ningun correo");
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid(testObject.Name);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void MaxLength_WhenStringIsShorterOrEqualThanMaxLength_ShouldReturnTrue()
        {
            // arrange
            var testObject = new TestObject() { Name = "asd" };
            var requiredRule = new MaxLengthRule("Name", 4, "El campo {0} no corresponde con ningun correo");
            List<ValidationError> results = new List<ValidationError>();

            // act
            bool result = requiredRule.IsValid(testObject.Name);

            // assert
            Assert.IsTrue(result);
        }
       
        [Test]
        public void TryValidate_ShouldReturnTrueRequiredRule()
        {
            // arrange
            var testObject = new TestObject() { Name = "Rene"};
            var objectValidator = new Validator<TestObject>();
            List<ValidationError> errors = new List<ValidationError>();
            objectValidator.AddRule(new RequiredRule("Name", "El campo {0} es requerido"));
            // act
            bool result = objectValidator.TryValidate(testObject, errors);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryValidate_WhenErrorCollectionIsNull_ShouldThrowArgumentNullException()
        {
            // arrange
            var testObject = new TestObject() { Name = "Rene" };
            var objectValidator = new Validator<TestObject>();
            objectValidator.AddRule(new RequiredRule("Name", "El campo {0} es requerido"));
            // act
            bool result = objectValidator.TryValidate(testObject, null);

            // assert
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryValidate_WhenObjectIsNull_ShouldThrowArgumentNullException()
        {
            // arrange
            var objectValidator = new Validator<TestObject>();
            var errorList = new List<ValidationError>();
            objectValidator.AddRule(new RequiredRule("Name", "El campo {0} es requerido"));
            // act
            bool result = objectValidator.TryValidate(null, errorList);

            // assert
        }
        
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TryValidate_WhenRuleHaveInvalidPropertyName_ShouldThrowInvalidOperationException()
        {
            // arrange
            var testObject = new TestObject() { Name = "Rene" };
            var objectValidator = new Validator<TestObject>();
            List<ValidationError> errors = new List<ValidationError>();
            objectValidator.AddRule(new RequiredRule("Names", "El campo {0} es requerido"));
            // act
            bool result = objectValidator.TryValidate(testObject, errors);

            // assert
        }


        [Test]
        public void TryValidate_ShouldReturnFalseOnRequiredRule()
        {
            // arrange
            var testObject = new TestObject() { };
            var objectValidator = new Validator<TestObject>();
            List<ValidationError> errors = new List<ValidationError>();
            objectValidator.AddRule(new RequiredRule("Name", "El campo {0} es requerido"));
            // act
            bool result = objectValidator.TryValidate(testObject, errors);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TryValidate_ShouldReturnErrorList()
        {
            // arrange
            var testObject = new TestObject() { };
            var objectValidator = new Validator<TestObject>();
            List<ValidationError> errors = new List<ValidationError>();
            objectValidator.AddRule(new RequiredRule("Name", "El campo {0} es requerido"));
            // act
            bool result = objectValidator.TryValidate(testObject, errors);

            // assert
            Assert.IsFalse(result);
            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("El campo Name es requerido", errors[0].ErrorMessage);
            Assert.AreEqual("Name", errors[0].PropertyName);
            Assert.AreEqual("RequiredRule", errors[0].ValidationRuleName);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddRule_WhenNullObjectIsProvided_ShouldThrowArgumentNullException()
        {
            // arrange
            var objectValidator = new Validator<TestObject>();
            List<ValidationError> errors = new List<ValidationError>();

            // act
            objectValidator.AddRule(null);

            // assert
        }

        [Test]
        public void TryValidate_ShouldValidateASetOfRules()
        {
            // arrange
            var testObject = new TestObject() { Name = "Rene", Address = "Norte 9", Notes = "final20@gmail.com", Age = 18};
            var objectValidator = new Validator<TestObject>();
            List<ValidationError> errors = new List<ValidationError>();
            objectValidator.AddRule(new RequiredRule("Address", "El campo {0} es requerido", true));
            objectValidator.AddRule(new RegexRule("Name", "El campo {0} no tiene el formato esperado: {1}","^([A-Za-z]*)$"));
            objectValidator.AddRule(new MinRule<int>("Age", "La edad minima es de {1} años", 18));
            objectValidator.AddRule(new MaxLengthRule("Address", 10, "{0} no puede tener mas de {1} caracteres"));

            // act
            bool result = objectValidator.TryValidate(testObject, errors);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TryValidate_ShouldPopulateErrorList()
        {
            // arrange
            var testObject = new TestObject() { Name = "Ren1e", Address = "Nortedfdsdfeesdf 9", Notes = "final20@gmail.com", Age = 12 };
            var objectValidator = new Validator<TestObject>();
            List<ValidationError> errors = new List<ValidationError>();
            objectValidator.AddRule(new RequiredRule("Address", "El campo {0} es requerido", true));
            objectValidator.AddRule(new RegexRule("Name", "El campo {0} no tiene el formato esperado: {1}", "^([A-Za-z]*)$"));
            objectValidator.AddRule(new MinRule<int>("Age", "La edad minima es de {1} años", 18));
            objectValidator.AddRule(new MaxLengthRule("Address", 10, "{0} no puede tener mas de {1} caracteres"));

            // act
            bool result = objectValidator.TryValidate(testObject, errors);

            // assert
            Assert.IsFalse(result);
            CollectionAssert.IsNotEmpty(errors);
            Assert.AreEqual(3, errors.Count);
        }

    }
}