using DXWebApplication2.Data;
using DXWebApplication2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DXWebApplication2
{
    [DataObject(true)]
    public class AccountDataSource
    {
        private AccountModel db = new AccountModel();
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public IEnumerable<Account> Select()
        {
            var pars = db.Accounts.Where(a => a.ACC_Parent == null).Include(a => a.Accounts1).ToList();
            var final = new List<Account>();

            foreach (var par in pars)
            {
                foreach(var acc in par.Accounts1)
                {
                    decimal? balance = GetBalance(acc);
                    if (par.Balance == null)
                    {
                        par.Balance = balance;
                    }
                    else
                    {
                        par.Balance = par.Balance + balance;
                    }

                }

                final.Add(par);
            }
            return final;

        }
        private decimal? GetBalance(Account account)
        {
            account = db.Accounts.Where(a => a.Acc_Number == account.Acc_Number).Include(a => a.Accounts1).FirstOrDefault();

            if(account.Balance > 0)
            {
                return account.Balance;
            }

            foreach (var acc in account.Accounts1)
            {
                account = acc;
            }

            return GetBalance(account);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public IEnumerable<Account> Insert(Account account)
        {
            return db.Accounts.Where(a => a.ACC_Parent != null).ToList();
        }
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public IEnumerable<Account> Update(Account account)
        {
            return db.Accounts.Where(a => a.ACC_Parent != null).ToList();
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public IEnumerable<Account> Delete(Account account)
        {
            return db.Accounts.Where(a => a.ACC_Parent != null).ToList();
        }
    }
}