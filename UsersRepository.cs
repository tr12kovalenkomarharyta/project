using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Store
{
    [Serializable]
    internal class UsersRepository 
    { 
        private List<Account> accounts = new List<Account>()
        {
            new SellersAccount(),
    };
        public void Add(Account user)
        {
            accounts.Add(user);
        }
        public bool IfUserIsSignUp(string name, string password)
        {
            for(int i=0;i<accounts.Count;i++)
            {
                if (accounts[i].Name==name&& accounts[i].Password == password) return true;
            }
            return false;
        }

        public  Account GetById(string name)
        {
            Account acc = new UsersAccount("name", "password");
            for(int i=0;i<accounts.Count;i++)
            {
                if (accounts[i].Name==name) return accounts[i];  
            }
            return acc;
        }
       
    }
}
