using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D201_OOP_Assignment
{
    /// <summary>
    /// Handles the searching from the list of books using a search term
    /// </summary>
    class Searcher
    {
        /// <summary>
        /// Searches the list of books based on a search term
        /// </summary>
        /// <param name="searchBook">A list of book objects to be searched</param>
        /// <param name="term">The search term to be used</param>
        /// <returns>Returns a list of book objects based on the result of the search</returns>
        public List<Book> SearchBook (List<Book> searchBook, string term)
        {
            // Create a new list of book objects called results
            List<Book> results = new List<Book>();
            // Using linq, do a query to search for the books which property values are the same as the
            // search term used, then store them into the list results
            results = searchBook.Where(book => book.ToString().ToLower().Contains(term)).ToList();
            // Return the list of searched result
            return results;
        }

        /// <summary>
        /// Searches the list of books based on a search term
        /// </summary>
        /// <param name="bookTitleAndYear">A list of book objects to be searched</param>
        /// <param name="term">The search term to be used</param>
        /// <returns>Returns a list of book objects based on the result of the search</returns>
        public List<Book> SearchTitleAndYear (List<Book> bookTitleAndYear, string term)
        {
            // Create a new list of book objects called results
            List<Book> results = new List<Book>();
            // Using linq, do a query to search for the books which title and year property values are the same as the
            // search terms used, then store them into the list results
            results = bookTitleAndYear.Where(book => (book.Title.ToString().ToLower() + " " + book.Year.ToString().ToLower()).Contains(term)).ToList();
            // Return the list of searched result
            return results;
        }

        /// <summary>
        /// Searches the list of books based on a search term
        /// </summary>
        /// <param name="bookAuthorAndYear">A list of book objects to be searched</param>
        /// <param name="term">The search term to be used</param>
        /// <returns>Returns a list of book objects based on the result of the search</returns>
        public List<Book> SearchAuthorAndYear(List<Book> bookAuthorAndYear, string term)
        {
            // Create a new list of book objects called results
            List<Book> results = new List<Book>();
            // Using linq, do a query to search for the books which author and year property values are the same as the
            // search terms used, then store them into the list results
            results = bookAuthorAndYear.Where(book => (book.Author.ToString().ToLower() + " " + book.Year.ToString().ToLower()).Contains(term)).ToList();
            // Return the list of searched result
            return results;
        }      
    }
}
