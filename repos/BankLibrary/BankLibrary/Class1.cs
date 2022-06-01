
using BankDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankLibrary
{
    public class IBank : Bank
    {

        IDao dao = new DaoImpl();
        public int emi(int amount, int n, int r)
        {
            return ((n * amount * r) / 100);
        }

        public Boolean LoanEligibility(int ReqAmount, int age, string accNo)
        {
            SBAccount sb = dao.getAcc(accNo);
            if (sb != null)
            {
                ReqAmount = (ReqAmount * 65) / 100;
                if (ReqAmount < sb.Balance && age > 18)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public string withDraw(int amount, string accNo)
        {
            String? s;
            SBAccount? sb = dao.getAcc(accNo);
            if (accNo.Equals(sb.GetAccountNumber()) )
            {

                if (amount < 0)
                {
                    throw new Exception("Transaction Fail");
                }
                if (amount < sb.Balance)
                {
                    if (dao.updateBal((sb.Balance - amount), accNo) == 1)
                    {
                        s = "Your Transaction Successful\n"

                       + "Availble Balance : " + (sb.Balance - amount);
                    }
                    else
                    {
                        s = "Balance Not Update";
                    }

                }
                else
                {
                    s = "Insufficient Balance";
                }
            }
            else
            {
                s = "Account Not Found";
            }
            return s;
        }
    }
}
