using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRManagement.DataAccess;
using HRManagement.DataAccess.Models.Models;
using HRManagement.Application;

namespace HRManagement.Controllers
{
    [Authorize]
    public class TrainingController : Controller
    {
        private ITrainingService _trainingService;
        private IExcelExporter _trainingExporter;
        private HrContext db = new HrContext();
        public TrainingController(ITrainingService trainingService, IExcelExporter trainingExporter)
        {
            _trainingService = trainingService;
            _trainingExporter = trainingExporter;
        }

        // GET: Training
        public ActionResult Index()
        {
            var model = new ViewModels.Training.TrainingIndexDataViewModel
            {
                Trainings = _trainingService.GetAllTrainings(),
            };

            return View(model);
        }

        public ActionResult EmployeesAssignedToTraining(int? trainingId)
        {
            var model = new ViewModels.Training.TrainingIndexDataViewModel
            {
                Trainings = _trainingService.GetAllTrainings(),
                EmployeesAssignedToTrainings = _trainingService.GetEmployeesForTraining(trainingId)
            };

            return View("Index", model);
        }

        // GET: Training/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            return View(training);
        }

        // GET: Training/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Training/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StartDate,EndDate,Status")] Training training)
        {
            if (ModelState.IsValid)
            {
                db.Trainings.Add(training);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(training);
        }

        // GET: Training/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            return View(training);
        }

        // POST: Training/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StartDate,EndDate,Status")] Training training)
        {
            if (ModelState.IsValid)
            {
                db.Entry(training).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(training);
        }

        // GET: Training/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            return View(training);
        }

        // POST: Training/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Training training = db.Trainings.Find(id);
            db.Trainings.Remove(training);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public class TrainingExportViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Status { get; set; }
            public string Employees { get; set; }
        }

        [HttpGet, ActionName("ExportTrainings")]
        public FileResult ExportTrainings()
        {
            var trainings = db.Trainings.ToList().Select(x => new TrainingExportViewModel
            {
                Id = x.Id,
                Name = x.Name,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Status = x.Status.ToString(),
                Employees = x.Employees.Any() ? x.Employees.Select(y => y.FullName).Aggregate((current, next) => current + " , " + next) : "",
                

            }).ToList();
            var url = _trainingExporter.ExportTrainings(trainings, "trainings");
            return File(url, "application/vnd.ms-excel", "trainings.xlsx");
        }
    }
}
