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
    /// Create a new class object called PhysicalBook that has weight and pagecount as properties.
    /// Inherits title, author and year properties from Book class and IPageCount interface.
    /// </summary>
    class PhysicalBook:Book,IPageCount
    {
        // Declare a string variable called weight.
        string weight;
        // Declare a int variable called pageCount.
        int pageCount;

        public string Weight
        {
            // Use the string variable stored in weight for Weight property
            get { return weight; }
            set { weight = value; }
        }

        // Default constructor, sets all string properties to empty and int properties to 0
        public PhysicalBook()
        {
            Title = "";
            Author = "";
            Year = 0;
            Weight = "";
        }

        public override string ToString()
        {
            // Override the ToString() method to return the Title(space)Author(space)Year(space)Weight.
            return base.ToString() + " " + Weight;
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
