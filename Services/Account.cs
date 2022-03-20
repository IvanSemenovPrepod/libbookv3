using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datamodel;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Services
{
    public class Account
    {
        Entities db = new Entities();
        public datamodel.Account GetAccountByLoginPassword(string login, string password)
        {
            var account = db.Accounts.FirstOrDefault(p => p.Login == login && p.Password == password);

            return account;
        }

        public datamodel.vAccount GetAccountByLogin(string login)
        {
            var account = db.vAccounts.FirstOrDefault(p => p.Login == login);
            return account;
        }

        public datamodel.vAccount GetAccountById(int id)
        {
            var account = db.vAccounts.FirstOrDefault(p => p.Id == id);
            return account;
        }

        public bool EditUser(vAccount account)
        {
            var res = db.EditUser(account.Id, account.FirstName, account.LastName, account.SecondName, account.Login, account.Email, account.Phone);
            if (res>0)
            {
                return true;
            }
            return false;
        }
    }
}
