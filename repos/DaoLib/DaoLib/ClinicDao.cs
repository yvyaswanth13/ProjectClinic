
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BeanLib;
namespace DaoLib
{
    public class ClinicDAO
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public List<Doctor> doc;
        public List<Appointment> apps;
        public ClinicDAO()
        {
            try
            {
                // Creating Connection  

                con = getCon();
             //   Console.WriteLine("Connection Established Successfully");
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
        public int checkPatientId(int id)
        {
            try
            {
                con = getCon();

                cmd = new SqlCommand("SELECT COUNT(*) from dbo.patients where patientId=@patientId", con);

                cmd.Parameters.AddWithValue("@patientId", id);


                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public List<Doctor> getAllDoct()
        {
            doc = new List<Doctor>();
            //doc.Add(new Doctor(123,"Rama","Arjunan","M","General","13:00","18:00"));
            //doc.Add(new Doctor(113, "Laxman", "D", "M", "General", "13:00", "18:00"));
            //doc.Add(new Doctor(423, "Ravana", "L", "M", "Orthopedics", "13:00", "18:00"));
            try
            {
                con = getCon();

                cmd = new SqlCommand("select * from dbo.doctor", con);
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //(13,'Raja','Vikram','M','General','11:00','12:00')
                    Doctor doctor = new Doctor();
                    doctor.DoctorId = rdr.GetInt32(0);
                    doctor.FName = rdr.GetString(1);
                    doctor.LName = rdr.GetString(2);
                    doctor.Sex = rdr.GetString(3);
                    doctor.Specialization = rdr.GetString(4);
                    doctor.VisitingHour = rdr[5].ToString();
                    doctor.LeavingHour = rdr[6].ToString();
                    doc.Add(doctor);
                }
                return doc;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return doc;
            }
            
        }
        public int AddPatient(Patient p)
        {
            try
            {

                Patient pat = new Patient();
                con = getCon();

                cmd = new SqlCommand("insert into dbo.patients (patientId,fname,lname,sex,age,dob) values(@patientId,@fname,@lname, @sex,@age,@dob)", con);


                cmd.Parameters.AddWithValue("@patientId", p.PatientId);
                cmd.Parameters.AddWithValue("@fname", p.FName);
                cmd.Parameters.AddWithValue("@lname", p.LName);
                cmd.Parameters.AddWithValue("@sex", p.Sex);
                cmd.Parameters.AddWithValue("@age", p.Age);
                cmd.Parameters.AddWithValue("@dob", p.Dob.ToShortDateString());





                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return 0;
            }
        }
        public int ScheduleApp(Appointment app)
        {

            try
            {

                con = getCon();

                cmd = new SqlCommand("insert into dbo.appointments (appId,patientId,doctorId,specializationRequired,visit,appointmentTime) values(@appId,@patientId,@doctorId,@specializationRequired,@visit,@appointmentTime)", con);

                cmd.Parameters.AddWithValue("@appId", app.AppId);
                cmd.Parameters.AddWithValue("@patientId", app.PatientId);
                cmd.Parameters.AddWithValue("@doctorId", app.DocId);
                cmd.Parameters.AddWithValue("@specializationRequired", app.SpecializationRequired);
                cmd.Parameters.AddWithValue("@visit", app.Visit.ToShortDateString());
                cmd.Parameters.AddWithValue("@appointmentTime", app.AppointmentTime);

                return cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                Console.WriteLine("enter correct patient_Id/doctor_Id ");

                return 0;
            }

        }

        public int cancelApp(int appId)
        {
            try
            {

                con = getCon();

                cmd = new SqlCommand("delete dbo.appointments where appId = @appId ", con);

                cmd.Parameters.AddWithValue("@appId", appId);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                
                Console.WriteLine("AppointMent Id Not Found");

                return 0;
            }

        }

        public List<Appointment> appById(int pid)
        {
            apps = new List<Appointment>();
            try
            {
                con = getCon();

                cmd = new SqlCommand("select * from dbo.appointments where patientId=@patientId ", con);
                cmd.Parameters.AddWithValue("@patientId", pid);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //(13,'Raja','Vikram','M','General','11:00','12:00')
                    Appointment app = new Appointment();
                    app.AppId = rdr.GetInt32(0);
                    app.PatientId = rdr.GetInt32(1);
                    app.DocId = rdr.GetInt32(2);
                    app.SpecializationRequired = rdr.GetString(3);
                    app.Visit = DateTime.Parse(rdr[4].ToString());
                    app.AppointmentTime = rdr[5].ToString();
                    apps.Add(app);
                }
                return apps;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return apps;
            }


        }

        public int UserValidation(Users u)
        {
            try
            {
                con = getCon();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM users WHERE UserName = @UserName and password = @password", con);
                cmd.Parameters.AddWithValue("@UserName", u.userId);
                cmd.Parameters.AddWithValue("@password", u.Password);


                return Convert.ToInt32( cmd.ExecuteScalar());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
           // return 1;
        }
    }
}
