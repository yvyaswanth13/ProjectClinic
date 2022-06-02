using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeanLib;
using ClinicServ;
using DaoLib;
using System.Threading;
namespace ClinicMgmtSys
{
    public class Program
    {
        public ClinicServiceImpl cl;
        public ClinicDAO dao;
        public void AppointmentBooking()
        {
            try
            {
                dao = new ClinicDAO();
                Appointment app = new Appointment();
                cl = new ClinicServiceImpl();
                Console.WriteLine("Enter AppointMent Id");
                int appid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Patient Id");
                int pid = Convert.ToInt32(Console.ReadLine());
                if (cl.checkpid(pid) != 1)
                {
                    throw new Exception("Patient Id Not Found");
                }
                else
                {
                    Console.WriteLine("General \nInternal Medicine\n Pediatrics\n Orthopedics\n Ophthalmology\n");
                    Console.WriteLine("Above Specializations are available");

                    string spec = Console.ReadLine();
                    List<BeanLib.Doctor> getByspec = cl.bySpec(spec);
                    Console.WriteLine("Below Doctors having Specialization ");
                    foreach (var d in getByspec)
                    {
                        Console.WriteLine(d.DoctorId + "- " + d.FName +"- timings:"+d.VisitingHour+"-"+d.LeavingHour);

                    }
                    Console.WriteLine("\n Enter Doctor Id");
                    int docid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter AppointMent Date");
                    string date = Console.ReadLine();
                    DateTime appdt;

                    if (!DateTime.TryParseExact(date, "dd/MM/yyyy", null, DateTimeStyles.None, out appdt))
                    {
                        Console.WriteLine("Wrong Date Format");

                    }
                        List<string> dt = cl.checkAvailability(docid, appdt);

                    if (cl.availablehrs != cl.count)
                    {
                        //Console.WriteLine(DateTime.Parse("11/04/2021") + "-" + dt.Count);
                        foreach (var str in dt)
                        {
                            Console.Write(str + "\t");
                        }
                        Console.WriteLine("\nAppointMent Time");
                        string apptime = Console.ReadLine();

                        int succ = cl.ScheduleApp(new BeanLib.Appointment(appid, docid, pid, spec, appdt, apptime));
                        if (succ == 1)
                        {
                            Console.WriteLine("Ok Schedule");
                        }
                        else
                        {
                            Console.WriteLine("Not Schedule");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Checking again...........\n");
                        Thread.Sleep(1500);
                        throw new SlotsNotAvailable("Yes...Currently No Slots are Avilable this Date!");

                    }
                }
            }
            catch (SlotsNotAvailable sna)
            {
                Console.WriteLine(sna.Message);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void AppointmentCancel()
        {
            cl = new ClinicServiceImpl();
            dao = new ClinicDAO();
            Console.WriteLine("Enter patien Id");
            int pid = Convert.ToInt32(Console.ReadLine());
            
                foreach (var p in cl.getbyId(pid))
                {
                    Console.WriteLine(p.AppId + " \t" + p.PatientId + " \t" + " \t" + p.AppointmentTime + " \t" + p.SpecializationRequired);
                }
            
            int cid = Convert.ToInt32(Console.ReadLine());
            int del = dao.cancelApp(cid);
            if (del == 1)
            {
                Console.WriteLine("Success");

            }
            else
            {
                Console.WriteLine("fail");

            }
        }

        public void addPatient()
        {
            cl = new ClinicServiceImpl();
            Console.WriteLine("ENter Patient Id");
            int pid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Fname and LName");
            string fname=Console.ReadLine();
            string lname=Console.ReadLine();
            Console.WriteLine("Enter Gender");

            string gen = Console.ReadLine();
            Console.WriteLine("Enter Age");

            int age = Convert.ToInt32(Console.ReadLine());
            int x =  cl.addPatient(new BeanLib.Patient(pid, fname, lname, gen, age, DateTime.Now));
            if (x == 1)
            {
                Console.WriteLine("Patient Added SuccessFully");
            }
            else
            {
                Console.WriteLine("PatientNot Added");
            }

        }
        public void getDocDetails()
        {
            cl = new ClinicServiceImpl();
           foreach (var doctor in cl.getAllDoctos())
            {
                Console.WriteLine(doctor.DoctorId+"\t"+ doctor.FName+"\t"+doctor.LName+"\t"+ doctor.Specialization);
            }
        }
        public Boolean frontEndValidation(Users u)
        {
            if (u.userId != null && u.Password != null)
            {
                if (u.userId.Length > 10)
                {
                    
                        if (u.Password.Contains('@'))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    
                }
                else
                {
                    return false;
                }
            }
            
            else
            {
                return false;
            }
        }
       
        public static void Main(string[] args)
        {
            Program p = new Program();
             Console.WriteLine("User and Passwor are Case Sensitive ");
             Console.WriteLine("Enter User: ");
             string uname = Console.ReadLine();

             Console.WriteLine("Enter Password: ");
             string pass = Console.ReadLine();
             Users u = new Users(uname, pass);
             ClinicServiceImpl c = new ClinicServiceImpl();
             if (p.frontEndValidation(u)&& c.UserCheck(u))
             {

             Console.WriteLine("Enter Your option \t\n1.Add Patient \n 2.Doctor Details \n 3.Book Appointment \n 4.Cancel AppointMent \n 5.LogOut");

                 int op = Convert.ToInt32(Console.ReadLine());
                 switch (op)
                 {
                     case 1:
                         {
                             p.addPatient();

                             break;
                         }
                     case 2:
                         {
                             p.getDocDetails();
                             break;
                         }
                     case 3:
                         {
                             p.AppointmentBooking();
                             break;
                         }
                     case 4:
                         {
                             p.AppointmentCancel();
                             break;
                         }
                     case 5:
                         {
                             Console.WriteLine("LogOut SuccessFully");
                             break;
                         }

                     default:
                         {
                             Console.WriteLine("InValid Input");
                             break;
                         }

                 }
             }
             else
             {
                 Console.WriteLine("Invalid Credentials");
             }

        }
    }
}
