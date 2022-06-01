using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanLib
{
    public class Users
    {
        public string userId;
        public string Fname;
        public string LName;
        public string Password;

        public Users()
        {
        }

        public Users(string userId, string fname, string lName, string password)
        {
            this.userId = userId;
            Fname = fname;
            LName = lName;
            Password = password;
        }
        public Users(string userId, string password)
        {
            this.userId = userId;
            Password = password;
        }
    }
}
