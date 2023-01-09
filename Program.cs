using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Http.Headers;

namespace Store
{
     class Program
    {
        public static void Main(string[] args)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            UsersRepository users = new UsersRepository();
            Menu menu = new Menu();
            BookRepository books = new BookRepository();
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                users = (UsersRepository)formatter.Deserialize(fs);
            }
            using(FileStream fs = new FileStream("books.dat", FileMode.OpenOrCreate))
            {
                books = (BookRepository)formatter.Deserialize(fs);
            }
            menu.Enter(users, books);
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, users);
            }
            using (FileStream fs = new FileStream("books.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, books);
            }

        }
    }
}
