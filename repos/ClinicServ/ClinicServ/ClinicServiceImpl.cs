using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeanLib;
using DaoLib;

namespace ClinicServ
{
    public class ClinicServiceImpl
    {
        public List<BeanLib.Doctor> doc;
        public ClinicDAO dAO;
        public int ScheduleApp(BeanLib.Appointment app)
        {
            dAO = new ClinicDAO();
            Appointment dapp = new Appointment(app.AppId,app.DocId,app.PatientId,app.SpecializationRequired,app.Visit,app.AppointmentTime);
            return dAO.ScheduleApp(dapp);
        }
        public List<BeanLib.Doctor> bySpec(string spec)
        {
            dAO = new ClinicDAO();
            doc = new List<BeanLib.Doctor>();

            foreach (var d in dAO.getAllDoct())
            {
                if (d.Specialization.Equals(spec))
                {
                    doc.Add(new BeanLib.Doctor(d.DoctorId,d.FName,d.LName,d.Sex,d.Specialization,d.VisitingHour,d.LeavingHour));
                }
            }
            return doc;
        }
        public List<Appointment> getbyId(int pid)
        {
            dAO = new ClinicDAO();
            return dAO.appById(pid);
        }
        public int addPatient(BeanLib.Patient p)
        {
            dAO = new ClinicDAO();
            try
            {
                return dAO.AddPatient(new Patient(p.PatientId, p.FName, p.LName, p.Sex, p.Age, p.Dob));
            }
            catch(Exception E)

            {
                
                Console.WriteLine("Patient ID Already Exists");

                return 0;
            }
        }
        public List<BeanLib.Doctor> getAllDoctos()
        {
            List<BeanLib.Doctor>doctor =new List<BeanLib.Doctor>();
               dAO = new ClinicDAO();
            foreach(var d in dAO.getAllDoct())
            {
                doctor.Add(new BeanLib.Doctor(d.DoctorId, d.FName, d.LName, d.Sex, d.Specialization, d.VisitingHour, d.LeavingHour));

            }
            return doctor;

        }
        public Boolean UserCheck(Users u)
        {
            dAO = new ClinicDAO();
            
            
                int valid = dAO.UserValidation(u);
                if (valid == 1)
                    return true;
                else
                    return false;
                
        }
        public int checkpid(int id)
        {
            dAO = new ClinicDAO();
            return dAO.checkPatientId(id);
        }
    }
}

//namespace ClinicServ
//{
//    public class ClinicServiceImpl
//    {
//    }
//}
