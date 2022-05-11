using HospitalERP.IServices;
using HospitalERP.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace HospitalERP.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        protected readonly IConfiguration _config;
        public AuthenticationServices(IConfiguration configuration)
        {
            _config = configuration;
        }
        void connectionString()
        {
            con.ConnectionString = _config.GetConnectionString("HospialDB");
        }
        public Login UserLogin(Login login)
        {
            login.Role = "";
            SqlDataReader dr;
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * from UserTbl where Username = '" + login.Username + "'and Password = '" + login.Password + "' and IsActive = 'Yes'";
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    login.Username = dr["Username"].ToString();
                    login.Role = dr["Role"].ToString();
                }               
            }
            else
            {
                login.Response = "Invalid Login Details";
            }
            return login;
           
        }
    }
}
