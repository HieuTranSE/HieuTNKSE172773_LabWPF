using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface AccountService
    {
        List<Account> GetAllAccounts();
        Account GetAccountById(string id);
        bool AddAccount(Account account);
        bool UpdateAccount(Account account);
        bool DeleteAccount(int id);
        bool ValidateAccount(string username, string password); 
    }
}
