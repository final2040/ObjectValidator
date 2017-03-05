using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ObjectValidator;

namespace ObjectValidatorTests
{
    [TestFixture]
    public class ReflectionHelperTests
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            // Your SetUp Here
        }

        [Test]
        public void GetPropertyList_ShouldReturnListWithObjectReadableProperties()
        {
            // Arrange
            var testObject = new TestObject();
            var reflectionHelper = new ReflectionHelper();

            // Act
            var result = reflectionHelper.GetProperties(testObject);

            // Assert
            Assert.AreEqual(10, result.Count);
            Assert.IsTrue(result.ContainsKey("Name"));
            Assert.IsTrue(result.ContainsKey("Age"));
            Assert.IsTrue(result.ContainsKey("Address"));
            Assert.IsTrue(result.ContainsKey("Notes"));
            Assert.IsTrue(result.ContainsKey("Salary"));
            Assert.IsTrue(result.ContainsKey("Phone"));
            Assert.IsTrue(result.ContainsKey("BirthDay"));
            Assert.IsTrue(result.ContainsKey("Clients"));
            Assert.IsTrue(result.ContainsKey("Boss"));
            Assert.IsTrue(result.ContainsKey("TestProperty"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPropertyList_WhenNullObjectIsProvided_ShouldThrowArgumentNullException()
        {
            // Arrange
            TestObject testObject = null;
            var reflectionHelper = new ReflectionHelper();

            // Act
            var result = reflectionHelper.GetProperties(testObject);

            // Assert

        }


        [Test]
        public void GetPropertyValue_ShouldReturnValueOfEspecifiedProperty()
        {
            // Arrange
            var testObject = new TestObject() { Name = "Jorge" };
            var reflectionHelper = new ReflectionHelper();

            // Act
            object result = reflectionHelper.GetPropertyValue(testObject, "Name", typeof(string));

            // Assert
            Assert.AreEqual("Jorge", result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPropertyValue_WhenProvidedObjectIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            TestObject testObject = null;
            var reflectionHelper = new ReflectionHelper();

            // Act
            object result = reflectionHelper.GetPropertyValue(testObject, "Name", typeof(string));

            // Assert

        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetPropertyValue_WhenProvidedPropertyDontExistsInObject_ShouldThrowArgumentException()
        {
            // Arrange
            var testObject = new TestObject() { Name = "Jorge" };
            var reflectionHelper = new ReflectionHelper();

            // Act
            object result = reflectionHelper.GetPropertyValue(testObject, "imnotexistentproperty",typeof(string));

            // Assert

        }

        [Test]
        public void GetPropertyTable_ShouldReturnPropertyValueDictionary()
        {
            // Arrange
            var testObject = new TestObject()
            {
                Name = "Jorge",
                Address = "Rio danubio no 80",
                Age = 19,
                BirthDay = new DateTime(15, 03, 16),
                Boss = new SecondaryObject() { Name = "Rene", Age = 23 },
                Clients = null,
                Notes = "No notes",
                Phone = 50474200,
                Salary = 1325.25M
            };
            var reflectionHelper = new ReflectionHelper();

            // Act
            Dictionary<string, object> result = reflectionHelper.GetPropertiesTable(testObject);

            // Assert
            Assert.IsInstanceOf<string>(result["Name"]);
            Assert.IsInstanceOf<string>(result["Address"]);
            Assert.IsInstanceOf<int>(result["Age"]);
            Assert.IsInstanceOf<DateTime>(result["BirthDay"]);
            Assert.IsInstanceOf<SecondaryObject>(result["Boss"]);
            Assert.IsInstanceOf<string>(result["Notes"]);
            Assert.IsInstanceOf<double>(result["Phone"]);
            Assert.IsInstanceOf<decimal>(result["Salary"]);
            Assert.IsNull(result["Clients"]);
            Assert.AreEqual("Jorge", result["Name"]);
            Assert.AreEqual("Rio danubio no 80", result["Address"]);
            Assert.AreEqual(19, result["Age"]);
            Assert.AreEqual(new DateTime(15, 03, 16), result["BirthDay"]);
            Assert.AreEqual("No notes", result["Notes"]);
            Assert.AreEqual(50474200, result["Phone"]);
            Assert.AreEqual(1325.25M, result["Salary"]);
        }

        [Test]
        public void GetPropertiesTable_WhenInheritedPropertyIsAmbiguos_ShouldIgnoreParentProperty()
        {
            // Arrange
            var testObject = new InheritedObject() {TestProperty = new InheritedObject()};
            var reflectionHelper = new ReflectionHelper();

            // Act
            var result = reflectionHelper.GetPropertiesTable(testObject);

            // Assert
            CollectionAssert.AllItemsAreUnique(result);
        }

    }

    public class TestObject
    {
        private object _onlyset;
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public decimal Salary { get; set; }
        public double Phone { get; set; }
        public DateTime BirthDay { get; set; }
        public List<string> Clients { get; set; }
        public SecondaryObject Boss { get; set; }
        public virtual string SetOnly { set { this._onlyset = value; } }
        public TestObject TestProperty { get; set; }
    }

    public class SecondaryObject
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class InheritedObject : TestObject
    {
        public new InheritedObject TestProperty { get; set; }
        public uint AnotherProperty { get; set; }

    }
}
