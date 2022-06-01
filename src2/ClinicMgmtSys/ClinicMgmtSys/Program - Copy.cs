//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ClinicMgmtSys
//{
//    public class Program
//    {
//        public ClinicServiceImpl cl;
//        public ClinicDAO dao;
//        public void AppointmentBooking()
//        {
//            Console.WriteLine("Hello World!");
//            Appointment app = new Appointment();
//            cl = new ClinicServiceImpl();
//            Console.WriteLine("Enter Patient Id");
//            int id = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("General \nInternal Medicine\n Pediatrics\n Orthopedics\n Ophthalmology");
//            string spec = Console.ReadLine();
//            List<Doctor> getByspec = cl.bySpec(spec);
//            foreach (var d in getByspec)
//            {
//                Console.WriteLine(d.DoctorId + "- " + d.FName);

//            }
//            int docid = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("Enter AppointMent Date");
//            string date = Console.ReadLine();
//            DateTime appdt;

//            if (!DateTime.TryParseExact(date, "dd/MM/yyyy", null, DateTimeStyles.None, out appdt))
//            {
//                Console.WriteLine("Wrong Date Format");

//            }
//            Console.WriteLine("AppointMent Time");
//            string apptime = Console.ReadLine();

//            int succ = cl.ScheduleApp(new Appointment(docid, id, spec, appdt, apptime));


//        }
//        public void AppointmentCancel()
//        {
//            cl = new ClinicServiceImpl();
//            dao = new ClinicDAO();
//            Console.WriteLine("Enter patien Id");
//            int pid = Convert.ToInt32(Console.ReadLine());
            
//                foreach (var p in cl.getbyId(pid))
//                {
//                    Console.WriteLine(p.AppId + " \t" + p.PatientId + " \t" + " \t" + p.AppointmentTime + " \t" + p.SpecializationRequired);
//                }
            
//            int cid = Convert.ToInt32(Console.ReadLine());
//            int del = dao.cancelApp(cid);
//            if (del == 1)
//            {
//                Console.WriteLine("Success");

//            }
//            else
//            {
//                Console.WriteLine("fail");

//            }
//        }
//        public static void main(string[] args)
//        {
//            Program p = new Program();
//             p.AppointmentBooking();
             

//            ClinicDAO d = new ClinicDAO();
//        foreach(var dc in d.getAllDoct())
//            {
//                Console.WriteLine(dc.DoctorId);
//            }
//            int x = 1;// d.AddPatient(new Patient(138, "Kavya", "Priya", "F", 24, DateTime.Now));
//       if(x==1)
//            {
//                Console.WriteLine("Ok");
//            }
//       else
//            {
//                Console.WriteLine("Not OK");
//            }
//            int x1 = d.ScheduleApp(new Appointment(10, 13, 133, "General", DateTime.Parse("11/3/21"), "11:00"));
//            if (x1 == 1)
//            {
//                Console.WriteLine("Ok Schedule");
//            }
//            else
//            {
//                Console.WriteLine("Not Schedule");
//            }

//            p.AppointmentCancel();


//        }
//    }
//}
