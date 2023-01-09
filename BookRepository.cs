using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    [Serializable]
   internal class BookRepository:Repository
     {

        public BookRepository()
        {
            books = new List<Book>()
            {
            new Book(1, "The Collector", "John Fowles", "dscdsc", 122),
            new Book(2, "Lolita", "Vladimir Nabocov", "dskahfsjkdj", 333),
            new Book(3, "Perfume. The story about a murderer", "Patrick Suskind", "kjdfvfj", 400),
             new Book(4, "Harry Potter and the Philosopher's Stone (2001)", " J. K. Rowling", "Harry Potter is an orphaned boy brought up by his unkind Muggle (non-magical) aunt and uncle. At the age of eleven, half-giant Rubeus Hagrid informs him that he is actually a wizard and that his parents were murdered by an evil wizard named Lord Voldemort. Voldemort also attempted to kill one-year-old Harry on the same night, but his killing curse mysteriously rebounded and reduced him to a weak and helpless form. Harry became extremely famous in the Wizarding World as a result. Harry begins his first year at Hogwarts School of Witchcraft and Wizardry and learns about magic. During the year, Harry and his friends Ron Weasley and Hermione Granger become entangled in the mystery of the Philosopher's Stone which is being kept within the school.", 400),
            new Book(5, "Harry Potter and the Chamber of Secrets (2002)", " J. K. Rowling", "Harry, Ron, and Hermione return to Hogwarts for their second year, which proves to be more challenging than the last. The Chamber of Secrets has been opened, leaving students and ghosts petrified by an unleashed monster. Harry must face up to claims that he is the heir of Salazar Slytherin (founder of the Chamber), learn that he can speak Parseltongue, and also discover the properties of a mysterious diary, only to find himself trapped within the Chamber itself.", 367),
            new Book(6, "Harry Potter and the Prisoner of Azkaban (2004)", " J. K. Rowling", "Harry's third year sees the boy wizard, along with his friends, attending Hogwarts School once again. Professor R. J. Lupin joins the staff as Defence Against the Dark Arts teacher, while convicted murderer Sirius Black escapes from Azkaban. The Ministry of Magic entrusts the Dementors to guard Hogwarts from Black. Harry learns more about his past and his connection with the escaped prisoner.", 250),
             new Book(7, "Harry Potter and the Goblet of Fire (2005)", " J. K. Rowling", "During Harry's fourth year, Hogwarts plays host to the Triwizard Tournament. Three European schools participate in the tournament, with three 'champions' representing each school in the deadly tasks. The Goblet of Fire chooses Fleur Delacour, Viktor Krum, and Cedric Diggory to compete against each other. However, Harry's name is also produced from the Goblet thus making him a fourth champion, which leads to a terrifying encounter with a reborn Lord Voldemort.", 300),
            new Book(8, "Harry Potter and the Order of the Phoenix (2007)", " J. K. Rowling", "Harry's fifth year begins with him being attacked by Dementors in Little Whinging. Later, he finds out that the Ministry of Magic is in denial of Lord Voldemort's return. Harry is also beset by disturbing and realistic nightmares, while Professor Umbridge, a representative of Minister for Magic Cornelius Fudge, is the new Defence Against the Dark Arts teacher. Harry becomes aware that Voldemort is after a prophecy which reveals: \"neither can live while the other survives\". The rebellion involving the students of Hogwarts, secret organisation Order of the Phoenix, the Ministry of Magic, and the Death Eaters begins.", 450),
            new Book(9, "Harry Potter and the Half-Blood Prince (2009)", " J. K. Rowling", "In Harry's sixth year at Hogwarts, Lord Voldemort and his Death Eaters are increasing their terror upon the Wizarding and Muggle worlds. Headmaster Albus Dumbledore persuades his old friend Horace Slughorn to return to Hogwarts as a professor as there is a vacancy to fill. There is a more important reason, however, for Slughorn's return. While in a Potions lesson, Harry takes possession of a strangely annotated school textbook, inscribed as belonging to the 'Half-Blood Prince'. Draco Malfoy struggles to carry out a mission presented to him by Voldemort. Meanwhile, Dumbledore and Harry secretly work together to discover how to destroy the Dark Lord once and for all.", 278),
        };
        }
        public Book[] GetAllByAuthorOrTitle(string authorortitle)
            {
                return books.Where(books => books.Title.Contains(authorortitle) || books.Author.Contains(authorortitle)).ToArray();
            }
        public void PrintInfoAboutBook(Book book)
        {
            Console.WriteLine(book.Title + "\n" + book.Author + "\n" + book.Description + "\n" + book.Price +"\n\n");
        }
        public void PrintSearchResults(Book[] Books)
        {
            for (int i = 0; i < Books.Length; i++)
            {
                Console.WriteLine(Books[i].Id+ " " + Books[i].Title + "\n");
            }
        }
        public void PrintBooksAvailability()
        {
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine(books[i].Id + " " + books[i].Title + " ");
                if (books[i].Availability) Console.WriteLine( "Є у наявностi\n ");
                else Console.WriteLine("Немає в наявностi\n ");
            }
        }
    }
    }

