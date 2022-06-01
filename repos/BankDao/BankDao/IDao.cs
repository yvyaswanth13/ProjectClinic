using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BankDao
{
    public interface IDao
    {
        public List<SBAccount> getAccDetails();
        public int insertAcc(SBAccount acc);
        public int updateAccDetails(String AccNumber, String Acctype);
        public int deleteAcc(String AccNumber);
        public SBAccount? getAcc(String AccNumber);
        public int updateBal(int bal, String AccNumber);
    }
}
