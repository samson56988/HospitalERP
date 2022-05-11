using HospitalERP.IServices;
using HospitalERP.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HospitalERP.Services
{
    public class AdminServices : IAdminServices
    {
        protected readonly IConfiguration _config;
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        IList<Doctor> _doctor = new List<Doctor>();
        IList<Nurse> _nurses = new List<Nurse>();
        public AdminServices(IConfiguration config)
        {
            _config = config;
            ConnectionString = _config.GetConnectionString("HospialDB");
            ProviderName = "System.Data.SqlClient";
        }
        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }
        public Doctor AddDoctor(Doctor doctor)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("Insert_Doctor", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@D_EmpID ", doctor.D_ID);
                cmd2.Parameters.AddWithValue("@D_Firstname", doctor.D_Firstname);
                cmd2.Parameters.AddWithValue("@D_Middlename", doctor.D_Middlename);
                cmd2.Parameters.AddWithValue("@D_Lastname", doctor.D_Lastname);
                cmd2.Parameters.AddWithValue("@D_Address", doctor.D_Address);
                cmd2.Parameters.AddWithValue("@D_Phone", doctor.D_Phone);
                cmd2.Parameters.AddWithValue("@D_Speciality", doctor.D_Speciality);
                cmd2.Parameters.AddWithValue("@D_Dob", doctor.D_Dob);
                cmd2.Parameters.AddWithValue("@D_Fullname", doctor.D_Fullname);
                cmd2.ExecuteNonQuery();
            }
            return doctor;
        }
        public Doctor AddLoginDetails(Doctor doctor)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("InsertUserDetails", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@UserID", doctor.UserID);
                cmd2.Parameters.AddWithValue("@Username", doctor.Username);
                cmd2.Parameters.AddWithValue("@Password", doctor.Password);
                cmd2.Parameters.AddWithValue("@Role", doctor.Role);
                cmd2.Parameters.AddWithValue("@EmployeeID", doctor.D_ID);
                cmd2.ExecuteNonQuery();
            }
            return doctor;
        }
        public Nurse AddLoginNurseDetails(Nurse nurse)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("InsertUserDetails", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@UserID", nurse.UserID);
                cmd2.Parameters.AddWithValue("@Username", nurse.Username);
                cmd2.Parameters.AddWithValue("@Password", nurse.Password);
                cmd2.Parameters.AddWithValue("@Role", nurse.Role);
                cmd2.Parameters.AddWithValue("@EmployeeID", nurse.N_ID);
                cmd2.ExecuteNonQuery();
            }
            return nurse;
        }
        public Nurse AddNurse(Nurse nurse)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("Insert_Nurse", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@N_EmpID ", nurse.N_ID);
                cmd2.Parameters.AddWithValue("@N_Firstname", nurse.N_Firstname);
                cmd2.Parameters.AddWithValue("@N_Middlename", nurse.N_Middlename);
                cmd2.Parameters.AddWithValue("@N_Lastname", nurse.N_Lastname);
                cmd2.Parameters.AddWithValue("@N_Address", nurse.N_Address);
                cmd2.Parameters.AddWithValue("@N_Phone", nurse.N_Phone);
                cmd2.Parameters.AddWithValue("@N_Speciality", nurse.N_Speciality);
                cmd2.Parameters.AddWithValue("@N_Dob", nurse.N_Dob);
                cmd2.Parameters.AddWithValue("@N_Fullname", nurse.N_Fullname);
                cmd2.ExecuteNonQuery();
            }
            return nurse;
        }
        public async Task<IEnumerable<Doctor>> AllDoctors()
        {
            _doctor = new List<Doctor>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetDoctor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Doctor doctor = new Doctor();
                    doctor.D_ID = rdr["D_EmpID"].ToString();
                    doctor.D_Fullname = rdr["D_Fullname"].ToString();
                    doctor.D_Address = rdr["D_Address"].ToString();
                    doctor.D_Phone = rdr["D_PhoneNo"].ToString();
                    doctor.D_Speciality = rdr["D_Speciality"].ToString();
                    _doctor.Add(doctor);
                }
                rdr.Close();
            }
            return await Task.FromResult(_doctor);
        }
        public async Task<IEnumerable<Nurse>> AllNurse()
        {
            _nurses = new List<Nurse>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetNurse", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Nurse nurse = new Nurse();
                    nurse.N_ID = rdr["N_EmpID"].ToString();
                    nurse.N_Fullname = rdr["N_Fullname"].ToString();
                    nurse.N_Address = rdr["N_Address"].ToString();
                    nurse.N_Phone = rdr["N_PhoneNo"].ToString();
                    nurse.N_Speciality = rdr["N_Speciality"].ToString();
                    _nurses.Add(nurse);
                }
                rdr.Close();
            }
            return await Task.FromResult(_nurses);
        }
    }
}
