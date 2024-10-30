using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public interface AccountDAO
    {
        List<Account> GetAccounts();
        bool AddAccount(Account account);
        Account GetAccount(int id);
        Account GetAccountByUsername(string username);
        bool UpdateAccount(Account account);
        bool DeleteAccount(int id);
    }
}
