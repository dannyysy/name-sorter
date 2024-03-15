using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter;
using System;

namespace name_sorterTests
{
    [TestClass]
    public class NameTest
    {
        static string testName = "John Paul George Ringo";
        Name Test_SetUp()
        {
            Name name = new Name();
            name.Parse(testName);

            return name;
        }

        [TestMethod]
        public void ParseTest_OriginalValue()
        {
            Name name = Test_SetUp();
            Assert.AreEqual(name.OriginalValue, "John Paul George Ringo");
        }

        [TestMethod]
        public void ParseTest_LastName()
        {
            Name name = Test_SetUp();
            Assert.AreEqual(name.LastName, "Ringo");
        }

        [TestMethod]
        public void ParseTest_FirstName()
        {
            Name name = Test_SetUp();
            CollectionAssert.AreEqual(name.FirstName, new[] { "John", "Paul", "George" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "An invalid name format was inappropriately allowed.")]
        public void ParseTest_ThrowsArgumentException()
        {
            Name name = new Name();
            name.Parse("John");
        }

        [TestMethod]
        public void SerialiseTest()
        {
            Name name = Test_SetUp();
            Assert.AreEqual(name.Serialise(), testName);
        }

        [TestMethod]
        public void CompareTo_EqualTest()
        {
            Name name = Test_SetUp();
            Name name2 = Test_SetUp();
            Assert.AreEqual(name.CompareTo(name2), 0);
        }
        
        /// <summary>
        /// This tests for greater than due to lastname differences
        /// </summary>
        [TestMethod]
        public void CompareTo_GreaterThanLastNameTest()
        {
            Name name = Test_SetUp(); // lastName is Ringo
            Name name2 = new Name();
            name2.Parse("John Paul"); // lastName is Paul
            Assert.AreEqual(name.CompareTo(name2), 1);
        }

        /// <summary>
        /// This tests for greater than due to firstname differences
        /// </summary>
        [TestMethod]
        public void CompareTo_GreaterThanFirstNameTest()
        {
            Name name = Test_SetUp(); // firstName is { "John", "Paul", "George" }
            Name name2 = new Name();
            name2.Parse("John Adam Ringo"); // firstName is { "John", "Adam" }
            Assert.AreEqual(name.CompareTo(name2), 1);
        }

        /// <summary>
        /// This tests for greater than due to firstname count differences
        /// </summary>
        [TestMethod]
        public void CompareTo_GreaterThanFirstNameCountTest()
        {
            Name name = Test_SetUp(); // firstName is { "John", "Paul", "George" }
            Name name2 = new Name();
            name2.Parse("John Paul Ringo"); // firstName is { "John", "Paul" }
            Assert.AreEqual(name.CompareTo(name2), 1);
        }
                
        /// <summary>
        /// This tests for less than due to lastname differences
        /// </summary>
        [TestMethod]
        public void CompareTo_LessThanLastNameTest()
        {
            Name name = Test_SetUp(); // lastName is Ringo
            Name name2 = new Name();
            name2.Parse("John Paul"); // lastName is Paul
            Assert.AreEqual(name2.CompareTo(name), -1);
        }
        
        /// <summary>
        /// This tests for less than due to firstname differences
        /// </summary>
        [TestMethod]
        public void CompareTo_LessThanFirstNameTest()
        {
            Name name = Test_SetUp(); // firstName is { "John", "Paul", "George" }
            Name name2 = new Name();
            name2.Parse("John Adam Ringo"); // firstName is { "John", "Adam" }
            Assert.AreEqual(name2.CompareTo(name), -1);
        }

        /// <summary>
        /// This tests for less than due to firstname count differences
        /// </summary>
        [TestMethod]
        public void CompareTo_LessThanFirstNameCountTest()
        {
            Name name = Test_SetUp(); // firstName is { "John", "Paul", "George" }
            Name name2 = new Name();
            name2.Parse("John Paul Ringo"); // firstName is { "John", "Paul" }
            Assert.AreEqual(name2.CompareTo(name), -1);
        }
    }
}
