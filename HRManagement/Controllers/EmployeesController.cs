using System.Net;
using System.Web.Mvc;
using HRManagement.DataAccess;
using HRManagement.DataAccess.Models.Models;
using HRManagement.Application;
using HRManagement.ViewModels.Employee;
using System.Linq;
using System;

namespace HRManagement.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private IEmployeeService _employeeService;
        public HrContext db = new HrContext();
        private ImageService _imageService;
        private IExcelExporter _employeeExporter;
        private ITrainingService _trainingService;

        public EmployeesController(IEmployeeService employeeService, ImageService imageService, IExcelExporter employeeExporter, ITrainingService trainingService)
        {
            _employeeService = employeeService;
            _imageService = imageService;
            _employeeExporter = employeeExporter;
            _trainingService = trainingService;
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
        // GET: Employees
        public ActionResult Index()
        {
            var model = _employeeService.GetAllEmployees();
            return View(model);
        }

        // GET: Employees/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            var model = _employeeService.GetEmployeeForCreate();
            return View(model);
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEmployeeViewModel input)
        {
            var employeeId = _employeeService.CreateEmployee(input);
            var imageUrl = _imageService.SaveEmployeeImage(input.ImageUpload, employeeId);
            _employeeService.AttachImage(employeeId, imageUrl);
            return RedirectToAction("Index");

        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _employeeService.GetEmployeeForEdit(id);

            return View(model);
        }

        //GET: Employees/5/EditEmploymentInformation
        [HttpGet]
        public ActionResult EditEmploymentInformation(int? employeeId)
        {
            if (employeeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _employeeService.GetEmploymentInformationForEdit(employeeId);
            return View("~/Views/Employees/GetEmploymentInformationForEdit.cshtml", model);
        }

        //GET: Employees/5/EditFinancialInformation
        [HttpGet]
        public ActionResult EditFinancialInformation(int? employeeId)
        {
            if (employeeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _employeeService.GetFinancialInformationForEdit(employeeId);
            return View("~/Views/Employees/GetFinancialInformationForEdit.cshtml", model);
        }

        //GET: Employees/5/EditContactInformation
        [HttpGet]
        public ActionResult EditContactInformation(int? employeeId)
        {
            if (employeeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _employeeService.GetContactInformationForEdit(employeeId);
            return View("~/Views/Employees/GetContactInformationForEdit.cshtml", model);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditEmployeeViewModel input)
        {
            _employeeService.SetChangesForEmployee(input.Id, input.PositionId, input.ProjectId, input.LastName, input.MiddleName, input.FirstName, input.DateOfBirth, input.Gender, input.Nationality, input.NationalIdentificationNumber);

            if (input.ImageUpload != null)
            {
                var imageUrl = _imageService.SaveEmployeeImage(input.ImageUpload, input.Id);
                _employeeService.AttachImage(input.Id, imageUrl);
            }

            return RedirectToAction("Index");
        }

        //GET: Employee/5/Trainings
        [HttpGet]
        [Route("employees/{employeeId}/trainings")]
        public ActionResult GetTrainingsForEmployee(int employeeId)
        {
            var model = _employeeService.GetTrainingForEmployee(employeeId);

            return View(model);
        }

        //GET: Employee/5/ContactInformation

        [HttpGet]
        public ActionResult GetContactInformationForEmployee(int employeeId)
        {
            var model = _employeeService.GetContactInformationForEmployee(employeeId);
            return View(model);
        }


        //GET: Employee/5/FinancialInformation

        [HttpGet]
        public ActionResult GetFinancialInformationForEmployee(int employeeId)
        {
            var model = _employeeService.GetFinancialInformationForEmployee(employeeId);
            return View(model);
        }

        //POST: Employees/5/EditEmploymentInformation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmploymentInformation(EditEmploymentInfomationForEmployeeViewModel input)
        {
            _employeeService.EditEmploymentInformation(input.Id, input.EmploymentDate, input.JubileeDate, input.DateForFormalProfessionalCompetence, input.DateForFormalTeachingSkills);
            return RedirectToAction("Index");
        }

        //POST: Employees/5/EditFinancialInformation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFinancialInformation(EditFinancialInformationForEmployeeViewModel input)
        {
            _employeeService.EditFinancialInformation(input.Id, input.Salary, input.NextSalaryIncrease, input.AccountNumber, input.Bank);
            return RedirectToAction("Index");
        }


        //POST: Employees/5/EditContactInformation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditContactInformation(EditContactInformationForEmployeeViewModel input)
        {
            _employeeService.EditContactInformation(input.Id, input.Address, input.City, input.PostalCode, input.State, input.WorkPhone, input.PrivatePhone, input.WorkEmail, input.PrivateEmail);
            return RedirectToAction("Index");
        }

        //GET: Employee/5/EmploymentInformation
        [HttpGet]
        public ActionResult GetEmploymentInformationForEmployee(int employeeId)
        {
            var model = _employeeService.GetEmploymentInformationForEmployee(employeeId);
            return View(model);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet, ActionName("ExportEmployees")]
        public FileResult ExportEmployees()
        {
            var employees = db.Employees.ToList().Select(x => new EmployeeExportViewModel
            {
                Id = x.Id,
                Name = x.FirstName + " " + x.MiddleName +" " + x.LastName,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender.ToString(),
                Nationality = x.Nationality,
                Positions = x.Position.Name,
                Projects = x.Project.Name,
                Trainings = x.Trainings.Any() ? x.Trainings.Select(y => y.Name).Aggregate((current, next) => current + " , " + next) : "",
                Address = x.ContactInformation.Address,
                City = x.ContactInformation.City,
                PostalCode = x.ContactInformation.PostalCode,
                State = x.ContactInformation.State,
                WorkPhone = x.ContactInformation.WorkPhone,
                PrivatePhone = x.ContactInformation.PrivatePhone,
                WorkEmail = x.ContactInformation.WorkEmail,
                PrivateEmail = x.ContactInformation.PrivateEmail,
                EmploymentDate = x.EmploymentInformation.EmploymentDate,
                JubileeDate = x.EmploymentInformation.JubileeDate,
                DateForFormalProfessionalCompetence = x.EmploymentInformation.DateForFormalProfessionalCompetence,
                DateForFormalTeachingSkills = x.EmploymentInformation.DateForFormalTeachingSkills,
                Salary = x.FinancialInformation.Salary,
                NextSalaryIncrease = x.FinancialInformation.NextSalaryIncrease,
                AccountNumber = x.FinancialInformation.AccountNumber,
                Bank = x.FinancialInformation.Bank

            }).ToList();
            var url = _employeeExporter.ExportEmployees(employees, "employees");
            return File(url, "application/vnd.ms-excel", "employees.xlsx");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }

    public class EmployeeExportViewModel
    {
        public int Id { get; set; }
        public string Positions { get; set; }
        public string Trainings { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Projects { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string WorkPhone { get; set; }
        public string PrivatePhone { get; set; }
        public string WorkEmail { get; set; }
        public string PrivateEmail { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime JubileeDate { get; set; }
        public DateTime DateForFormalProfessionalCompetence { get; set; }
        public DateTime DateForFormalTeachingSkills { get; set; }
        public Decimal Salary { get; set; }
        public DateTime NextSalaryIncrease { get; set; }
        public string AccountNumber { get; set; }
        public string Bank { get; set; }
    }
}
