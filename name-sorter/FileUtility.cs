using System;
using System.Collections.Generic;
using System.IO;

namespace name_sorter
{
    /// <summary>
    /// This is a utility class that will provide generic file read and write service.
    /// 
    /// To use this, you need a class that implements the IFacilityUtilityCompatible interface.  It will take care of parsing
    /// line of data read from a file as well as serialising data back to single string before it is written back to a file.
    /// 
    /// A class factory that implements the IFileUtilityCompatibleFactory interface is also needed.  The factory will produce an 
    /// IFacilityUtilityCompatible object whenever it is needed.
    /// </summary>
    public class FileUtility
    {
        private IFileUtilityCompatibleFactory defaultFileUtilityObjectFactory;

        public FileUtility(IFileUtilityCompatibleFactory fileUtilityObjectFactory)
        {
            this.defaultFileUtilityObjectFactory = fileUtilityObjectFactory;
        }

        /// <summary>
        /// This method will read a file line by line and will hand each line of data to an IFacilityUtilityCompatible object for
        /// parsing.  The parsed data will be collected in a list and returned to the caller.
        /// </summary>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <param name="fileUtilityObjectFactory">The class factory that will produce the needed IFacilityUtilityCompatible object.</param>
        /// <returns>List of parsed data.</returns>
        public List<IFileUtilityCompatible> FileToList(string inputFileName, IFileUtilityCompatibleFactory fileUtilityObjectFactory)
        {
            List<IFileUtilityCompatible> result = new List<IFileUtilityCompatible>();

            using (StreamReader reader = File.OpenText(inputFileName))
            {
                string line;
                IFileUtilityCompatible fileUtilityCompatibleObject;

                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        fileUtilityCompatibleObject = fileUtilityObjectFactory.GetFileUtilityCompatibleObject();
                        fileUtilityCompatibleObject.Parse(line);
                        result.Add(fileUtilityCompatibleObject);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Skipping (" + line + ") as it did not pass parsing validation.");
                        Console.WriteLine();
                    }
                }
            }

            return result;
        }
        
        /// <summary>
        /// This method will read a file line by line and will hand each line of data to an IFacilityUtilityCompatible object for
        /// parsing.  The parsed data will be collected in a list and returned to the caller.
        /// 
        /// Note: This is an overloaded method that wraps a method with the same name but a different signature.  Instead of having the
        /// caller specify a class factory it uses the one injected during instantiation of the FileUtility class.
        /// </summary>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <returns>List of parsed data.</returns>
        public List<IFileUtilityCompatible> FileToList(string inputFileName)
        {
            return FileToList(inputFileName, this.defaultFileUtilityObjectFactory);
        }

        /// <summary>
        /// This method takes a list of IFileUtilityCompatible objects and writes it to a file.  It hands over the serialisation of data
        /// to the IFileUtilityCompatible object.
        /// </summary>
        /// <param name="listOfFileUtilityCompatibleObject">List of IFileUtilityCompatible objects to write.</param>
        /// <param name="outputFileName">Name of the output file.</param>
        public void ListToFile(List<IFileUtilityCompatible> listOfFileUtilityCompatibleObject, string outputFileName)
        {
            using (StreamWriter writer = new StreamWriter(outputFileName, false /*this will overwrite an existing file*/))
            {
                foreach (IFileUtilityCompatible fileUtilityCompatibleObject in listOfFileUtilityCompatibleObject)
                {
                    writer.WriteLine(fileUtilityCompatibleObject.Serialise());
                }
            }
        }
    }
}
