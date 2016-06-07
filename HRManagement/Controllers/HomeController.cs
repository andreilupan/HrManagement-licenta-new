using HRManagement.Application;
using HRManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IEmployeeService _employeeService;

        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public ActionResult Index()
        {
            var data = _employeeService.GetAllEmployees();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}