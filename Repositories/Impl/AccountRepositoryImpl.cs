using BusinessObjects.Context;
using BusinessObjects.Models;
using DAOs;
using DAOs.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impl
{
    public class AccountRepositoryImpl : AccountRepository
    {
        public bool AddAccount(Account account)
        {
            return AccountDAOImpl.Instance.AddAccount(account);
        }

        public bool DeleteAccount(int id)
        {
            return AccountDAOImpl.Instance.DeleteAccount(id);
        }

        public Account GetAccountById(string id)
        {
            throw new NotImplementedException();
        }

        //public Account GetAccountById(int id)
        //{
        //    return AccountDAOImpl.Instance.GetAccount(id);
        //}
        public Account GetAccountByUsername(string username)
        {
            return AccountDAOImpl.Instance.GetAccountByUsername(username);
        }
        public List<Account> GetAllAccounts()
        {
            return AccountDAOImpl.Instance.GetAccounts();
        }

        public bool UpdateAccount(Account account)
        {
           return AccountDAOImpl.Instance.UpdateAccount(account);
        }

    }
}
