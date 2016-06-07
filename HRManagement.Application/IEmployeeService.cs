using HRManagement.DataAccess.Models.Models;
using HRManagement.ViewModels.Employee;
using System;
using System.Collections.Generic;

namespace HRManagement.Application
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        EditEmployeeViewModel GetEmployeeForEdit(int? id);
        EditEmploymentInfomationForEmployeeViewModel GetEmploymentInformationForEdit(int? id);
        EditContactInformationForEmployeeViewModel GetContactInformationForEdit(int? id);
        EditFinancialInformationForEmployeeViewModel GetFinancialInformationForEdit(int? id);
        void EditFinancialInformation(int financialInformationId, Decimal salary, DateTime nextSalaryDiscussion, string accountNumber, string bank);
        void EditEmploymentInformation(int employmentInformationId, DateTime employmentDate, DateTime jubileeDate, DateTime dateProfessionalCompetence, DateTime dateTeachingSkills);
        void EditContactInformation(int finiancialInformationId, string address, string city, string postalCode, string state, string workPhone, string privatePhone, string workEmail, string privateEmail);
        void SetChangesForEmployee(int id, int positionId, int projectId, string lastName, string middleName, string firstName, DateTime dateOfBirth, Gender gender, string nationality, string nID);
        CreateEmployeeViewModel GetEmployeeForCreate();
        int CreateEmployee(CreateEmployeeViewModel input);
        GetTrainingForEmployeeViewModel GetTrainingForEmployee(int? id);
        GetContactInformationForEmployeeViewModel GetContactInformationForEmployee(int? id);
        GetEmploymentInformationForEmployeeViewModel GetEmploymentInformationForEmployee(int? id);
        GetFinancialInformationForEmployeeViewModel GetFinancialInformationForEmployee(int? id);
        void AttachImage(int employeeId, string imageUrl);
        List<GetTrainingListForEmployeeToAssignViewModel> GetTrainingsToAssign(int? id);
    }
}
