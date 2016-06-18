using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace D201_OOP_Assignment
{
    /// <summary>
    /// Handles reading and writing from different file formats and populating the listbox
    /// with book objects as well as adding, deleting and editing of books
    /// </summary>
    class FileIO
    {
        // Create a new list of books called LoadBooks
        List<Book> LoadBooks = new List<Book>();

        #region SaveBooks
        /// <summary>
        /// Saves the book objects from a listbox as plain text to a text file.
        /// </summary>
        /// <param name="filename">Use a string parameter called filename and use it as
        /// filename when saving</param>
        /// <param name="lbxItems">Use a list of book objects as a parameter and use it
        /// for what texts to write on the text file</param>
        /// <returns>Void</returns>     
        public void SaveBooks(string filename, List<Book> lbxItems)
        {
            // Create a new stream writer object called sw to write on the file filename
            StreamWriter sw = new StreamWriter(filename);

            // Declare a new list of string called books to store the texts to write onto the file
            List<string> books = new List<string>();

            // for loop to loop through each book objects from the list lbxItems
            for (int i = 0; i < lbxItems.Count(); i++)
            {
                // if statement to check if the book at [i] is a physical book object, do the following code
                if (lbxItems[i] is PhysicalBook)
                {
                    // Cast the book at [i] to a physical book and call it n
                    PhysicalBook n = (PhysicalBook)lbxItems[i];
                    // Add to the list of string PB + the properties of physical book n separated by commas
                    books.Add("PB" + "," + n.Title + "," + n.Author + "," + n.Year.ToString() + "," + n.Weight + "," + n.PageCount);
                }

                // if statement to check if the book at [i] is an audio book object, do the following code
                else if (lbxItems[i] is AudioBook)
                {
                    // Cast the book at [i] to an audio book and call it n
                    AudioBook n = (AudioBook)lbxItems[i];
                    // Add to the list of string AB + the properties of audio book n separated by commas
                    books.Add("AB" + "," + n.Title + "," + n.Author + "," + n.Year.ToString() + "," + n.FileSize + "," + n.Length + "," + n.Narrator);
                }
                // if statement to check if the book at [i] is an e book object, do the following code
                else if (lbxItems[i] is EBook)
                {
                    // Cast the book at [i] to an e book and call it n
                    EBook n = (EBook)lbxItems[i];
                    // Add to the list of string EB + the properties of e book n separated by commas
                    books.Add("EB" + "," + n.Title + "," + n.Author + "," + n.Year.ToString() + "," + n.FileSize + "," + n.FileFormat + "," + n.PageCount);                   
                }         
            }
            // foreach loop to loop through each string in the list of strings called books
            foreach (string n in books)
            {
                // Write onto the text file the string contained in n
                sw.WriteLine(n);
            }
            
            // Close the stream writer
            sw.Dispose();
        }
        #endregion

        #region SaveAsHtml
        /// <summary>
        /// Saves the book objects from a listbox as plain text to a html file.
        /// </summary>
        /// <param name="booksToSave">Use a list of book objects as parameter and use it
        /// for what texts to write on the html file</param>
        /// <param name="filename">Use a string parameter called filename and use it as
        /// filename when saving</param>
        /// <returns>Void</returns>
        public void SaveAsHTML(List<Book> booksToSave, string filename)
        {
            // Create a new stream writer object called sw to write on the file filename and add .html to the end
            StreamWriter sw = new StreamWriter(filename);

            // Declare a new list of string called books to store the texts to write onto the file
            List<string> books = new List<string>();

            // for loop to loop through each book objects from the list booksToSave
            for (int i = 0; i < booksToSave.Count(); i++)
            {
                // if statement to check if the book at [i] is a physical book object, do the following code
                if (booksToSave[i] is PhysicalBook)
                {
                    // Cast the book at [i] to a physical book and call it n
                    PhysicalBook n = (PhysicalBook)booksToSave[i];
                    // Add to the list of string PB + the properties of physical book n separated by commas
                    books.Add("PB" + "," + n.Title + "," + n.Author + "," + n.Year.ToString() + "," + n.Weight + "," + n.PageCount);
                }
                // if statement to check if the book at [i] is an audio book object, do the following code
                else if (booksToSave[i] is AudioBook)
                {
                    // Cast the book at [i] to an audio book and call it n
                    AudioBook n = (AudioBook)booksToSave[i];
                    // Add to the list of string AB + the properties of audio book n separated by commas
                    books.Add("AB" + "," + n.Title + "," + n.Author + "," + n.Year.ToString() + "," + n.FileSize + "," + n.Length + "," + n.Narrator);
                }
                // if statement to check if the book at [i] is an e book object, do the following code
                else if (booksToSave[i] is EBook)
                {
                    // Cast the book at [i] to an e book and call it n
                    EBook n = (EBook)booksToSave[i];
                    // Add to the list of string EB + the properties of e book n separated by commas
                    books.Add("EB" + "," + n.Title + "," + n.Author + "," + n.Year.ToString() + "," + n.FileSize + "," + n.FileFormat + "," + n.PageCount);
                }
            }

            // Write the word <html> to the file
            sw.WriteLine("<html>");
            // Write the word <head><title> </title></head> to the file
            sw.WriteLine("<head><title> </title></head>");
            // Write the word <body> to the file
            sw.WriteLine("<body>");

            //foreach loop to loop through each string in books and name it n
            foreach (string n in books)
            {
                // Write onto the file the string stored in n
                sw.WriteLine(n);
                // Write the word <br> to the file
                sw.WriteLine("<br>");
            }
            // Write the word </body> to the file
            sw.WriteLine("</body>");
            // Write the word </html> to the file
            sw.WriteLine("</html>");
            // Close the stream writer
            sw.Dispose();
        }
        #endregion

        #region SaveAsDatFile and LoadFromDat
        /// <summary>
        /// Handles saving a serialized list of book objects to a dat file
        /// </summary>
        /// <param name="booksToSave">List of book objects to be saved into the file</param>
        /// <param name="filename">FileName of the file to be saved</param>
        public void SaveAsDatFile(List<Book> booksToSave, string filename)
        {
            // Create a new binaryformatter class called bFormatter
            BinaryFormatter bFormatter = new BinaryFormatter();

            // Create a new filestream class, pass in the value of string filename as filename, 
            // create the file, then write onto the file with fileshare option set to none
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);

            // Use the serialize method to serialize the list of books and write onto the file
            bFormatter.Serialize(fs, booksToSave);
            
            // Close the filestream
            fs.Close();
        }

        /// <summary>
        /// Handles loading a serialized list of book objects from a dat file
        /// </summary>
        /// <param name="fileName">FileName of the file to be loaded</param>
        /// <returns>Returns a list of book objects read from the dat file</returns>
        public List<Book> LoadFromDat(string fileName)
        {
            // Create a new binaryformatter class called bFormatter
            BinaryFormatter bFormatter = new BinaryFormatter();

            // Create a new filestream class, pass in the value of string filename as filename, 
            // open and read the file, set the fileshare option to none
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);

            // Use the deserialize method to deserialize the list of books
            // then put them to LoadBooks
            LoadBooks = (List<Book>)bFormatter.Deserialize(fs);

            // Close the filestream
            fs.Close();

            // Return the loaded list of books from the dat file
            return LoadBooks;
        }
        #endregion

        #region SaveAsXML and LoadFromXML
        /// <summary>
        /// Handles saving a serialized list of book objects to a xml file
        /// </summary>
        /// <param name="booksToSave">List of book objects to be saved into the file</param>
        /// <param name="filename">FileName of the file to be saved</param>
        public void SaveAsXML(List<Book> booksToSave, string filename)
        {
            // Create a new xmlserializer class, set the type based on the type of List<Book>
            XmlSerializer xFormatter = new XmlSerializer(typeof(List<Book>));

            // Create a new filestream class, pass in the value of string filename as filename, 
            // create the file, then write onto the file with fileshare option set to none
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);

            // Use the serialize method to serialize the list of books and write onto the file
            xFormatter.Serialize(fs, booksToSave);

            // Close the filestream
            fs.Close();
        }

        /// <summary>
        /// Handles loading a serialized list of book objects from a xml file
        /// </summary>
        /// <param name="fileName">FileName of the file to be loaded</param>
        /// <returns>Returns a list of book objects read from the xml file</returns>
        public List<Book> LoadFromXML(string fileName)
        {
            // Create a new xmlserializer class, set the type based on the type of List<Book>
            XmlSerializer xFormatter = new XmlSerializer(typeof(List<Book>));

            // Create a new filestream class, pass in the value of string filename as filename, 
            // open and read the file, set the fileshare option to none
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);

            // Use the deserialize method to deserialize the list of books
            // then put them to LoadBooks
            LoadBooks = (List<Book>)xFormatter.Deserialize(fs);

            // Close the filestream
            fs.Close();

            // Return the loaded list of books from the dat file
            return LoadBooks;
        }
        #endregion

        #region SaveAsSoap and LoadFromSoap
        /// <summary>
        /// Handles saving a serialized list of book objects to a SOAP xml file
        /// </summary>
        /// <param name="booksToSave">List of book objects to be saved into the file</param>
        /// <param name="filename">FileName of the file to be saved</param>
        public void SaveAsSOAP(List<Book> booksToSave, string fileName)
        {
            // Create a new soapformatter class called sFormatter
            SoapFormatter sFormatter = new SoapFormatter();

            // Create a new filestream class, pass in the value of string filename as filename, 
            // create the file, then write onto the file with fileshare option set to none
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);

            // Use the serialize method to serialize the list of books and write onto the file
            sFormatter.Serialize(fs, booksToSave.ToArray());

            // Close the filestream
            fs.Close();
        }

        /// <summary>
        /// Handles loading a serialized list of book objects from a SOAP xml file
        /// </summary>
        /// <param name="fileName">FileName of the file to be loaded</param>
        /// <returns>Returns a list of book objects read from the SOAP xml file</returns>
        public List<Book> LoadFromSOAP(string fileName)
        {
            // Create a new soapformatter class called sFormatter
            SoapFormatter sFormatter = new SoapFormatter();

            // Create a new filestream class, pass in the value of string filename as filename, 
            // open and read the file, set the fileshare option to none
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);

            // Deserialize the book array stored in the file
            // then add them to the list of books LoadBooks
            LoadBooks.AddRange((Book[])sFormatter.Deserialize(fs));

            // Close the filestream
            fs.Close();

            // Return a list of books read from the SOAP xml file
            return LoadBooks;
        }
        #endregion

        #region OpenFile
        /// <summary>
        /// Handles the opening of an external file, read what is stored and pass it through as a list of book objects
        /// </summary>
        /// <param name="filename">Uses a string called filename as parameter</param>
        /// <returns>Returns a list of book objects</returns>
        public List<Book> OpenFile(string filename)
        {
            // Declare a new list of book objects called ListAll
            List<Book> ListAll = new List<Book>();
            // Declare a new stream reader object called sr and read from a file which filename is stored in the filename variable
            StreamReader sr = new StreamReader(filename);
            // While loop read each line of text from the file
            while (!sr.EndOfStream)
            {
                // Store the read line of text to a string called bookInfo
                string bookInfo = sr.ReadLine();

                // Split the text stored in bookInfo where there are commas and store each into a string array
                string[] bookVals = bookInfo.Split(',');

                // try catch block to prevent crashing
                try
                {
                    // if statement to check if the string stored in bookVals[0] is the word PB, do the following code
                    if (bookVals[0] == "PB")
                    {
                        // Declare a new physical book object and call it newPhysicalBook
                        PhysicalBook newPhysicalBook = new PhysicalBook();
                        // Use the string stored at bookVals[1] as title property of newPhysicalBook
                        newPhysicalBook.Title = bookVals[1];
                        // Use the string stored at bookVals[2] as author property of newPhysicalBook
                        newPhysicalBook.Author = bookVals[2];
                        // Use the string stored at bookVals[3], convert in into an int and use it as year property of newPhysicalBook
                        newPhysicalBook.Year = int.Parse(bookVals[3]);
                        // Use the string stored at bookVals[4] as weight property of newPhysicalBook
                        newPhysicalBook.Weight = bookVals[4];
                        // Use the string stored at bookVals[5], convert in into an int and use it as pagecount property of newPhysicalBook
                        newPhysicalBook.PageCount = int.Parse(bookVals[5]);
                        // Add to the list of books the newly created physical book
                        ListAll.Add(newPhysicalBook);
                    }
                    // if statement to check if the string stored in bookVals[0] is the word EB, do the following code
                    else if (bookVals[0] == "EB")
                    {
                        // Declare a new e book object and call it newEBook
                        EBook newEBook = new EBook();
                        // Use the string stored at bookVals[1] as title property of newEBook
                        newEBook.Title = bookVals[1];
                        // Use the string stored at bookVals[1] as author property of newEBook
                        newEBook.Author = bookVals[2];
                        // Use the string stored at bookVals[3], convert in into an int and use it as year property of newEBook
                        newEBook.Year = int.Parse(bookVals[3]);
                        // Use the string stored at bookVals[4] as filesize property of newEBook
                        newEBook.FileSize = bookVals[4];
                        // Use the string stored at bookVals[5] as fileformat property of newEBook
                        newEBook.FileFormat = bookVals[5];
                        // Use the string stored at bookVals[6], convert in into an int and use it as pagecount property of newEBook
                        newEBook.PageCount = int.Parse(bookVals[6]);
                        // Add to the list of books the newly created e book
                        ListAll.Add(newEBook);
                    }
                    else if (bookVals[0] == "AB")
                    {
                        // Declare a new physical book object and call it newAudioBook
                        AudioBook newAudioBook = new AudioBook();
                        // Use the string stored at bookVals[1] as title property of newAudioBook
                        newAudioBook.Title = bookVals[1];
                        // Use the string stored at bookVals[2] as title property of newAudioBook
                        newAudioBook.Author = bookVals[2];
                        // Use the string stored at bookVals[3], convert in into an int and use it as year property of newAudioBook
                        newAudioBook.Year = int.Parse(bookVals[3]);
                        // Use the string stored at bookVals[4] as filesize property of newAudioBook
                        newAudioBook.FileSize = bookVals[4];
                        // Use the string stored at bookVals[5] as length property of newAudioBook
                        newAudioBook.Length = bookVals[5];
                        // Use the string stored at bookVals[6] as narrator property of newAudioBook
                        newAudioBook.Narrator = bookVals[6];
                        // Add to the list of books the newly created audio book
                        ListAll.Add(newAudioBook);
                    }
                }
                // Catch if code in try has errors
                catch
                {
                    // Show a messagebox
                    MessageBox.Show("lolwut");
                }
            }
            // Close the stream reader
            sr.Dispose();

            // Return ListAll, which is a list of book objects populated by the information stored within the file
            return ListAll;
        }

        /// <summary>
        /// Handles opening a html file to the default browser
        /// </summary>
        /// <param name="fileName">Uses a string called filename as parameter, used as the filename of the file to be opened</param>
        /// <returns>Void</returns>
        public void OpenExternalFile(string fileName)
        {
            // Open the file with the filename stored in the string filename
            Process.Start(fileName);
        }
        #endregion

        #region DeleteBook
        /// <summary>
        /// Handles the deleting of book objects from the list of books then remove them from all the data sources
        /// </summary>
        /// <param name="fileName">Uses a string called filename as parameter, used as the filename of the file to be edited</param>
        /// <param name="books">Use a list of book objects as parameter, use it as updated list of books to be saved onto the file</param>
        public void DeleteBook(string fileName, List<Book> books)
        {
            // Remove the last 3 characters of fileName then store it to string variable extension
            string extension = fileName.Substring(fileName.Length - 3);

            // If extension is txt, do the following
            if (extension == "txt")
            {
                // Call the savebooks method to overwrite the textfile using the edited list of books
                SaveBooks(fileName, books);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "html" to fileName
                fileName = fileName + "html";
                // Call the saveashtml method to overwrite the html file using the edited list of books
                SaveAsHTML(books, fileName);

                // Remove the last 4 characters of fileName
                fileName = fileName.Remove(fileName.Length - 4);
                // Concatenate string literal "dat" to fileName
                fileName = fileName + "dat";
                // Call the saveasdat method to overwrite the dat file using the edited list of books
                SaveAsDatFile(books, fileName);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "xml" to fileName
                fileName = fileName + "xml";
                // Call the saveassoap method to overwrite the xml file using the edited list of books
                SaveAsSOAP(books, fileName);

                // Call the saveasxml method to overwrite the html file using the edited list of books
                SaveAsXML(books, fileName);
            }
            // If extension is tml, do the following
            else if (extension == "tml")
            {
                // Call the saveashtml method to overwrite the html file using the edited list of books
                SaveAsHTML(books, fileName);

                // Remove the last 4 characters of fileName
                fileName = fileName.Remove(fileName.Length - 4);
                // Concatenate string literal "txt" to fileName
                fileName = fileName + "txt";
                // Call the savebooks method to overwrite the textfile using the edited list of books
                SaveBooks(fileName, books);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "dat" to fileName
                fileName = fileName + "dat";
                // Call the saveasdat method to overwrite the dat file using the edited list of books
                SaveAsDatFile(books, fileName);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "xml" to fileName
                fileName = fileName + "xml";
                // Call the saveassoap method to overwrite the xml file using the edited list of books
                SaveAsSOAP(books, fileName);
                // Call the saveasxml method to overwrite the html file using the edited list of books
                SaveAsXML(books, fileName);
            }

            // If extension is tml, do the following
            else if (extension == "dat")
            {
                // Call the saveasdat method to overwrite the dat file using the edited list of books
                SaveAsDatFile(books, fileName);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "txt" to fileName
                fileName = fileName + "txt";
                // Call the savebooks method to overwrite the textfile using the edited list of books
                SaveBooks(fileName, books);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "html" to fileName
                fileName = fileName + "html";
                // Call the saveashtml method to overwrite the html file using the edited list of books
                SaveAsHTML(books, fileName);

                // Remove the last 4 characters of fileName
                fileName = fileName.Remove(fileName.Length - 4);
                // Concatenate string literal "xml" to fileName
                fileName = fileName + "xml";
                // Call the saveassoap method to overwrite the xml file using the edited list of books
                SaveAsSOAP(books, fileName);
                // Call the saveasxml method to overwrite the html file using the edited list of books
                SaveAsXML(books, fileName);
            }        

            // If extension is xml, do the following
            else if (extension =="xml")
            {
                // Call the saveassoap method to overwrite the xml file using the edited list of books
                SaveAsSOAP(books, fileName);
                // Call the saveasxml method to overwrite the html file using the edited list of books
                SaveAsXML(books, fileName);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "txt" to fileName
                fileName = fileName + "txt";
                // Call the savebooks method to overwrite the textfile using the edited list of books
                SaveBooks(fileName, books);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "html" to fileName
                fileName = fileName + "html";
                // Call the saveashtml method to overwrite the html file using the edited list of books
                SaveAsHTML(books, fileName);

                // Remove the last 4 characters of fileName
                fileName = fileName.Remove(fileName.Length - 4);
                // Concatenate string literal "dat" to fileName
                fileName = fileName + "dat";
                // Call the saveasdat method to overwrite the dat file using the edited list of books
                SaveAsDatFile(books, fileName);
            }                
        }
        #endregion

        #region AddBook
        /// <summary>
        /// Handles adding a new book to the list of books then add them to all the data sources
        /// </summary>
        /// <param name="fileName">Uses a string called filename as parameter, used as the filename of the file to be edited</param>
        /// <param name="books">Use a list of book objects as parameter, use it as updated list of books to be saved onto the file</param>
        public void AddBook(string fileName, List<Book> books)
        {
            // Remove the last 3 characters of fileName then store it to string variable extension
            string extension = fileName.Substring(fileName.Length - 3);

            // If extension is txt, do the following
            if (extension == "txt")
            {
                // Call the savebooks method to overwrite the textfile using the edited list of books
                SaveBooks(fileName, books);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "html" to fileName
                fileName = fileName + "html";
                // Call the saveashtml method to overwrite the html file using the edited list of books
                SaveAsHTML(books, fileName);

                // Remove the last 4 characters of fileName
                fileName = fileName.Remove(fileName.Length - 4);
                // Concatenate string literal "dat" to fileName
                fileName = fileName + "dat";
                // Call the saveasdat method to overwrite the dat file using the edited list of books
                SaveAsDatFile(books, fileName);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "xml" to fileName
                fileName = fileName + "xml";
                // Call the saveassoap method to overwrite the xml file using the edited list of books
                SaveAsSOAP(books, fileName);
            }
            // If extension is tml, do the following
            else if (extension == "tml")
            {
                // Call the saveashtml method to overwrite the html file using the edited list of books
                SaveAsHTML(books, fileName);

                // Remove the last 4 characters of fileName
                fileName = fileName.Remove(fileName.Length - 4);
                // Concatenate string literal "txt" to fileName
                fileName = fileName + "txt";
                // Call the savebooks method to overwrite the textfile using the edited list of books
                SaveBooks(fileName, books);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "dat" to fileName
                fileName = fileName + "dat";
                // Call the saveasdat method to overwrite the dat file using the edited list of books
                SaveAsDatFile(books, fileName);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "xml" to fileName
                fileName = fileName + "xml";
                // Call the saveassoap method to overwrite the xml file using the edited list of books
                SaveAsSOAP(books, fileName);
            }

            // If extension is tml, do the following
            else if (extension == "dat")
            {
                // Call the saveasdat method to overwrite the dat file using the edited list of books
                SaveAsDatFile(books, fileName);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "txt" to fileName
                fileName = fileName + "txt";
                // Call the savebooks method to overwrite the textfile using the edited list of books
                SaveBooks(fileName, books);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "html" to fileName
                fileName = fileName + "html";
                // Call the saveashtml method to overwrite the html file using the edited list of books
                SaveAsHTML(books, fileName);

                // Remove the last 4 characters of fileName
                fileName = fileName.Remove(fileName.Length - 4);
                // Concatenate string literal "xml" to fileName
                fileName = fileName + "xml";
                // Call the saveassoap method to overwrite the xml file using the edited list of books
                SaveAsSOAP(books, fileName);
            }

            // If extension is xml, do the following
            else if (extension == "xml")
            {
                // Call the saveassoap method to overwrite the xml file using the edited list of books
                SaveAsSOAP(books, fileName);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "txt" to fileName
                fileName = fileName + "txt";
                // Call the savebooks method to overwrite the textfile using the edited list of books
                SaveBooks(fileName, books);

                // Remove the last 3 characters of fileName
                fileName = fileName.Remove(fileName.Length - 3);
                // Concatenate string literal "html" to fileName
                fileName = fileName + "html";
                // Call the saveashtml method to overwrite the html file using the edited list of books
                SaveAsHTML(books, fileName);

                // Remove the last 4 characters of fileName
                fileName = fileName.Remove(fileName.Length - 4);
                // Concatenate string literal "dat" to fileName
                fileName = fileName + "dat";
                // Call the saveasdat method to overwrite the dat file using the edited list of books
                SaveAsDatFile(books, fileName);
            }
        }
        #endregion

        #region EditBook

        #endregion
    }
}        
    

