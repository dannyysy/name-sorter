using System;
using System.Collections.Generic;
using System.Text;

namespace name_sorter
{
    /// <summary>
    /// This is a class factory for IFileUtilityCompatible objects
    /// </summary>
    public class NameFactory : IFileUtilityCompatibleFactory
    {
        /// <summary>
        /// This will create an object that implements IFileUtilityCompatible interface.
        /// </summary>
        /// <returns>An object that implements IFileUtilityCompatible interface.</returns>
        public IFileUtilityCompatible GetFileUtilityCompatibleObject()
        {
            IFileUtilityCompatible name = new Name();
            return name;
        }
    }
}
