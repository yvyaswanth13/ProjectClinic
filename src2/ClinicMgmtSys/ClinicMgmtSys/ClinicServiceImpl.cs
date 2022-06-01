//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ClinicMgmtSys
//{
//    public class ClinicService
//    {
//        public List<Doctor> doc;
//        public ClinicDAO dAO;
//        public int ScheduleApp(Appointment app)
//        {
//            dAO = new ClinicDAO();

//            return dAO.ScheduleApp(app);
//        }
//        public List<Doctor>bySpec(string spec)
//        {
//            dAO = new ClinicDAO();
//            doc = new List<Doctor>();
           
//            foreach(var d in dAO.getAllDoct())
//            {
//                if(d.Specialization.Equals(spec))
//                {
//                    doc.Add(d);
//                }
//            }
//            return doc;
//        }
//        public List<Appointment> getbyId(int pid)
//        {
//            dAO = new ClinicDAO();
//            return dAO.appById(pid);
//        }
//        public int addPatient(Patient p)
//        {
//            dAO = new ClinicDAO();
//          return dAO.AddPatient(p);
//        }
//        public List<Doctor>getAllDoctos()
//        {
//            dAO = new ClinicDAO();
//            return dAO.getAllDoct();
            
//        }
//    }
//}
