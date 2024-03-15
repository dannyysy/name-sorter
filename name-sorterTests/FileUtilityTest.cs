using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter;
using System.Collections.Generic;
using System.IO;

namespace name_sorterTests
{
    class Mock_IFileUtilityCompatible : IFileUtilityCompatible
    {
        public void Parse(string data)
        {
        }

        public string Serialise()
        {
            return "";
        }
    }

    class Mock_IFileUtilityCompatibleFactory : IFileUtilityCompatibleFactory
    {
        public IFileUtilityCompatible GetFileUtilityCompatibleObject()
        {
            return new Mock_IFileUtilityCompatible();
        }
    }

    [TestClass]
    public class FileUtilityTest
    {
        [TestMethod]
        public void FileToListTest()
        {
            List<string> listOfData = new List<string>() { "1", "2", "3" };
            string fileName = ".\\FileUtility_FiletoListTest.txt";

            using (StreamWriter writer = new StreamWriter(fileName, false /*this will overwrite an existing file*/))
            {
                foreach (string data in listOfData)
                {
                    writer.WriteLine(data);
                }
            }

            IFileUtilityCompatibleFactory mockFactory = new Mock_IFileUtilityCompatibleFactory();
            FileUtility fileUtility = new FileUtility(mockFactory);

            List<IFileUtilityCompatible> listOfMockObj;
            listOfMockObj = fileUtility.FileToList(fileName);

            Assert.AreEqual(listOfMockObj.Count, listOfData.Count);
        }

        [TestMethod]
        public void ListToFileTest()
        {
            string fileName = ".\\FileUtility_ListToFileTest.txt";

            IFileUtilityCompatibleFactory mockFactory = new Mock_IFileUtilityCompatibleFactory();
            FileUtility fileUtility = new FileUtility(mockFactory);

            int numberOfLines = 3;
            List<IFileUtilityCompatible> listOfMockObj = new List<IFileUtilityCompatible>();
            IFileUtilityCompatible mockObj = new Mock_IFileUtilityCompatible();

            for (int i = 0; i < numberOfLines; i++)
                listOfMockObj.Add(mockObj);

            fileUtility.ListToFile(listOfMockObj, fileName);
            List<string> listOfData = new List<string>();

            using (StreamReader reader = File.OpenText(fileName))
            {
                string line;
                
                while ((line = reader.ReadLine()) != null)
                {
                    listOfData.Add(line);
                }
            }

            Assert.AreEqual(listOfData.Count, listOfMockObj.Count);
        }
    }
}