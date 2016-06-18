using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D201_OOP_Assignment
{
    /// <summary>
    /// Handles the sorting of the list by their property either ascending or descending depending on
    /// which radio buttons are checked.
    /// </summary>
    class Sorter
    {
        /// <summary>
        /// Sorts the list by title either ascending or descending.
        /// </summary>
        /// <param name="allBooks">Uses a list of book objects as parameter, used as the list to be sorted</param>
        /// <param name="order">Uses a string as parameter, sorts the list ascending if equals to "a", and descending
        /// if equals to "d".</param>
        /// <returns>Returns a sorted list of book objects either A-Z or Z-A.</returns>
        public List<Book> SortTitle(List<Book> allBooks, string order)
        {
            // If statement to check if string stored in order is "a", do the following
            if (order == "a")
            {
                // Arrange the books in allBooks list by their title property A-Z.
                allBooks = (from n in allBooks orderby n.Title select n).ToList();
                
            }
            // If statement to check if string stored in order is "d", do the following
            else if (order == "d")
            {
                // Arrange the books in allBooks list by their title property Z-A.
                allBooks = (from n in allBooks orderby n.Title descending select n).ToList();               
            }

            // Return the sorted list of books.
            return allBooks;
        }

        /// <summary>
        /// Sorts the list by author either ascending or descending.
        /// </summary>
        /// <param name="allBooks">Uses a list of book objects as parameter, used as the list to be sorted</param>
        /// <param name="order">Uses a string as parameter, sorts the list ascending if equals to "a", and descending
        /// if equals to "d".</param>
        /// <returns>Returns a sorted list of book objects either A-Z or Z-A.</returns>
        public List<Book> SortAuthor(List<Book> allBooks, string order)
        {
            // If statement to check if string stored in order is "a", do the following
            if (order == "a")
            {
                // Arrange the books in allBooks list by their author property A-Z.
                allBooks = (from n in allBooks orderby n.Author select n).ToList();
            }
            // If statement to check if string stored in order is "d", do the following
            else if (order == "d")
            {
                // Arrange the books in allBooks list by their author property Z-A.
                allBooks = (from n in allBooks orderby n.Author descending select n).ToList();               
            }
            // Return the sorted list of books.
            return allBooks;           
        }

        /// <summary>
        /// Sorts the list by year either ascending or descending.
        /// </summary>
        /// <param name="allBooks">Uses a list of book objects as parameter, used as the list to be sorted</param>
        /// <param name="order">Uses a string as parameter, sorts the list ascending if equals to "a", and descending
        /// if equals to "d".</param>
        /// <returns>Returns a sorted list of book objects either A-Z or Z-A.</returns>
        public List<Book> SortYear(List<Book> allBooks, string order)
        {
            // If statement to check if string stored in order is "a", do the following
            if (order == "a")
            {
                // Arrange the books in allBooks list by their year property A-Z.
                allBooks = (from n in allBooks orderby n.Year select n).ToList();
            }
            // If statement to check if string stored in order is "d", do the following
            else if (order == "d")
            {
                // Arrange the books in allBooks list by their year property Z-A.
                allBooks = (from n in allBooks orderby n.Year descending select n).ToList();
            }
            // Return the sorted list of books.
            return allBooks;
        }

        /// <summary>
        /// Sorts the list by weight either ascending or descending.
        /// </summary>
        /// <param name="allBooks">Uses a list of physical book objects as parameter, used as the list to be sorted</param>
        /// <param name="order">Uses a string as parameter, sorts the list ascending if equals to "a", and descending
        /// if equals to "d".</param>
        /// <returns>Returns a sorted list of physical book objects either A-Z or Z-A.</returns>
        public List<PhysicalBook> SortWeight(List<PhysicalBook> allBooks, string order)
        {
            // If statement to check if string stored in order is "a", do the following
            if (order == "a")
            {
                // Arrange the physical books in allBooks list by their weight property A-Z.
                allBooks = (from n in allBooks orderby n.Weight select n).ToList();
            }
            // If statement to check if string stored in order is "d", do the following
            else if (order == "d")
            {
                // Arrange the physical books in allBooks list by their weight property Z-A.
                allBooks = (from n in allBooks orderby n.Weight descending select n).ToList();
            }
            // Return the sorted list of physical books.
            return allBooks;
        }

        /// <summary>
        /// Sorts the list by fileformat either ascending or descending.
        /// </summary>
        /// <param name="allBooks">Uses a list of ebook objects as parameter, used as the list to be sorted</param>
        /// <param name="order">Uses a string as parameter, sorts the list ascending if equals to "a", and descending
        /// if equals to "d".</param>
        /// <returns>Returns a sorted list of ebook objects either A-Z or Z-A.</returns>
        public List<EBook> SortFileFormat(List<EBook> allBooks, string order)
        {
            // If statement to check if string stored in order is "a", do the following
            if (order == "a")
            {
                // Arrange the  ebooks in allBooks list by their fileformat property A-Z.
                allBooks = (from n in allBooks orderby n.FileFormat select n).ToList();
            }
            // If statement to check if string stored in order is "d", do the following
            else if (order == "d")
            {
                // Arrange the  ebooks in allBooks list by their fileformat property Z-A.
                allBooks = (from n in allBooks orderby n.FileFormat descending select n).ToList();
            }
            // Return the sorted list of ebooks.
            return allBooks;
        }

        /// <summary>
        /// Sorts the list by filesize either ascending or descending.
        /// </summary>
        /// <param name="allBooks">Uses a list of ebook objects as parameter, used as the list to be sorted</param>
        /// <param name="order">Uses a string as parameter, sorts the list ascending if equals to "a", and descending
        /// if equals to "d".</param>
        /// <returns>Returns a sorted list of ebook objects either A-Z or Z-A.</returns>
        public List<EBook> SortFileSize(List<EBook> allBooks, string order)
        {
            // If statement to check if string stored in order is "a", do the following
            if (order == "a")
            {
                // Arrange the  ebooks in allBooks list by their filesize property A-Z.
                allBooks = (from n in allBooks orderby n.FileSize select n).ToList();
            }
            // If statement to check if string stored in order is "d", do the following
            else if (order == "d")
            {
                // Arrange the  ebooks in allBooks list by their filesize property Z-A.
                allBooks = (from n in allBooks orderby n.FileSize descending select n).ToList();
            }
            // Return the sorted list of ebooks.
            return allBooks;
        }

        /// <summary>
        /// Sorts the list by length either ascending or descending.
        /// </summary>
        /// <param name="allBooks">Uses a list of audio book objects as parameter, used as the list to be sorted</param>
        /// <param name="order">Uses a string as parameter, sorts the list ascending if equals to "a", and descending
        /// if equals to "d".</param>
        /// <returns>Returns a sorted list of audio book objects either A-Z or Z-A.</returns>
        public List<AudioBook> SortLength(List<AudioBook> allBooks, string order)
        {
            // If statement to check if string stored in order is "a", do the following
            if (order == "a")
            {
                // Arrange the  audio books in allBooks list by their filesize property A-Z.
                allBooks = (from n in allBooks orderby n.Length select n).ToList();
            }
            // If statement to check if string stored in order is "d", do the following
            else if (order == "d")
            {
                // Arrange the  audio books in allBooks list by their filesize property Z-A.
                allBooks = (from n in allBooks orderby n.Length descending select n).ToList();
            }
            // Return the sorted list of audio books.
            return allBooks;
        }

        /// <summary>
        /// Sorts the list by narrator either ascending or descending.
        /// </summary>
        /// <param name="allBooks">Uses a list of audio book objects as parameter, used as the list to be sorted</param>
        /// <param name="order">Uses a string as parameter, sorts the list ascending if equals to "a", and descending
        /// if equals to "d".</param>
        /// <returns>Returns a sorted list of audio book objects either A-Z or Z-A.</returns>
        public List<AudioBook> SortNarrator(List<AudioBook> allBooks, string order)
        {
            // If statement to check if string stored in order is "a", do the following
            if (order == "a")
            {
                // Arrange the  audio books in allBooks list by their narrator property A-Z.
                allBooks = (from n in allBooks orderby n.Narrator select n).ToList();
            }
            // If statement to check if string stored in order is "d", do the following
            else if (order == "d")
            {
                // Arrange the  audio books in allBooks list by their narrator property Z-A.
                allBooks = (from n in allBooks orderby n.Narrator descending select n).ToList();
            }
            // Return the sorted list of audio books.
            return allBooks;
        }

        /// <summary>
        /// Sorts the list by pagecount either ascending or descending.
        /// </summary>
        /// <param name="allBooks">Uses a list of book objects as parameter, used as the list to be sorted</param>
        /// <param name="order">Uses a string as parameter, sorts the list ascending if equals to "a", and descending
        /// if equals to "d".</param>
        /// <returns>Returns a sorted list of book objects either A-Z or Z-A.</returns>
        public List<Book> SortPageCount(List<PhysicalBook> pBooks, List<EBook> eBooks, string order)
        {
            // Create a new list of IPageCount objects called PageCountList
            List<IPageCount> PageCountList = new List<IPageCount>();

            // Loop through each physical book stored in pBooks
            foreach (PhysicalBook n in pBooks)
            {
                // Add the physical book to the list PageCountList
                PageCountList.Add(n);
            }
            // Loop through each ebook stored in pBooks
            foreach (EBook n in eBooks)
            {
                // Add the ebook to the list PageCountList
                PageCountList.Add(n);
            }

            // If statement to check if string stored in order is "a", do the following
            if (order == "a")
            {
                // Arrange the IPageCount objects in PageCountList list by their pagecount property A-Z.
                PageCountList = (from n in PageCountList orderby n.PageCount select n).ToList();
            }
            // If statement to check if string stored in order is "d", do the following
            else if (order == "d")
            {
                // Arrange the IPageCount objects in PageCountList list by their pagecount property Z-A.
                PageCountList = (from n in PageCountList orderby n.PageCount descending select n).ToList();               
            }

            // Create a new list of book objects called SortedList
            List<Book> SortedList = new List<Book>();

            // Loop through each book objects in PageCountList
            foreach (Book n in PageCountList)
            {
                // Add the book to the list SortedList
                SortedList.Add(n);
            }
            // Return the sorted list of books.
            return SortedList;
        }

    }
}
