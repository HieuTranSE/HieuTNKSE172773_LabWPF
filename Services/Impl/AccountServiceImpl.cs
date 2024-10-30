using BusinessObjects.Models;
using Repositories;
using Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class AccountServiceImpl : AccountService
    {
        private readonly AccountRepository _accountRepository;

        public AccountServiceImpl()
        {
            _accountRepository = new AccountRepositoryImpl();
        }

        public List<Account> GetAllAccounts()
        {
            return _accountRepository.GetAllAccounts();
        }

        public Account GetAccountById(string id)
        {
            return _accountRepository.GetAccountById(id);
        }

        public bool AddAccount(Account account)
        {
            return _accountRepository.AddAccount(account);
        }

        public bool UpdateAccount(Account account)
        {
            return _accountRepository.UpdateAccount(account);
        }

        public bool DeleteAccount(int id)
        {
            return _accountRepository.DeleteAccount(id);
        }
        public bool ValidateAccount(string username, string password)
        {
            bool isValidated = false;
            var account = _accountRepository.GetAccountByUsername(username);

            if (account == null)
            {
                isValidated = false;
            }
            else
            {
                if(account.PasswordHash == password)
                {
                    isValidated = true;
                }
            }

            return isValidated;
        }
    }
}
