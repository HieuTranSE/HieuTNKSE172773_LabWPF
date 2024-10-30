using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface AccountRepository
    {
        List<Account> GetAllAccounts();
        Account GetAccountById(string id);
        Account GetAccountByUsername(string username);
        bool AddAccount(Account account);
        bool UpdateAccount(Account account);
        bool DeleteAccount(int id);
    }
}
