using DIApp.BusinessLayer.Facade;
using System;
using System.IO;
using System.Web.Mvc;

namespace DIApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeFacade _employeeFacade;

        public HomeController(IEmployeeFacade employeeFacade)
        {
            this._employeeFacade = employeeFacade;
        }

        [HttpGet]
        public ActionResult Index(string country = "USA")
        {
            ViewBag.Countries = this._employeeFacade.GetEmployeeCountries();
            return View(this._employeeFacade.GetEmployeesByCountry(country));
        }

        [HttpGet]
        public FileResult RenderImage(int id)
        {
            var employee = this._employeeFacade.GetEmployeeById(id);
            byte[] photo = employee.Photo;
            MemoryStream ms = new MemoryStream();
            // Some OleDB image format hacking
            ms.Write(photo, 78, photo.Length - 78);
            ms.Position = 0;
            return File(ms, "image/jpeg");
        }
    }
}