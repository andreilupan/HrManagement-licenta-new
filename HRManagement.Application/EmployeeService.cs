
using HRManagement.DataAccess.Models.Models;
using HRManagement.DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;
using HRManagement.ViewModels.Employee;
using HRManagement.ViewModels.Extensions;

namespace HRManagement.Application
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        private IPositionRepository _positionRepository;
        private IProjectRepository _projectRepository;
        private ITrainingRepository _trainingRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IPositionRepository positionRepository, IProjectRepository projectRepository, ITrainingRepository trainingRepository)
        {
            _employeeRepository = employeeRepository;
            _positionRepository = positionRepository;
            _projectRepository = projectRepository;
            _trainingRepository = trainingRepository;


        }
        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees().ToList();
        }

        public GetContactInformationForEmployeeViewModel GetContactInformationForEmployee(int? id)
        {
            var employee = _employeeRepository.GetById(id);
            var model = new GetContactInformationForEmployeeViewModel
            {
                Id = employee.ContactInformation.Id,
                EmployeeId = employee.Id,
                Address = employee.ContactInformation.Address,
                City = employee.ContactInformation.City,
                PostalCode = employee.ContactInformation.PostalCode,
                PrivateEmail = employee.ContactInformation.PrivateEmail,
                PrivatePhone = employee.ContactInformation.PrivatePhone,
                State = employee.ContactInformation.State,
                WorkEmail = employee.ContactInformation.WorkEmail,
                WorkPhone = employee.ContactInformation.WorkPhone
            };

            return model;
        }

        public GetFinancialInformationForEmployeeViewModel GetFinancialInformationForEmployee(int? id)
        {
            var employee = _employeeRepository.GetById(id);
            var model = new GetFinancialInformationForEmployeeViewModel
            {
                Id = employee.FinancialInformation.Id,
                EmployeeId = employee.Id,
                Salary = employee.FinancialInformation.Salary,
                NextSalaryIncrease = employee.FinancialInformation.NextSalaryIncrease,
                AccountNumber = employee.FinancialInformation.AccountNumber,
                Bank = employee.FinancialInformation.Bank
            };

            return model;
        }

        public GetEmploymentInformationForEmployeeViewModel GetEmploymentInformationForEmployee(int? id)
        {
            var employee = _employeeRepository.GetById(id);
            var model = new GetEmploymentInformationForEmployeeViewModel
            {
                Id = employee.EmploymentInformation.Id,
                EmployeeId = employee.Id,
                EmploymentDate = employee.EmploymentInformation.EmploymentDate,
                JubileeDate = employee.EmploymentInformation.JubileeDate,
                DateForFormalProfessionalCompetence = employee.EmploymentInformation.DateForFormalProfessionalCompetence,
                DateForFormalTeachingSkills = employee.EmploymentInformation.DateForFormalTeachingSkills
                
            };

            return model;
        }
        public GetTrainingForEmployeeViewModel GetTrainingForEmployee(int? id)
        {
            var employeeTrainings = _employeeRepository.GetById(id).Trainings;
            var model = new GetTrainingForEmployeeViewModel();

            model.EmployeeId = id.Value;
            model.Trainings = employeeTrainings.Select(x => new GetTrainingListForEmployeeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Status = x.Status,
                StatusDescription = x.Status.GetDescription()
            }).ToList();

            return model;
        }

        public EditEmploymentInfomationForEmployeeViewModel GetEmploymentInformationForEdit(int? id)
        {
            var employee = _employeeRepository.GetById(id);

            var model = new EditEmploymentInfomationForEmployeeViewModel
            {
                Id = employee.EmploymentInformation.Id,
                EmployeeId = employee.Id,
                EmploymentDate = employee.EmploymentInformation.EmploymentDate,
                JubileeDate = employee.EmploymentInformation.JubileeDate,
                DateForFormalProfessionalCompetence = employee.EmploymentInformation.DateForFormalProfessionalCompetence,
                DateForFormalTeachingSkills = employee.EmploymentInformation.DateForFormalTeachingSkills
            };

            return model;
        }

        public EditFinancialInformationForEmployeeViewModel GetFinancialInformationForEdit(int? id)
        {
            var employee = _employeeRepository.GetById(id);

            var model = new EditFinancialInformationForEmployeeViewModel
            {
                Id = employee.FinancialInformation.Id,
                EmployeeId = employee.Id,
                Salary = employee.FinancialInformation.Salary,
                NextSalaryIncrease = employee.FinancialInformation.NextSalaryIncrease,
                AccountNumber = employee.FinancialInformation.AccountNumber,
                Bank = employee.FinancialInformation.Bank

                 
            };

            return model;
        }

        public EditContactInformationForEmployeeViewModel GetContactInformationForEdit(int? id)
        {
            var employee = _employeeRepository.GetById(id);

            var model = new EditContactInformationForEmployeeViewModel
            {
                Id = employee.ContactInformation.Id,
                EmployeeId = employee.Id,
                Address = employee.ContactInformation.Address,
                City = employee.ContactInformation.City,
                PostalCode = employee.ContactInformation.PostalCode,
                PrivateEmail = employee.ContactInformation.PrivateEmail,
                PrivatePhone = employee.ContactInformation.PrivatePhone,
                State = employee.ContactInformation.State,
                WorkEmail = employee.ContactInformation.WorkEmail,
                WorkPhone = employee.ContactInformation.WorkPhone
            };

            return model;
        }

        public EditEmployeeViewModel GetEmployeeForEdit(int? id)
        {
            var employee = _employeeRepository.GetById(id);
            var positions = _positionRepository.GetAll();
            var projects = _projectRepository.GetAllProjects();

            var model = new EditEmployeeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                Positions = positions.ToList(),
                Projects = projects.ToList(),
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                Nationality = employee.Nationality,
                NationalIdentificationNumber = employee.NationalIdentificationNumber
            };

            if (employee.Position != null)
            {
                model.PositionId = employee.Position.Id;
            }
            if (employee.Project != null)
            {
                model.ProjectId = employee.Project.Id;
            }
            if (employee.DateOfBirth != null)
            {
                model.DateOfBirth = employee.DateOfBirth;
            }
            return model;

        }

        public void SetChangesForEmployee(int employeeId, int positionId, int projectId, string lastName, string middleName, string firstName, DateTime dateOfBirth, Gender gender, string nationality, string nID)
        {
            _employeeRepository.SetChangesForEmployee(employeeId, positionId, projectId, lastName, middleName, firstName, dateOfBirth, gender, nationality, nID);
        }

        public void EditContactInformation(int financialInformationId, string address, string city, string postalCode, string state, string workPhone, string privatePhone, string workEmail, string privateEmail)
        {
            _employeeRepository.EditContactInformation(financialInformationId, address, city, postalCode, state, workPhone, privatePhone, workEmail, privateEmail);
        }

        public void EditEmploymentInformation(int employmentInformationId, DateTime employmentDate, DateTime jubileeDate, DateTime dateProfessionalCompetence, DateTime dateTeachingSkills)
        {
            _employeeRepository.EditEmploymentInformation(employmentInformationId, employmentDate, jubileeDate, dateProfessionalCompetence, dateTeachingSkills);
        }

        public void EditFinancialInformation(int financialInformationId, Decimal salary, DateTime nextSalaryDiscussion, string accountNumber, string bank)
        {
            _employeeRepository.EditFinancialInformation(financialInformationId, salary, nextSalaryDiscussion, accountNumber, bank);
        }

        public CreateEmployeeViewModel GetEmployeeForCreate()
        {
            var positions = _positionRepository.GetAll();
            var projects = _projectRepository.GetAllProjects();

            var model = new CreateEmployeeViewModel
            {
                Positions = positions.ToList(),
                Projects = projects.ToList()
            };

            return model;
        }
        public int CreateEmployee(CreateEmployeeViewModel input)
        {
            var employee = _employeeRepository.CreateEmployee(input.PositionId, input.ProjectId, input.LastName, input.MiddleName, input.FirstName, input.DateOfBirth, input.Gender, input.Nationality, input.Languages, input.NationalIdentificationNumber);
            _employeeRepository.AddContactInformation(employee.Id, input.Address, input.City, input.PostalCode, input.State, input.WorkPhone, input.PrivatePhone, input.WorkEmail, input.PrivateEmail);
            _employeeRepository.AddEmploymentInformation(employee.Id, input.EmploymentDate, input.JubileeDate, input.DateForFormalProfessionalCompetence, input.DateForFormalTeachingSkills);
            _employeeRepository.AddFinancialInformation(employee.Id, input.Salary, input.NextSalaryIncrease, input.AccountNumber, input.Bank);
            return employee.Id;
        }

        public void AttachImage(int employeeId, string imageUrl)
        {
            _employeeRepository.AttachImage(employeeId, imageUrl);
        }

         List<GetTrainingListForEmployeeToAssignViewModel> IEmployeeService.GetTrainingsToAssign(int? id)
        {
            var trainingsToAssign = _trainingRepository.GetAllTrainings();

            return trainingsToAssign.Select(x => new GetTrainingListForEmployeeToAssignViewModel
            {
                Id = x.Id,
                Name = x.Name,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Status = x.Status,
                StatusDescription = x.Status.GetDescription()
            }).ToList();
        }

        
    }
}
