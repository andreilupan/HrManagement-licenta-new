using HRManagement.Application;
using HRManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRManagement.Controllers
{
    public class DocumentsController : Controller
    {
        private IEmployeeService _employeeService;
        public HrContext db = new HrContext();

        public DocumentsController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: Documents
        public ActionResult Index()
        {
            var model = _employeeService.GetAllEmployees();
            return View(model);
        }

        // GET: Documents/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Documents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Documents/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Documents/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Documents/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Documents/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Documents/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
