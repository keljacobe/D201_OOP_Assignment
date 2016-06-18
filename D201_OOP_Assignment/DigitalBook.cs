using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D201_OOP_Assignment
{
    // Add [Serializable] to enable serialization
    [Serializable]
    /// <summary>
    /// Create a new abstract class object called DigitalBook that has filesize as property.
    /// Inherits title, author and year properties from Book class.
    /// </summary>
    abstract class DigitalBook:Book
    {
        // Declare a string variable called fileSize.
        string fileSize;

        public string FileSize
        {
            // Use the string variable stored in fileSize for FileSize property
            get { return fileSize; }
            set { fileSize = value; }
        }

        // Default constructor, sets all string properties to empty and int properties to 0
        public DigitalBook()
        {
            Title = "";
            Author = "";
            Year = 0;
            FileSize = "";
        }

        public override string ToString()
        {
            // Override the ToString() method to return the Title(space)Author(space)Year(space)FileSize.
            return base.ToString() + " " + FileSize;
        }


    }
}
