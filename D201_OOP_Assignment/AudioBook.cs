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
    /// Create a new class object called AudioBook that has length and narrator as properties.
    /// Inherits title, author, year and filesize properties from DigitalBook class.
    /// </summary>
    class AudioBook:DigitalBook
    {
        // Declare a string variable called length.
        string length;
        // Declare a string variable called narrator.
        string narrator;

        public string Length
        {
            // Use the string variable stored in length for Length property
            get { return length; }
            set { length = value; }
        }
        
        public string Narrator
        {
            // Use the string variable stored in narrator for Narrator property
            get { return narrator; }
            set { narrator = value; }
        }

        // Default constructor, sets all string properties to empty and int properties to 0
        public AudioBook()
        {
            Title = "";
            Author = "";
            Year = 0;
            FileSize = "";
            Length = "";
            Narrator = "";
        }

        public override string ToString()
        {
            // Override the ToString() method to return the Title(space)Author(space)Year(Space)FileSize(space)Length(space)Narrator.
            return base.ToString() + " " + Length + " " + Narrator;
        }

        public override string GetPrice()
        {
            // Override the GetPrice() method to return a price calculated from the book’s year plus the length in hours.
            return "$" + Year.ToString() + Length;
        }
    }
}
