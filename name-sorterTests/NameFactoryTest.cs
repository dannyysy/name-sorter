using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter;

namespace name_sorterTests
{
    [TestClass]
    public class NameFactoryTest
    {
        [TestMethod]
        public void OfIFileUtilityCompatibleFactoryTypeTest()
        {
            NameFactory factory = new NameFactory();
            Assert.IsInstanceOfType(factory, typeof(IFileUtilityCompatibleFactory));
        }

        [TestMethod]
        public void GetFileUtilityCompatibleObject_OfNameTest()
        {
            NameFactory factory = new NameFactory();
            object obj = factory.GetFileUtilityCompatibleObject();

            Assert.IsInstanceOfType(obj, typeof(Name));
        }

        [TestMethod]
        public void GetFileUtilityCompatibleObject_OfIFileUtilityCompatibleTest()
        {
            NameFactory factory = new NameFactory();
            object obj = factory.GetFileUtilityCompatibleObject();

            Assert.IsInstanceOfType(obj, typeof(IFileUtilityCompatible));
        }
    }
}
