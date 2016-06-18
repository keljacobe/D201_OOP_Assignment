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
    /// Create a new abstract class object called Book that has title, author and year as properties.
    /// </summary>
    public abstract class Book
    {
        // Declare a string variable called title.
        string title;
        // Declare a string variable called author.
        string author;
        // Declare an int variable called year.
        int year;

        public string Title
        {
            // Use the string variable stored in title for Title property
            get { return title; }
            set { title = value; }
        }      

        public string Author
        {
            // Use the string variable stored in author for Author property.
            get { return author; }
            set { author = value; }
        }
        
        public int Year
        {
            // Use the int variable stored in year for Year property
            get { return year; }
            set { year = value; }
        }

        // Default constructor
        public Book()
        {
        }

        public override string ToString()
        {
            // Override the ToString() method to return the Title(space)Author(space)Year.
            // Convert the Year property to string.
            return Title + " " + Author + " " + Year.ToString();
        }

        public virtual string GetPrice()
        {
            // Virtual string GetPrice() method to return a price calculated from the book’s year.
            return "$" + Year.ToString();
        }

    }
}
