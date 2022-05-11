using HospitalERP.IServices;
using HospitalERP.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HospitalERP.Controllers
{
    public class AuthenticationController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        protected readonly IConfiguration _config;
        protected readonly IAuthenticationServices _authenticationServices;
        public AuthenticationController(IConfiguration configuration,IAuthenticationServices authenticationServices)
        {
            _config = configuration;
            _authenticationServices = authenticationServices;
        }
        void connectionString()
        {
            con.ConnectionString = _config.GetConnectionString("HospialDB");
        }
        public IActionResult Login()
        {
            return View();
        }    
        [HttpPost]
        public IActionResult Login(Login login)
        {
                       
            _authenticationServices.UserLogin(login);            
            if(login.Response == "Invalid Login Details")
            {
                RedirectToAction("Login");
            }
            else
            {
                if(login.Role == "Admin")
                {
                    HttpContext.Session.SetString("Username", login.Username);
                    return RedirectToAction("Dashboard","Admin");
                }
                if (login.Role == "Nurse")
                {
                    HttpContext.Session.SetString("Username", login.Username);
                    return RedirectToAction("Dashboard", "Admin");
                }
                if (login.Role == "Doctor")
                {
                    HttpContext.Session.SetString("Username", login.Username);
                    return RedirectToAction("Dashboard", "Admin");
                }
            }
            return View();
              
            

        }

        
        





    }
}
