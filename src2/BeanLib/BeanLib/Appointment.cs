using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanLib
{
   public class Appointment
    {
        private int appId;
        private int docId;
        private int patientId;
        private string specializationRequired;
        private DateTime visit;
        private string appointmentTime;// (Show the specific time slots available for the doctor for the given date, each slot is 1 hour)

        public int AppId { get => appId; set => appId = value; }
        public int DocId { get => docId; set => docId = value; }
        public int PatientId { get => patientId; set => patientId = value; }
        public string SpecializationRequired { get => specializationRequired; set => specializationRequired = value; }
        public DateTime Visit { get => visit; set => visit = value; }
        public string AppointmentTime { get => appointmentTime; set => appointmentTime = value; }

        public Appointment()
        {
        }

        public Appointment(int docId, int patientId, string specializationRequired, DateTime visit, string appointmentTime)
        {
            
            this.docId = docId;
            this.patientId = patientId;
            this.specializationRequired = specializationRequired;
            this.visit = visit;
            this.appointmentTime = appointmentTime;
        }
        public Appointment(int appId,int docId, int patientId, string specializationRequired, DateTime visit, string appointmentTime)
        {
            this.appId = appId;
            this.docId = docId;
            this.patientId = patientId;
            this.specializationRequired = specializationRequired;
            this.visit = visit;
            this.appointmentTime = appointmentTime;
        }
    }
}
