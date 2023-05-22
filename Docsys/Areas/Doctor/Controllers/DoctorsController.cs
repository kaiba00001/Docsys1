using Microsoft.AspNetCore.Mvc;

namespace Docsys.Areas.Doctor.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
