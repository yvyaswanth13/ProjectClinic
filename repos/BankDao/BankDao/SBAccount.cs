using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDao
{
    public class SBAccount
    {
         
        public SBAccount()
        {
        }
     
        public SBAccount(string accountNumber, string accountHolderName, string typeofAccount, DateTime dateofCreation, int balance)
        {
            this.accountNumber = accountNumber;
            this.AccountHolderName = accountHolderName;
            this.TypeofAccount = typeofAccount;
            this.DateofCreation = dateofCreation;
            this.Balance = balance;
        }
        private string accountNumber;

        public string GetAccountNumber()
        {
            return accountNumber;
        }

        public void SetAccountNumber(string value)
        {
            accountNumber = value;
        }

        public string AccountHolderName { get; set; }
        public string TypeofAccount { get; set; }
        public DateTime DateofCreation { get; set; }
        public int Balance { get; set; }

    }
}
