using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HRManagement.DataAccess;
using HRManagement.DataAccess.Models.Models;
using HRManagement.Application;

namespace HRManagement.Controllers
{
    [Authorize]
    public class PositionsController : Controller
    {
        private IPositionService _positionService;
        private IExcelExporter _positionExporter;
        public HrContext db = new HrContext();

        public PositionsController(IPositionService positionService, IExcelExporter positionExporter)
        {
            _positionService = positionService;
            _positionExporter = positionExporter;
        }

        // GET: Positions
        public ActionResult Index()
        {
            var model = new ViewModels.Position.PositionIndexDataViewModel
            {
                Positions = _positionService.GetAllPositions(),
            };

            return View(model);
        }

        [Route("Positions/EmployeesAssignedToPosition/{positionId}")]
        public ActionResult EmployeesAssignedToPosition(int positionId)
        {
            var model = new ViewModels.Position.PositionIndexDataViewModel
            {
                Positions = _positionService.GetAllPositions(),
                EmployeesAssignedToPosition = _positionService.GetEmployeesForPosition(positionId)
            };

            return View("Index", model);
        }

        // GET: Positions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // GET: Positions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Technology,LevelOfExperience")] Position position)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Add(position);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(position);
        }

        // GET: Positions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Technology,LevelOfExperience")] Position position)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        // GET: Positions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Position position = db.Positions.Find(id);
            db.Positions.Remove(position);
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

        public class PositionExportViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Technology { get; set; }
            public string LevelOfExperience { get; set; }
            public string Employees { get; set; }
        }

        [HttpGet, ActionName("ExportPositions")]
        public FileResult ExportPositions()
        {
            var positions = db.Positions.ToList().Select(x => new PositionExportViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Technology = x.Technology,
                LevelOfExperience = x.LevelOfExperience.ToString(),
                Employees = x.Employees.Any() ? x.Employees.Select(y => y.FullName).Aggregate((current, next) => current + " , " + next) : "",


            }).ToList();
            var url = _positionExporter.ExportPositions(positions, "positions");
            return File(url, "application/vnd.ms-excel", "positions.xlsx");
        }
    }
}
