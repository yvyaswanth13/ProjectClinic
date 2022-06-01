using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicMgmtSys
{
   public class Patient
    {
        private int patientId;
        private string fName;// (No special characters allowed)
        private string lName;// (No special characters allowed)
        private string sex;// (Choices - M/F/Others)
        private int age;
        private DateTime dob;


        private DateTime visitDate;// (DD/MM/YYYY – Indian format)

        public Patient()
        {
        }

        public Patient(int patientId, DateTime visitDate, List<Appointment> allAppList)
        {
           this. patientId = patientId;
            this.visitDate = visitDate;
            this.allAppList = allAppList;
           
        }

        public Patient(int patientId, string fName, string lName, string sex, int age, DateTime dob)
        {
            this.patientId = patientId;
            this.fName = fName;
            this.lName = lName;
            this.sex = sex;
            this.age = age;
            this.dob = dob;
             }

        public List<Appointment> allAppList { get; }
        public int PatientId { get => patientId; set => patientId = value; }
        public DateTime VisitDate { get => visitDate; set => visitDate = value; }
        public string FName { get => fName; set => fName = value; }
        public string LName { get => lName; set => lName = value; }
        public string Sex { get => sex; set => sex = value; }
        public int Age { get => age; set => age = value; }
        public DateTime Dob { get => dob; set => dob = value; }
    }
}
