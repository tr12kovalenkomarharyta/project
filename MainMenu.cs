using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    internal class Menu
    {
        private int MainMenuForSeller(UsersRepository users, Account user, BookRepository books)
        {
            Console.Clear();
            Console.WriteLine("1.Додати книгу " + "\n" + "2.Змiнити наявнiсть книг\n" + "3.Переглянути iсторiю змiн\n"+"4.Переглянути книги у наявностi\n"+"5.Вийти");
            int temp = Convert.ToInt32(Console.ReadLine());
            if (temp == 5) return 0;
            if (temp == 1) AddingNewBook(users, user, books);
            if (temp == 2) Edit(users, user, books);
            if (temp == 3) UsersHistory(users, user, books, false);
            if (temp == 4) PrintAvailAbility(users, user, books);
            return 0;
        }
        private void PrintAvailAbility(UsersRepository users, Account user, BookRepository books)
        {
            Console.Clear();
            books.PrintBooksAvailability();
            Console.WriteLine("\n\n\n\n0.Назад");
            Console.ReadLine();
            MainMenuForSeller(users, user, books);
        }
        private void Edit(UsersRepository users, Account user, BookRepository books)
        {
            Console.Clear();
            Console.WriteLine("Введiть id книги: ");
            int id = Convert.ToInt32(Console.ReadLine());
            user.EditTheAvailAbility(books.GetById(id), true);
            Console.Clear();
            Console.WriteLine("Книга у наявностi\n\n\n\n0.Назад");
            Console.ReadLine();
            MainMenuForSeller(users, user, books);
        }
        private void AddingNewBook(UsersRepository users, Account user, BookRepository books)
        {
            Console.Clear();
            Console.WriteLine("Введiть назву книги: ");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введiть автора книги: ");
            string author = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введiть опис книги: ");
            string description = Console.ReadLine();
            Console.WriteLine("Введiть ціну книги: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть id книги: ");
            int id = Convert.ToInt32(Console.ReadLine());
            user.AddBookInRepository(id, name, author, description, price, books);
            Console.WriteLine("Книгу додано\n\n\n\n0.Назад");
            Console.ReadLine();
            MainMenuForSeller(users, user, books);
        }

            private int MainMenuForUser(UsersRepository users, Account user, BookRepository books)
        {
            Console.Clear();
            Console.WriteLine("1.Поповнити баланс " + "\n" + "2.Переглянути товари " + "\n" + "3.Корзина " + "\n" + "4.Iсторiя покупок " + "\n" + "5.Вийти");
            int temp = Convert.ToInt32(Console.ReadLine());
            if (temp == 5) return 0;
            if (temp == 1) UsersBalanse(users, user, books);
            if (temp == 2) BookSearch(users, user, books);
            if (temp == 4) UsersHistory(users, user, books, true);
            if (temp == 3) UsersCard(users, user, books);
            return 0;
        }

        private void UsersBalanse(UsersRepository users, Account user, BookRepository books)
        {
            Console.Clear();
            Console.WriteLine("Баланс:" + user.Balanse + "\nВведiть суму поповнення: ");
            int balanse = Convert.ToInt32(Console.ReadLine());
            user.ReplanishTheBalanse(balanse);
            Console.Clear();
            Console.WriteLine("Успiшно поповнено. Баланс:" + user.Balanse+ "\n\n\n\n0.Назад");
            Console.ReadLine();
            MainMenuForUser(users, user, books);
        }
        private void UsersHistory(UsersRepository users, Account user, BookRepository books, bool flag)
        {
            Console.Clear();
            user.PrintHistory();
            Console.WriteLine("\n\n\n0.Назад");
            Console.ReadLine();
            if(flag)
            MainMenuForUser(users, user, books);
            else
                MainMenuForSeller(users, user, books);
        }
        private void UsersCard(UsersRepository users, Account user, BookRepository books)
        {
            Console.Clear();
            user.card.PrintAllBooks();
            if (!user.card.Empty())
            {
                Console.WriteLine("-1.Купити    1-" + user.card.LastId() + ".Видалити" + "\n\n\n0.Назад");
                int temp = Convert.ToInt32(Console.ReadLine());
                if (temp == -1)
                {
                    if (user.card.IfBalanseEnough(user))
                    {
                        user.card.BuyAll(user);

                        Console.Clear();
                        Console.WriteLine("Покупка успiшна\n\n\n\n0.Назад");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("На вашому рахунку недостатньо коштiв. Будь ласка, поповнiть баланс\n\n\n\n0.Назад");
                        Console.ReadLine();
                    }
                    MainMenuForUser(users, user, books);
                }
                else
                {
                   
                    user.card.Delete(temp);
                    Console.Clear();
                    Console.WriteLine("Видалено.\n\n\n\n0.Назад");
                    Console.ReadLine();
                    UsersCard(users, user, books);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Корзина пуста.\n\n\n\n0.Назад");
                Console.ReadLine();
                MainMenuForUser(users, user, books);
            }
        }
        private void BookSearch(UsersRepository users, Account user, BookRepository books)
        {
            Console.Clear();
            Console.WriteLine("1.Переглянути усi товари    2.Знайти товар\n\n\n0.Назад");
            int temp = Convert.ToInt32(Console.ReadLine());
            if (temp == 0) MainMenuForUser(users, user, books);
            if (temp == 1)
            {
                Console.Clear();
                books.PrintAllBooks();
                Choosing(users, user, books);
            }
            if (temp == 2)
            {
                Console.Clear();
                Console.WriteLine("Знайти: ");
                string titleofauthor = Console.ReadLine();
                Book[] results = books.GetAllByAuthorOrTitle(titleofauthor);
                Console.Clear();
                books.PrintSearchResults(results);
                Choosing(users, user, books);
            }
        }

        private void Choosing(UsersRepository users, Account user, BookRepository books)
        {
            Console.WriteLine("1-" + books.LastId() + ".Обрати книгу    -1.В головне меню\n\n\n0.Назад");
            int book = Convert.ToInt32(Console.ReadLine());
            if (book == 0) BookSearch(users, user, books);
            if(book == -1) MainMenuForUser(users, user, books);
            else
            {
                Console.Clear();
                books.PrintInfoAboutBook(books.GetById(book));
                Console.WriteLine("1.B корзину    0.Назад");
                int temptemp = Convert.ToInt32(Console.ReadLine());
                if (temptemp == 1)
                {
                    if (books.GetById(book).Availability)
                    {
                        if(!user.card.IfInCard(book))
                        {
                            Console.Clear();
                            Console.WriteLine("Книгу додано до корзини\n\n\n\n0.Назад");
                            Console.ReadLine();
                            user.card.Add(books.GetById(book));
                        }     
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Ця книга вже в корзині\n\n\n\n0.Назад");
                            Console.ReadLine();
                        }
                    }    
                    else { Console.Clear(); Console.WriteLine("На жаль, книги нема у наявностi\n\n\n\n0.Назад"); Console.ReadLine(); }
                    Console.Clear();
                    books.PrintAllBooks();
                    Choosing(users, user, books);
                }
                else
                {    
                    books.PrintAllBooks();
                    Choosing(users, user, books);
                }
            }
        }

        public void Enter(UsersRepository users, BookRepository books)
        {
            Console.Clear();
            Console.WriteLine("1.Увiйти" + "\n" + "2.Зареєстуватись");
            int temp = Convert.ToInt32(Console.ReadLine());
            if (temp == 1)
            {
                Console.Clear();
                Console.WriteLine("1.Увiйти як покупець" + "\n" + "2.Увiйти як продавець");
                
                int typeofacc = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Введiть iм'я користувача");
                string name = Console.ReadLine();
                Console.WriteLine("Введiть пароль");
                string password = Console.ReadLine();
                if (users.IfUserIsSignUp(name, password)) 
                {

                    if (typeofacc == 1)
                    {
                        Account user = new UsersAccount("name", "password");
                        user = users.GetById(name);
                        MainMenuForUser(users, user, books);
                    }

                    else
                    {
                        Account user = new SellersAccount();
                        user = users.GetById(name);
                        MainMenuForSeller(users, user, books);
                    }
                   
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Неправильний пароль або iм'я користувача. Спробуйте ще раз\n\n\n\n0.Назад");
                    Console.ReadLine();
                    Enter(users, books);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Введiть iм'я користувача");
                string name = Console.ReadLine();
                Console.WriteLine("Введiть пароль");
                string password = Console.ReadLine();
                Account user = new UsersAccount(name, password);
                users.Add(user);
                MainMenuForUser(users, user, books);
            }
        }
    }
}
