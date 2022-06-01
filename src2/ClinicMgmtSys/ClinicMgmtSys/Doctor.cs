using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicMgmtSys
{
   public class Doctor
    {
        private int doctorId;//;(auto generated number by the system, not editable by the users)
        private string fName;// (No special characters allowed)
        private string lName;// (No special characters allowed)
        private string sex;// (Choices - M/F/Others)
        private string specialization;// (Choices – General, Internal Medicine, Pediatrics, Orthopedics, Ophthalmology)
        private string visitingHour;// (Doctors can visit for 1hr, 2hrs, 3hrs etc., and not 1:30hrs or 1:15 or 1:45hrs)
        private string leavingHour;
        public int DoctorId { get => doctorId; set => doctorId = value; }
        public string FName { get => fName; set => fName = value; }
        public string LName { get => lName; set => lName = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Specialization { get => specialization; set => specialization = value; }
        public string VisitingHour { get => visitingHour; set => visitingHour = value; }
        public string LeavingHour { get => leavingHour; set => leavingHour = value; }

        public Doctor()
        {
        }

        public Doctor(int doctorId, string fName, string lName, string sex, string specialization, string visitingHour, string leavingHour)
        {
            this.doctorId = doctorId;
            this.fName = fName;
            this.lName = lName;
            this.sex = sex;
            this.specialization = specialization;
            this.visitingHour = visitingHour;
            this.leavingHour = leavingHour;
        }

    }
}
