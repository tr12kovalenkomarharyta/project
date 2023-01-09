using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    [Serializable]
    public class Book
    {
        public int Id { get; }
        public string Title { get; }
        public string Author { get; }
        public string Description { get; }
        public int Price { get; }
        public bool Availability { get; set; }

        public Book(int id, string title, string author, string description, int price)
        {
            Title = title;
            Id = id;
            Author = author;
            Price = price;
            Description = description;
            Availability = true;
        }
    }
}
