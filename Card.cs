using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    [Serializable]
    internal class Card : Repository
    {
        public Card()
        {
            books = new List<Book>();
        }

        public bool Empty()
        {
            if (books.Count != 0) return false;
            else return true;
        }
        public void BuyAll(Account user)
        {
            int cost = 0;
            for (int i = 0; i < books.Count; i++)
            {
                user.HistoryOfPurchase.Add(books[i]);
                books[i].Availability = false;
                cost += books[i].Price;
            }
            user.Balanse -= cost;
            books.Clear();
        }
        public void Delete(int id)
        {
            books.Remove(GetById(id));
        }
        public bool IfInCard(int id)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (id == books[i].Id) return true;
            }
            return false;
        }
        public bool IfBalanseEnough(Account user)
        {
            int Cost = 0;
            for (int i = 0; i < books.Count; i++)
            {
                Cost += books[i].Price;
            }
            if (Cost <= user.Balanse)
                return true;
            else return false;
        }

        

        
    }
}
