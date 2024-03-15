using System;

namespace name_sorter
{
    /// <summary>
    /// This class will serve as the main data structure for the name sorting program.  
    /// It will hold 1 last name and 1 or more first names.
    /// 
    /// It implements IComparable interface so we can take advantage of built-in Sort function of collection class.
    /// 
    /// It implements IFileUtilityCompatible so we can use the custom FileUtility class.
    /// </summary>
    public class Name : IComparable, IFileUtilityCompatible
    {
        private string lastName;
        private string[] firstName;
        private string originalValue;
                
        public string LastName { get => lastName; }
        public string[] FirstName { get => firstName; }
        public string OriginalValue { get => originalValue; }       

        /// <summary>
        /// This method is required by the IComparable interface.  
        /// 
        /// It compares the current instance of Name against the object that was passed into the method.  It will decide if it is 
        /// less than, equal to or greater than the object that was passed into the method.
        /// 
        /// Comparison logic:
        /// 1. Compare last name, if last names are different then return the result of the string comparison otherwise proceed to step 2
        /// 2. Compare first names one by one, at any point first names are different then return the result of the string comparison 
        /// otherwise proceed to step 3
        /// 3. If all allowable first names comparison are the same then we check the number of first names.  The one with more 
        /// first names is greater. (i.e. "John Paul George Ringo" > "John Paul George")
        /// 
        /// </summary>
        /// <param name="obj">Another Name object that the current instance will be compared against.</param>
        /// <returns>0 if equal, 1 if greater than, -1 if less than</returns>
        public int CompareTo(object obj) 
        {
            if (this.GetType() != obj.GetType())
            {
                throw new ArgumentException("Both objects being compared must be of type Name.", "obj");
            }
            else
            {
                Name name2 = (Name)obj;
                int lastNameCompareResult = string.Compare(this.lastName, name2.lastName);
                if (lastNameCompareResult == 0)
                {
                    int firstNameCompareResult = 0;
                    // lastNames are the same, we need to compare firstNames
                    for (int i = 0; i < this.firstName.Length && i < name2.firstName.Length; i++)
                    {
                        firstNameCompareResult = string.Compare(this.firstName[i], name2.firstName[i]);
                        if (firstNameCompareResult != 0)
                            break;

                    }

                    if (firstNameCompareResult == 0)
                    {
                        // all first names that can be compared are the same, then check number of first names
                        if (this.firstName.Length > name2.firstName.Length)
                            return 1;
                        else
                        {
                            if (this.firstName.Length < name2.firstName.Length)
                                return -1;
                            else
                                return 0;
                        }
                    }
                    else
                        return firstNameCompareResult;
                }
                else
                {
                    return lastNameCompareResult;
                }
            }
        }

        /// <summary>
        /// This method is required by the IFileUtilityCompatible interface.
        /// 
        /// This will take a list of names separated by space and split them out into individual names.  It will assign the last one
        /// to lastName and the rest to firstName.
        /// 
        /// It will also assign the original list of names to originalValue
        /// 
        /// For example:
        /// "John Paul George Ringo"
        /// 
        /// will become...
        /// 
        /// lastName = "Ringo"
        /// firstName = {"John", "Paul", "George"}
        /// originalValue = "John Paul George Ringo"
        /// </summary>
        /// <param name="data">List of names</param>
        public void Parse(string data)
        {
            string[] names = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (names.Length < 2)
            {
                throw new ArgumentException("The argument 'name' must contain at least 1 first name and 1 last name.", "name");
            }
            else
            {
                this.originalValue = data;
                this.lastName = names[names.Length - 1];
                this.firstName = new string[names.Length - 1];
                for (int i = 0; i < names.Length - 1; i++)
                    this.firstName[i] = names[i];
            }
        }

        /// <summary>
        /// This method is required by the IFileUtilityCompatible interface.
        /// 
        /// This just returns the originalValue.
        /// </summary>
        /// <returns>originalValue</returns>
        public string Serialise() /* implementing IFileUtilityCompatible interface methods */
        {
            return this.originalValue;
        }
    }
}