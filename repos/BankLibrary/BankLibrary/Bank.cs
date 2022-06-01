using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDao;
namespace BankLibrary
{
    public interface Bank
    {
        public Boolean LoanEligibility(int ReqAmount, int age, string accNo);
        public int emi(int amount, int n, int r);
        public String withDraw(int amount, string accNo);
    }
}
