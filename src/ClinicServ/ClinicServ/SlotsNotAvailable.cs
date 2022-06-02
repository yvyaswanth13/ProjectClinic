using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServ
{
    public class SlotsNotAvailable : Exception
    {
        public SlotsNotAvailable()
        {
        }

        public SlotsNotAvailable(string message) : base(message)
        {
        }
    }
}
