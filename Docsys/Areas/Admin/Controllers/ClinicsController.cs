using Clinic.Services;
using Clinic.Utilities;
using Clinic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Docsys.Areas.Admin.Controllers
{
    [Area("admin")]

    public class ClinicsController : Controller
    {
        public IClinicInfo _clinicInfo;

        public ClinicsController(IClinicInfo clinicInfo)
        {
            _clinicInfo = clinicInfo;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_clinicInfo.GetAll(pageNumber, pageSize));
        }

        [HttpGet]

        public IActionResult Edit(int id)
        { 
            var viewModel = _clinicInfo.GetClinicById(id);
            return View(viewModel);
        }

        [HttpPost]

        public IActionResult Edit(ClinicInfoViewModel vm)
        {
            _clinicInfo.UpdateClinicInfo(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(ClinicInfoViewModel vm)
        {
            _clinicInfo.InsertClinicInfo(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _clinicInfo.DeleteClinicInfo(id);
            return RedirectToAction("Index");
        }


    }
}
