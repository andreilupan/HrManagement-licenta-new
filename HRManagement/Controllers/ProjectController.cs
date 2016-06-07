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
    public class ProjectController : Controller
    {
        private IProjectService _projectService;
        private IExcelExporter _projectExporter;
        private HrContext db = new HrContext();
        public ProjectController(IProjectService projectService, IExcelExporter projectExporter)
        {
            _projectService = projectService;
            _projectExporter = projectExporter;
        }

        // GET: Project
        public ActionResult Index()
        {
            var model = new ViewModels.Project.ProjectIndexDataViewModel
            {
                Projects = _projectService.GetAllProjects(),
            };

            return View(model);
        }

        [Route("Project/EmployeesAssignedToProjects/{projectId}")]
        public ActionResult EmployeesAssignedToProjects(int projectId)
        {
            var model = new ViewModels.Project.ProjectIndexDataViewModel
            {
                Projects = _projectService.GetAllProjects(),
                EmployeesAssignedToProjects = _projectService.GetEmployeesForProject(projectId)
            };

            return View("Index", model);
        }

        // GET: Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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

        public class ProjectExportViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Employees { get; set; }
        }

        [HttpGet, ActionName("ExportProjects")]
        public FileResult ExportProjects()
        {
            var projects = db.Projects.ToList().Select(x => new ProjectExportViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Employees = x.Employees.Any() ? x.Employees.Select(y => y.FullName).Aggregate((current, next) => current + " , " + next) : "",


            }).ToList();
            var url = _projectExporter.ExportProjects(projects, "projects");
            return File(url, "application/vnd.ms-excel", "projects.xlsx");
        }
    }
}
