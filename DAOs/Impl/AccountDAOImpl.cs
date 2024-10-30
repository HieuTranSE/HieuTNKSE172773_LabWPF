using BusinessObjects.Context;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.Impl
{
    public class AccountDAOImpl : AccountDAO
    {
        private KoiManagementSystemContext _context;

        private static AccountDAOImpl _instance = null;

        public static AccountDAOImpl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountDAOImpl();
                }
                return _instance;
            }
        }

        public AccountDAOImpl()
        {
            _context = new KoiManagementSystemContext();
        }

        public List<Account> GetAccounts()
        {
            return _context.Accounts.ToList();
        }

        public bool AddAccount(Account account)
        {
            bool isSuccess = false;
            try
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
                isSuccess = true;
            }
            finally
            {
                // Handle any cleanup here if needed
            }
            return isSuccess;
        }

        public Account GetAccount(int id) => _context.Accounts.FirstOrDefault(x => x.AccountId == id);

        public Account GetAccountByUsername(string username) => _context.Accounts.FirstOrDefault(x => x.Username.Equals(username));
        
        public bool UpdateAccount(Account account)
        {
            bool isSuccess = false;
            try
            {
                _context.Accounts.Update(account);
                _context.SaveChanges();
                isSuccess = true;
            }
            finally
            {
                // Handle any cleanup here if needed
            }
            return isSuccess;
        }

        public bool DeleteAccount(int id)
        {
            bool isSuccess = false;
            try
            {
                _context.Accounts.Remove(GetAccount(id));
                _context.SaveChanges();
                isSuccess = true;
            }
            catch
            {

            }
            finally
            {
                // Handle any cleanup here if needed
            }
            return isSuccess;
        }
    }
}
