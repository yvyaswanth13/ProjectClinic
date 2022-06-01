using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BankDao
{
    public class DaoImpl : IDao
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public DaoImpl()
        {

            try
            {
                // Creating Connection  

                con = getCon();
                Console.WriteLine("Connection Established Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
        }

        private static SqlConnection getCon()
        {
            con = new SqlConnection("data source=.; database=eurofins; integrated security=SSPI");
            con.Open();

            return con;
        }
        public int deleteAcc(string AccNumber)
        {

            con = getCon();

            cmd = new SqlCommand("DELETE FROM dbo.bank WHERE AccNumber = @AccNumber ", con);
            cmd.Parameters.AddWithValue("@AccNumber", AccNumber);

            return cmd.ExecuteNonQuery();
        }


        public List<SBAccount> getAccDetails()
        {
            List<SBAccount> sba = new List<SBAccount>();
            try
            {
                con = getCon();

                cmd = new SqlCommand("select * from dbo.bank", con);
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SBAccount ba = new SBAccount();
                    ba.SetAccountNumber(rdr.GetString(1));
                    ba.AccountHolderName = rdr.GetString(2);
                    ba.TypeofAccount = rdr.GetString(3);
                    ba.DateofCreation = DateTime.Now;//DateTime.Parse(rdr.GetString(4));
                    ba.Balance = Convert.ToInt32(rdr.GetString(5));


                    sba.Add(ba);
                }
                return sba;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return sba;
            }
        }






        public int insertAcc(SBAccount acc)
        {
            con = getCon();

            cmd = new SqlCommand("INSERT INTO dbo.bank (AccNumber,AccHolderName,AccType,DateOfCre,Balance) VALUES (@AccNumber,@AccHolderName,@AccType,@DateOfCre,@Balance)", con);


            cmd.Parameters.AddWithValue("@AccNumber", acc.GetAccountNumber());
            cmd.Parameters.AddWithValue("@AccHolderName", acc.AccountHolderName);
            cmd.Parameters.AddWithValue("@AccType", acc.TypeofAccount);
            cmd.Parameters.AddWithValue("@DateOfCre", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@Balance", acc.Balance);



            return cmd.ExecuteNonQuery();

        }

        public int updateAccDetails(string AccNumber, String Acctype)
        {
            con = getCon();

            cmd = new SqlCommand("Update dbo.bank SET AccType = @AccType WHERE AccNumber = @AccNumber ", con);
            cmd.Parameters.AddWithValue("@AccNumber", AccNumber);
            cmd.Parameters.AddWithValue("@AccType", Acctype);
            return cmd.ExecuteNonQuery();
        }
        public int updateBal(int bal, String AccNumber)
        {
            con = getCon();

            cmd = new SqlCommand("Update dbo.bank SET Balance = @bal WHERE AccNumber = @AccNumber ", con);
            cmd.Parameters.AddWithValue("@AccNumber", AccNumber);
            cmd.Parameters.AddWithValue("@bal", bal);

            return cmd.ExecuteNonQuery();
        }

        public SBAccount? getAcc(String AccNumber)
        {
            SBAccount ba = new SBAccount();

            try
            {
                con = getCon();

                cmd = new SqlCommand("select * from dbo.bank  WHERE AccNumber = @AccNumber ", con);
                cmd.Parameters.AddWithValue("@AccNumber", AccNumber);
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ba.SetAccountNumber(rdr.GetString(1));
                    ba.AccountHolderName = rdr.GetString(2);
                    ba.TypeofAccount = rdr.GetString(3);
                    ba.DateofCreation = DateTime.Now;//DateTime.Parse(rdr.GetString(4));
                    ba.Balance = Convert.ToInt32(rdr.GetString(5));


                }
                return ba;
            }
            catch (Exception e)
            {
                return null;
            }

        }


    }
}