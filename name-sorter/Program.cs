using System;
using System.Collections.Generic;

namespace name_sorter
{
    public class Program
    {
        static void Main(string[] args)
        {
            string inputFileName;

            // Get input file name from first command line argument if specified otherwise default it to .\unsorted-names-list.txt
            if (args.Length > 0)
            {
                inputFileName = args[0];
            }
            else
            {
                inputFileName = ".\\unsorted-names-list.txt";
            }

            NameFactory nameFactory = new NameFactory();
            FileUtility fileUtility = new FileUtility(nameFactory);

            List<IFileUtilityCompatible> nameList;
            try
            {
                // reading unsorted file and loading the data into nameList collection
                nameList = fileUtility.FileToList(inputFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("An error was encountered while trying to read the file {0}, exiting the program now.", inputFileName);
                return;
            }
             

            nameList.Sort();

            // Display sorted names on screen
            foreach (Name name in nameList)
            {
                Console.WriteLine(name.OriginalValue);
            }


            // Get output file name from second command line argument if specified otherwise default it to .\sorted-names-list.txt
            string outputFileName;
            if (args.Length > 1)
            {
                outputFileName = args[1];
            }
            else
            {
                outputFileName = ".\\sorted-names-list.txt";
            }

            try
            {
                // Writing sorted names to outputFileName
                fileUtility.ListToFile(nameList, outputFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("An error was encountered while trying to write the file {0}, exiting the program now.", outputFileName);
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
