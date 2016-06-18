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
    /// Create a new class object called EBook that has fileformat and pagecount as properties.
    /// Inherits title, author, year and filesize properties from DigitalBook class and IPageCount interface.
    /// </summary>
    class EBook:DigitalBook,IPageCount
    {
        // Declare a string variable called fileFormat.
        string fileFormat;
        // Declare an int variable called pageCount.
        int pageCount;
        public string FileFormat
        {
            // Use the string variable stored in fileFormat for FileFormat property
            get { return fileFormat; }
            set { fileFormat = value; }
        }

        public override string ToString()
        {
            // Override the ToString() method to return the Title(space)Author(space)Year(space)FileSize(space)FileFormat(space)PageCount.
            // Convert the PageCount property to string.
            return base.ToString() + " " + FileFormat + " " + PageCount.ToString();
        }

        // Default constructor, sets all string properties to empty and int properties to 0
        public EBook()
        {
            Title = "";
            Author = "";
            Year = 0;
            FileSize = "";
            FileFormat = "";
            PageCount = 0;
        }

        public int PageCount
        {
            // Use the string variable stored in pageCount for PageCount property
            get
            {
                return pageCount;
            }
            set
            {
                pageCount = value;
            }
        }
    }
}
