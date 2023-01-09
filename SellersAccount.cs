using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace Store
{
    [Serializable]
    internal class SellersAccount:Account
    {
        private List<string> history= new List<string>();
        public SellersAccount() 
        {
            Name = "seller";
            Password = "123456";
            byte[] tmpSource;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(Password);
            HashPassword = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
          
        }

        public override void AddBookInRepository(int id, string title, string author, string descripthion, int price, BookRepository books)
        {
            Book newBook=new Book(id,title,author,descripthion,price);
            books.Add(newBook);
            string his = "Adding " + title ;
            history.Add(his);
        }

        public override void EditTheAvailAbility(Book book, bool availability)
        {
            book.Availability = availability;
            string his = "Editing " + book.Title+" availability";
            history.Add(his);
        }
        public override void PrintHistory()
        {
            for (int i = 0; i < history.Count; i++)
            {
                Console.WriteLine(history[i] + "\n");
            }
        }
    }
}
