using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace D201_OOP_Assignment
{
    public partial class Form1 : Form
    {
        // Declare a list of book objects called allBooks
        List<Book> allBooks;
        // Declare a list of physical book objects called physicalBooks
        List<PhysicalBook> physicalBooks;
        // Declare a list of e book objects called eBooks
        List<EBook> eBooks;
        // Declare a list of audio book objects called audioBooks
        List<AudioBook> audioBooks;
        // Declare a list of string called saveBooks
        List<string> saveBooks;
        // Declare a list of book objects called searchResult
        List<Book> searchResult;
        // Declare a list of physical book objects called searchPResult
        List<PhysicalBook> searchPResult;
      
        public Form1()
        {
            InitializeComponent();

            // Initialize a new list of book objects and store into allBooks
            allBooks = new List<Book>();
            // Initialize a new list of physical book objects and store into searchPResult
            searchPResult = new List<PhysicalBook>();
            // Initialize a new list of physical book objects and store into physicalBooks
            physicalBooks = new List<PhysicalBook>();
            // Initialize a new list of e book objects and store into eBooks
            eBooks = new List<EBook>();
            // Initialize a new list of audio book objects and store into audioBooks
            audioBooks = new List<AudioBook>();
            // Initialize a new list of string and store into saveBooks
            saveBooks = new List<string>();
        }
        

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            // Create a new OpenFileDialog class called openFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Use the method ShowDialog() to pop up an open file dialog window
            openFileDialog.ShowDialog();
            // Create a new FileIO class caled fm
            FileIO fm = new FileIO();

            // Get the extension of the file selected from the openfiledialog
            // then store it into a string
            string path = Path.GetExtension(openFileDialog.FileName);

            // If the extension is .dat
            if (path == ".dat")
            {
                // Use the FileIO method LoadFromDat and use the filename of the file selected from the openFileDialog
                // then store it into the list of books
                allBooks = fm.LoadFromDat(openFileDialog.FileName);
            }
            // If the extension is .txt
            else if (path == ".txt")
            {
                // Use the FileIO method OpenFile and use the filename of the file selected from the openFileDialog
                // then store it into the list of books
                allBooks = fm.OpenFile(openFileDialog.FileName);
            }
            // If the extension is .html
            else if (path == ".html")
            {
                // Use the FileIO method OpenFile and use the filename of the file selected from the openFileDialog
                // then store it into the list of books
                allBooks = fm.OpenFile(openFileDialog.FileName);
            }
            // If the extension is .xml
            else if (path == ".xml")
            {
                //allBooks = fm.LoadFromXML(openFileDialog.FileName);

                // Use the FileIO method LoadFromSOAP and use the filename of the file selected from the openFileDialog
                // then store it into the list of books
                allBooks = fm.LoadFromSOAP(openFileDialog.FileName);                                
            }
            
            // Store the filename of the file opened into the textbox
            tbxName.Text = openFileDialog.FileName;
            // Empty the list items of lbxInformation
            lbxInformation.Items.Clear();
            // Add to the listbox the list of book objects allBooks converted to array
            lbxInformation.Items.AddRange(allBooks.ToArray());

            // Foreach loop to loop through each book objects in allbooks
            foreach (Book n in allBooks)
            {
                // If the book is a physical book
                if (n is PhysicalBook)
                {
                    // Cast the book into a physical book
                    PhysicalBook pBook = (PhysicalBook)n;
                    // Add to the list of physical books
                    physicalBooks.Add(pBook);
                }
                // If the book is a e book
                else if (n is EBook)
                {
                    // Cast the book into an e book
                    EBook eBook = (EBook)n;
                    // Add to the list of e books
                    eBooks.Add(eBook);
                }
                // If the book is a audio book
                else if (n is AudioBook)
                {
                    // Cast the book into an audio book
                    AudioBook audioBook = (AudioBook)n;
                    // Add to the list of audio books
                    audioBooks.Add(audioBook);
                }
            }       
        }       

        private void btnAllBooks_Click(object sender, EventArgs e)
        {
            // Empty the list items of lbxInformation
            lbxInformation.Items.Clear();
            // Add to the listbox the list of book objects allBooks converted to array
            lbxInformation.Items.AddRange(allBooks.ToArray());
        }
        private void btnPhysicalBooks_Click(object sender, EventArgs e)
        {
            // Empty the list items of lbxInformation
            lbxInformation.Items.Clear();
            // Add to the listbox the list of physical book objects physicalBooks converted to array
            lbxInformation.Items.AddRange(physicalBooks.ToArray());
        }
        private void btnEBooks_Click(object sender, EventArgs e)
        {
            // Empty the list items of lbxInformation
            lbxInformation.Items.Clear();
            // Add to the listbox the list of e book objects eBooks converted to array
            lbxInformation.Items.AddRange(eBooks.ToArray());
        }

        private void btnAudioBooks_Click(object sender, EventArgs e)
        {
            // Empty the list items of lbxInformation
            lbxInformation.Items.Clear();
            // Add to the listbox the list of audio book  objects audioBooks converted to array
            lbxInformation.Items.AddRange(audioBooks.ToArray());
        }

        private void btnMoreInformation_Click(object sender, EventArgs e)
        {
            // Clear the text of all textboxes
            tbxTitle.Clear();
            tbxAuthor.Clear();
            tbxYear.Clear();
            tbxWeight.Clear();
            tbxFileSize.Clear();
            tbxFileFormat.Clear();
            tbxLength.Clear();
            tbxNarrator.Clear();
            tbxPageCount.Clear();

            // If the selected item on the listbox is an audio book
            if (lbxInformation.SelectedItem is AudioBook)
            {
                // Cast the selected item into an audio book, call it item
                AudioBook item = (AudioBook)lbxInformation.SelectedItem;
                // Store the title property of item to the textbox tbxTitle
                tbxTitle.Text = item.Title;
                // Store the author property of item to the textbox tbxAuthor
                tbxAuthor.Text = item.Author;
                // Store the year property of item, converted to a string, to the textbox tbxYear
                tbxYear.Text = item.Year.ToString();
                // Store the filesize property of item to the textbox tbxFileSize
                tbxFileSize.Text = item.FileSize;
                // Store the length property of item to the textbox tbxLength
                tbxLength.Text = item.Length;
                // Store the narrator property of item to the textbox tbxNarrator
                tbxNarrator.Text = item.Narrator;
            }
            // If the selected item on the listbox is an e book
            else if (lbxInformation.SelectedItem is EBook)
            {
                // Cast the selected item into an e book, call it item
                EBook item = (EBook)lbxInformation.SelectedItem;
                // Store the title property of item to the textbox tbxTitle
                tbxTitle.Text = item.Title;
                // Store the author property of item to the textbox tbxAuthor
                tbxAuthor.Text = item.Author;
                // Store the year property of item, converted to a string, to the textbox tbxYear
                tbxYear.Text = item.Year.ToString();
                // Store the filesize property of item to the textbox tbxFileSize
                tbxFileSize.Text = item.FileSize;
                // Store the fileformat property of item to the textbox tbxFileFormat
                tbxFileFormat.Text = item.FileFormat;
                // Store the pagecount property of item, converted to a string, to the textbox tbxPageCount
                tbxPageCount.Text = item.PageCount.ToString();
            }
            // If the selected item on the listbox is an physical book
            else if (lbxInformation.SelectedItem is PhysicalBook)
            {
                // Cast the selected item into a physical book, call it item
                PhysicalBook item = (PhysicalBook)lbxInformation.SelectedItem;
                // Store the title property of item to the textbox tbxTitle
                tbxTitle.Text = item.Title;
                // Store the author property of item to the textbox tbxAuthor
                tbxAuthor.Text = item.Author;
                // Store the year property of item, converted to a string, to the textbox tbxYear
                tbxYear.Text = item.Year.ToString();
                // Store the weight property of item to the textbox tbxWeight
                tbxWeight.Text = item.Weight;
                // Store the pagecount property of item, converted to a string, to the textbox tbxPageCount
                tbxPageCount.Text = item.PageCount.ToString();
            }         
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Create a new Searcher class, call it bookSearcher
            Searcher bookSearcher = new Searcher();
            // Convert the text in tbxSearchTerm to lower case then store into a string variable
            string searchTerm = tbxSearchTerm.Text.ToLower();
            // Use the SearchBook method using allBooks as the list of books to search
            // and searchTerm as the search term
            searchResult = bookSearcher.SearchBook(allBooks, searchTerm);
            // If nothing is returned using the method above, do the following
            if (searchResult.Count() == 0)
            {
                // Use the SearchTitleAndYear method using allBooks as the list of books to search
                // and searchTerm as the search term
                searchResult = bookSearcher.SearchTitleAndYear(allBooks, searchTerm);
            }
            // If nothing is returned using the method above, do the following
            else if (searchResult.Count() == 0)
            {// Use the SearchAuthorAndYear method using allBooks as the list of books to search
                // and searchTerm as the search term
                searchResult = bookSearcher.SearchAuthorAndYear(allBooks, searchTerm);
            }
            // Clear the items in the listbox lbxSearchResult
            lbxSearchResult.Items.Clear();
            // Add the list of books that has been searched into the listbox lbxSearchResult
            lbxSearchResult.Items.AddRange(searchResult.ToArray());
        }
        
        private void UpdateBooksListBox()
        {
            // Empty the list items of lbxInformation
            lbxInformation.Items.Clear();
            // Add to the listbox the list of book objects allBooks converted to array
            lbxInformation.Items.AddRange(allBooks.ToArray());
        }
        private void UpdatePhysicalBooksListBox()
        {
            // Empty the list items of lbxInformation
            lbxInformation.Items.Clear();
            // Add to the listbox the list of physical book objects physicalBooks converted to array
            lbxInformation.Items.AddRange(physicalBooks.ToArray());
        }
        private void UpdateEBooksListBox()
        {
            // Empty the list items of lbxInformation
            lbxInformation.Items.Clear();
            // Add to the listbox the list of e book objects eBooks converted to array
            lbxInformation.Items.AddRange(eBooks.ToArray());
        }
        private void UpdateAudioBooksListBox()
        {
            // Empty the list items of lbxInformation
            lbxInformation.Items.Clear();
            // Add to the listbox the list of audio book objects audioBooks converted to array
            lbxInformation.Items.AddRange(audioBooks.ToArray());
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            // Create a new sorter class called bookSorter
            Sorter bookSorter = new Sorter();
            // Declare a string variable called ascending to store "a"
            string ascending = "a";
            // Declare a string variable called descending to store "d"
            string descending = "d";

            // If statement to check if the radio button Title and Ascending is checked
            if (rdoTitle.Checked && rdoAscending.Checked == true)
            {
                // Sort the books stored in allbooks A-Z using the SortTitle method
                allBooks = bookSorter.SortTitle(allBooks, ascending);
                // Call the updatebookslistbox method
                UpdateBooksListBox();
            }
            // If statement to check if the radio button Title and Descending is checked
            else if (rdoTitle.Checked && rdoDescending.Checked == true)
            {
                // Sort the books stored in allbooks Z-A using the SortTitle method
                allBooks = bookSorter.SortTitle(allBooks, descending);
                // Call the updatebookslistbox method
                UpdateBooksListBox();
            }
            // If statement to check if the radio button Author and Ascending is checked
            else if (rdoAuthor.Checked && rdoAscending.Checked == true)
            {
                // Sort the books stored in allbooks A-Z using the SortAuthor method
                allBooks = bookSorter.SortAuthor(allBooks, ascending);
                // Call the updatebookslistbox method
                UpdateBooksListBox();
            }
            // If statement to check if the radio button Author and Descending is checked
            else if (rdoAuthor.Checked && rdoDescending.Checked == true)
            {
                // Sort the books stored in allbooks Z-A using the SortAuthor method
                allBooks = bookSorter.SortAuthor(allBooks, descending);
                // Call the updatebookslistbox method
                UpdateBooksListBox();
            }
            // If statement to check if the radio button Year and Ascending is checked
            else if (rdoYear.Checked && rdoAscending.Checked == true)
            {
                // Sort the books stored in allbooks A-Z using the SortYear method
                allBooks = bookSorter.SortYear(allBooks, ascending);
                // Call the updatebookslistbox method
                UpdateBooksListBox();
            }
            // If statement to check if the radio button Year and Descending is checked
            else if (rdoYear.Checked && rdoDescending.Checked == true)
            {
                // Sort the books stored in allbooks Z-A using the SortYear method
                allBooks = bookSorter.SortYear(allBooks, descending);
                // Call the updatebookslistbox method
                UpdateBooksListBox();
            }
            // If statement to check if the radio button Weight and Ascending is checked
            else if (rdoWeight.Checked && rdoAscending.Checked == true)
            {
                // Sort the physical books stored in physicalBooks A-Z using the SortWeight method
                physicalBooks = bookSorter.SortWeight(physicalBooks, ascending);
                // Call the UpdatePhysicalBooksListBox method
                UpdatePhysicalBooksListBox();
            }
            // If statement to check if the radio button Weight and Descending is checked
            else if (rdoWeight.Checked && rdoDescending.Checked == true)
            {
                // Sort the physical books stored in physicalBooks Z-A using the SortWeight method
                physicalBooks = bookSorter.SortWeight(physicalBooks, descending);
                // Call the UpdatePhysicalBooksListBox method
                UpdatePhysicalBooksListBox();
            }
            // If statement to check if the radio button File Size and Ascending is checked
            else if (rdoFileSize.Checked && rdoAscending.Checked == true)
            {
                // Sort the e books stored in eBooks A-Z using the SortFileSize method
                eBooks = bookSorter.SortFileSize(eBooks, ascending);
                // Call the UpdateEBooksListBox method
                UpdateEBooksListBox();
            }
            // If statement to check if the radio button File Size and Descending is checked
            else if (rdoFileSize.Checked && rdoDescending.Checked == true)
            {
                // Sort the e books stored in eBooks Z-A using the SortFileSize method
                eBooks = bookSorter.SortFileSize(eBooks, descending);
                // Call the UpdateEBooksListBox method
                UpdateEBooksListBox();
            }
            // If statement to check if the radio button File Format and Ascending is checked
            else if (rdoFileFormat.Checked && rdoAscending.Checked == true)
            {
                // Sort the e books stored in eBooks A-Z using the SortFileFormat method
                eBooks = bookSorter.SortFileFormat(eBooks, ascending);
                // Call the UpdateEBooksListBox method
                UpdateEBooksListBox();
            }
            // If statement to check if the radio button File Format and Descending is checked
            else if (rdoFileFormat.Checked && rdoDescending.Checked == true)
            {
                // Sort the e books stored in eBooks Z-A using the SortFileFormat method
                eBooks = bookSorter.SortFileFormat(eBooks, descending);
                // Call the UpdateEBooksListBox method
                UpdateEBooksListBox();
            }
            // If statement to check if the radio button Length and Ascending is checked
            else if (rdoLength.Checked && rdoAscending.Checked == true)
            {
                // Sort the audio books stored in audioBooks A-Z using the SortLength method
                audioBooks = bookSorter.SortLength(audioBooks, ascending);
                // Call the UpdateAudioBooksListBox method
                UpdateAudioBooksListBox();
            }
            // If statement to check if the radio button Length and Descending is checked
            else if (rdoLength.Checked && rdoDescending.Checked == true)
            {
                // Sort the audio books stored in audioBooks Z-A using the SortLength method
                audioBooks = bookSorter.SortLength(audioBooks, descending);
                // Call the UpdateAudioBooksListBox method
                UpdateAudioBooksListBox();
            }
            // If statement to check if the radio button Narrator and Ascending is checked
            else if (rdoNarrator.Checked && rdoAscending.Checked == true)
            {
                // Sort the audio books stored in audioBooks A-Z using the SortNarrator method
                audioBooks = bookSorter.SortNarrator(audioBooks, ascending);
                // Call the UpdateAudioBooksListBox method
                UpdateAudioBooksListBox();
            }
            // If statement to check if the radio button Narrator and Descending is checked
            else if (rdoNarrator.Checked && rdoDescending.Checked == true)
            {
                // Sort the audio books stored in audioBooks Z-A using the SortNarrator method
                audioBooks = bookSorter.SortNarrator(audioBooks, descending);
                // Call the UpdateAudioBooksListBox method
                UpdateAudioBooksListBox();
            }
            // If statement to check if the radio button Page Count and Ascending is checked
            else if (rdoPageCount.Checked && rdoAscending.Checked == true)
            {
                // Sort the physical books stored in physicalBooks and e books stored in eBooks
                // A-Z using the SortPageCount method, then store them into allbooks
                allBooks = bookSorter.SortPageCount(physicalBooks, eBooks, ascending);
                // Call the UpdateBooksListBox method
                UpdateBooksListBox();
            }
            // If statement to check if the radio button Page Count and Descending is checked
            else if (rdoPageCount.Checked && rdoDescending.Checked == true)
            {
                // Sort the physical books stored in physicalBooks and e books stored in eBooks
                // Z-A using the SortPageCount method, then store them into allbooks
                allBooks = bookSorter.SortPageCount(physicalBooks, eBooks, descending);
                // Call the UpdateBooksListBox method
                UpdateBooksListBox();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Create a new SaveFileDialog class, call it saveFile
            SaveFileDialog saveFile = new SaveFileDialog();
            // Set the DefaultExt property to "txt"
            saveFile.DefaultExt = "txt";
            // Automatically add the extension to the file
            saveFile.AddExtension = true;
            // Set the FileName property to the text stored in tbxName
            saveFile.FileName = tbxName.Text;
            // Pop up the save file dialog
            saveFile.ShowDialog();
            // Create a new FileIO, call it fm
            FileIO fm = new FileIO();
            //Use the SaveBooks method to save the books stored in allBooks into the file
            fm.SaveBooks(saveFile.FileName, allBooks);
        }

        private void btnSaveHTML_Click(object sender, EventArgs e)
        {
            // Create a new SaveFileDialog class, call it saveFile
            SaveFileDialog saveFile = new SaveFileDialog();
            // Set the DefaultExt property to "html"
            saveFile.DefaultExt = "html";
            // Automatically add the extension to the file
            saveFile.AddExtension = true;
            // Set the FileName property to the text stored in tbxName
            saveFile.FileName = tbxName.Text;
            // Pop up the save file dialog
            saveFile.ShowDialog();
            // Create a new FileIO, call it fm
            FileIO fm = new FileIO();
            //Use the SaveAsHTML method to save the books stored in allBooks into the file
            fm.SaveAsHTML(allBooks, saveFile.FileName);

            // Show a messagebox with a yes and no button after the SaveFileDialog
            DialogResult dr = MessageBox.Show("Would you like to view the file?", "Open file?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If statement, if the user clicked yes
            if (dr.Equals(DialogResult.Yes))
            {
                // Use the OpenExternalFile to open the file that has been saved
                fm.OpenExternalFile(saveFile.FileName);
            }
        }
        private void btnSaveAsDat_Click(object sender, EventArgs e)
        {
            // Create a new SaveFileDialog class, call it saveFile
            SaveFileDialog saveFile = new SaveFileDialog();
            // Set the DefaultExt property to "dat"
            saveFile.DefaultExt = "dat";
            // Automatically add the extension to the file
            saveFile.AddExtension = true;
            // Set the FileName property to the text stored in tbxName
            saveFile.FileName = tbxName.Text;
            // Pop up the save file dialog
            saveFile.ShowDialog();
            // Create a new FileIO, call it fm
            FileIO fm = new FileIO();
            //Use the SaveAsDatFile method to save the books stored in allBooks into the file
            fm.SaveAsDatFile(allBooks, saveFile.FileName);
        }

        private void btnSaveAsXML_Click(object sender, EventArgs e)
        {
            // Create a new SaveFileDialog class, call it saveFile
            SaveFileDialog saveFile = new SaveFileDialog();
            // Set the DefaultExt property to "xml"
            saveFile.DefaultExt = "xml";
            // Automatically add the extension to the file
            saveFile.AddExtension = true;
            // Set the FileName property to the text stored in tbxName
            saveFile.FileName = tbxName.Text;
            // Pop up the save file dialog
            saveFile.ShowDialog();
            // Create a new FileIO, call it fm
            FileIO fm = new FileIO();
            //Use the SaveAsXML method to save the books stored in allBooks into the file
            //fm.SaveAsXML(allBooks, saveFile.FileName);
        }

        private void btnSaveAsSOAP_Click(object sender, EventArgs e)
        {
            // Create a new SaveFileDialog class, call it saveFile
            SaveFileDialog saveFile = new SaveFileDialog();
            // Set the DefaultExt property to "xml"
            saveFile.DefaultExt = "xml";
            // Automatically add the extension to the file
            saveFile.AddExtension = true;
            // Set the FileName property to the text stored in tbxName
            saveFile.FileName = tbxName.Text;
            // Pop up the save file dialog
            saveFile.ShowDialog();
            // Create a new FileIO, call it fm
            FileIO fm = new FileIO();
            //Use the SaveAsXML method to save the books stored in allBooks into the file
            fm.SaveAsSOAP(allBooks, saveFile.FileName);
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            //FileIO fm = new FileIO();
            //fm.SaveBooks(tbxName.Text, allBooks);
            //fm.SaveAsHTML(allBooks, tbxName.Text);
            //fm.SaveAsDatFile(allBooks, tbxName.Text);
            //fm.SaveAsXML(allBooks, tbxName.Text);
            //fm.SaveAsSOAP(allBooks, tbxName.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Loop through each item in allBooks
            for (int i = 0; i < allBooks.Count; i++)
            {
                // If the selected item from the listbox is the same as the item in allBooks
                if (lbxInformation.SelectedItem == allBooks[i])
                {
                    // Remove the book from the list allBooks
                    allBooks.Remove((Book)lbxInformation.SelectedItem);
                    // Remove the item from the list
                    lbxInformation.Items[i] = "";
                }
            }

            // Create a new FileIO, call it fm
            FileIO fm = new FileIO();
            // Use the DeleteBook method to delete the book from the list of books
            fm.DeleteBook(tbxName.Text, allBooks);
            // Call the UpdateBooksListBox method
            UpdateBooksListBox();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Try catch block to prevent crashing
            try
            {
                // If statement to check if radiobutton Physical Book is checked
                if (rdoPhysicalBook.Checked == true)
                {
                    // Create a new PhysicalBook object call it pBook
                    PhysicalBook pBook = new PhysicalBook();
                    // Set the Title property to the text in tbxTitle
                    pBook.Title = tbxTitle.Text;
                    // Set the Author property to the text in tbxAuthor
                    pBook.Author = tbxAuthor.Text;
                    // Set the Year property to the text in tbxYear converted into an int
                    pBook.Year = int.Parse(tbxYear.Text);
                    // Set the Weight property to the text in tbxWeight
                    pBook.Weight = tbxWeight.Text;
                    // Set the PageCount property to the text in tbxPageCount converted into an int
                    pBook.PageCount = int.Parse(tbxPageCount.Text);
                    // Add the book to the list of books called allBooks
                    allBooks.Add(pBook);
                }
                // If statement to check if radiobutton Audio Book is checked
                else if (rdoAudioBook.Checked == true)
                {
                    // Create a new AudioBook object call it aBook
                    AudioBook aBook = new AudioBook();
                    // Set the Title property to the text in tbxTitle
                    aBook.Title = tbxTitle.Text;
                    // Set the Author property to the text in tbxAuthor
                    aBook.Author = tbxAuthor.Text;
                    // Set the Year property to the text in tbxYear converted into an int
                    aBook.Year = int.Parse(tbxYear.Text);
                    // Set the FileSize property to the text in tbxFileSize
                    aBook.FileSize = tbxFileSize.Text;
                    // Set the Length property to the text in tbxLength
                    aBook.Length = tbxLength.Text;
                    // Set the Narrator property to the text in tbxNarrator
                    aBook.Narrator = tbxNarrator.Text;
                    // Add the book to the list of books called allBooks
                    allBooks.Add(aBook);
                }
                // If statement to check if radiobutton Audio Book is checked
                else if (rdoEbook.Checked == true)
                {
                    // Create a new EBook object call it eBook
                    EBook eBook = new EBook();
                    // Set the Title property to the text in tbxTitle
                    eBook.Title = tbxTitle.Text;
                    // Set the Author property to the text in tbxAuthor
                    eBook.Author = tbxAuthor.Text;
                    // Set the Year property to the text in tbxYear converted into an int
                    eBook.Year = int.Parse(tbxYear.Text);
                    // Set the FileSize property to the text in tbxFileSize
                    eBook.FileSize = tbxFileSize.Text;
                    // Set the FileFormat property to the text in tbxFileFormat
                    eBook.FileFormat = tbxFileFormat.Text;
                    // Set the PageCount property to the text in tbxPageCount converted into an int
                    eBook.PageCount = int.Parse(tbxPageCount.Text);
                    // Add the book to the list of books called allBooks
                    allBooks.Add(eBook);
                }
            }
            // Catch the error and instead do the following code
            catch
            {
                // Show a messagebox
                MessageBox.Show("Error");
            }
            // Call the UpdateBooksListBox method
            UpdateBooksListBox();
            // Create a new FileIO call it fm
            FileIO fm = new FileIO();
            // Use the AddBook to add the created book to the list of books
            fm.AddBook(tbxName.Text, allBooks);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Does the same when you click btnOpenFile
            btnOpenFile.PerformClick();
        }

        private void saveAstxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Does the same when you click btnSave
            btnSave.PerformClick();
        }

        private void saveAsdatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Does the same when you click btnSaveAsDat
            btnSaveAsDat.PerformClick();
        }

        private void saveAsxmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Does the same when you click btnSaveAsXML
            btnSaveAsXML.PerformClick();
        }

        private void saveAsSOAPxmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Does the same when you click btnSaveAsSOAP
            btnSaveAsSOAP.PerformClick();
        }

        private void saveAsHtmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Does the same when you click btnSaveHTML
            btnSaveHTML.PerformClick();
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Does the same when you click btnSaveAll
            btnSaveAll.PerformClick();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Closes the form
            this.Close();
        }

        private void allBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Does the same when you click btnAllBooks
            btnAllBooks.PerformClick();
        }

        private void physicalBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Does the same when you click btnPhysicalBooks
            btnPhysicalBooks.PerformClick();
        }

        private void eBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Does the same when you click btnEBooks
            btnEBooks.PerformClick();
        }

        private void audioBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Does the same when you click btnAudioBooks
            btnAudioBooks.PerformClick();
        }

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            // Does the same when you click btnOpenFile
            btnOpenFile.PerformClick();
        }

        private void tsmClose_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }
    }

}
