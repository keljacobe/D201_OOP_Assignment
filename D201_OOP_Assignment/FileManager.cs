using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace D201_OOP_Assignment
{
    class FileManager
    {
        public List<Book> LoadAll()
        {
            List<Book> ListAll = new List<Book>();

            StreamReader sr = new StreamReader("BookSourceFile.txt");
            while (!sr.EndOfStream)
            {
                string bookInfo = sr.ReadLine();

                string[] bookVals = bookInfo.Split(',');

                PhysicalBook newPhysicalBook = new PhysicalBook();
                newPhysicalBook.Title = bookVals[1];
                newPhysicalBook.Author = bookVals[2];
                newPhysicalBook.Year = int.Parse(bookVals[3]);
                newPhysicalBook.Weight = int.Parse(bookVals[4]);

                AudioBook newAudioBook = new AudioBook();
                newAudioBook.Title = bookVals[1];
                newAudioBook.Author = bookVals[2];
                newAudioBook.Year = int.Parse(bookVals[3]);
                newAudioBook.FileSize = bookVals[4];
                newAudioBook.Length = bookVals[6];
                newAudioBook.Narrator = bookVals[7];

                EBook newEbook = new EBook();
                newEbook.Title = bookVals[1];
                newEbook.Author = bookVals[2];
                newEbook.Year = int.Parse(bookVals[3]);
                newEbook.FileSize = bookVals[4];
                newEbook.FileFormat = bookVals[5];

                ListAll.Add(newPhysicalBook);
                ListAll.Add(newAudioBook);
                ListAll.Add(newEbook);
            }
            sr.Dispose();

            return ListAll;
        }

        public void OpenExternalFile(string fileName)
        {
            Process.Start(fileName);
        }
    }
}
