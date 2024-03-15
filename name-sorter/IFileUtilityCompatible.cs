using System;
using System.Collections.Generic;
using System.Text;

namespace name_sorter
{
    /// <summary>
    /// This interface will be used with FileUtility custom class which will allow the implementing class to participate in reading 
    /// from a file and writing to a file
    /// </summary>
    public interface IFileUtilityCompatible
    {
        /// <summary>
        /// This method must be able to take a line of data read from a file and populate its internal data structure.
        /// </summary>
        /// <param name="data">This is the line of data read from a file for parsing.</param>
        void Parse(string data);

        /// <summary>
        /// This method must be able to take its internal data structure and serialise it into a single string.
        /// </summary>
        /// <returns>This is the serialised data.</returns>
        string Serialise();
    }
}
