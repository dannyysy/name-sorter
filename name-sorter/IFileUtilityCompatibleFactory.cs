using System;
using System.Collections.Generic;
using System.Text;

namespace name_sorter
{
    /// <summary>
    /// This interface will be used with the FileUtility custom class.  It defines an object factory that the FileUtility will need 
    /// to create an IFileUtilityCompatible object.
    /// </summary>
    public interface IFileUtilityCompatibleFactory
    {
        /// <summary>
        /// This method will instantiate a IFileUtilityCompatible object required by the FileUtility class.
        /// </summary>
        /// <returns> IFileUtilityCompatible object </returns>
        IFileUtilityCompatible GetFileUtilityCompatibleObject();
    }
}
