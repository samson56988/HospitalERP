using HospitalERP.IServices;
using HospitalERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HospitalERP.Controllers
{
    public class AdminController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        protected readonly IConfiguration _config;
        protected readonly IAdminServices _adminServices;
        public AdminController(IConfiguration configuration, IAdminServices adminServices)
        {
            _config = configuration;
            _adminServices = adminServices;
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public async Task<IActionResult> Doctors()
        {
            var doctor = await _adminServices.AllDoctors();
            return View(doctor);
        }
        public IActionResult AddDoctor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {
            doctor.Role = "Doctor";
            doctor.D_Fullname = doctor.D_Firstname + "  " +doctor.D_Middlename + "  " + doctor.D_Lastname;
            _adminServices.AddDoctor(doctor);
            _adminServices.AddLoginDetails(doctor);
            return View("Doctors");
        }
        public IActionResult AddNurse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNurse(Nurse nurse)
        {
            nurse.Role = "Nurse";
            nurse.N_Fullname = nurse.N_Firstname +  " " + nurse.N_Middlename + " " + nurse.N_Lastname;
            _adminServices.AddNurse(nurse);
            _adminServices.AddLoginNurseDetails(nurse);
            return View("Nurses");
        }
        public async Task<IActionResult> Nurses()
        {
            var nurse = await _adminServices.AllNurse();
            return View(nurse);
        }

    }
}
