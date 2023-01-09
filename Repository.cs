using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Store
{
    [Serializable]
    internal class Repository
    {
        protected List<Book> books;
        public void Add(Book book)
        {
            books.Add(book);
        }
        public int LastId()
        {
            return books[books.Count - 1].Id;
        }
        public Book GetById(int id)
        {
            Book book = new Book(0,"","","",0);
            for(int i=0;i<books.Count;i++)
            {
                if (books[i].Id==id) return books[i];
            }
            return book;
        }
        public void PrintAllBooks()
        {
            for (int i = 0; i < books.Count; i++)
                Console.WriteLine(books[i].Id + " " + books[i].Title + "\n");
        }
    }

}
