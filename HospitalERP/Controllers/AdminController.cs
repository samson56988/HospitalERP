using Microsoft.AspNetCore.Mvc;

namespace HospitalERP.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Doctor()
        {
            return View();
        }

    }
}
