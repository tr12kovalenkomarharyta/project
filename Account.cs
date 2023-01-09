using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Store
{
    [Serializable]
     internal class Account
    {
        public string Name;
        public string Password;
        public int Balanse = 0;
        public List<Book> HistoryOfPurchase = new List<Book>();
        public Card card=new Card();
        public byte[] HashPassword;

        public virtual void ReplanishTheBalanse(int replenishment){  }

        public virtual void PrintHistory() { }    
        
        public virtual void AddBookInRepository(int id, string title, string author, string descripthion, int price, BookRepository books) { }

        public virtual void EditTheAvailAbility(Book book, bool availability) { }
    }
}
