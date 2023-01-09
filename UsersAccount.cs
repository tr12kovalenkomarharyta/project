using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Store
{
    [Serializable]
    internal class UsersAccount:Account
    {
        
       
        public UsersAccount(string name, string password)
        {
            Name = name;
            Password = password;
            byte[] tmpSource;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(Password);
            HashPassword = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

        }
        public override void PrintHistory()
        {
            for (int i = 0; i < HistoryOfPurchase.Count; i++)
            {
                Console.WriteLine(HistoryOfPurchase[i].Title + " " + HistoryOfPurchase[i].Author + "\n");
            }
        }
        public override void ReplanishTheBalanse(int replanishment)
        {
            Balanse += replanishment;
        }
    }
}
