using DXWebApplication2.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DXWebApplication2.Models
{
    public class DataViewModel
    {
        private static AccountModel db = new AccountModel();

        public static string GetRowData(string accountNumber)
        {
            var parent = db.Accounts.Where(a => a.Acc_Number == accountNumber).Include(a => a.Accounts1).FirstOrDefault();
            AccountNumber = parent.Acc_Number;
            foreach (var item in parent.Accounts1)
            {
                AccountNumber = AccountNumber + GetAccountNumber(item) + Environment.NewLine;
            }

            return AccountNumber;
        }
        private static string AccountNumber = "";
        private static string GetAccountNumber(Account account)
        {
            account = db.Accounts.Where(a => a.Acc_Number == account.Acc_Number).Include(a => a.Accounts1).FirstOrDefault();
            
            if (account.Accounts1.Count > 0)
            {
                foreach (var acc in account.Accounts1)
                {
                    AccountNumber =  AccountNumber + " -> " + account.Acc_Number;
                    GetAccountNumber(acc);
                }
            }

            AccountNumber = AccountNumber +" -> "+ account.Acc_Number + " = " + account.Balance;

            return "";
        }
    }
}