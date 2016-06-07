using HRManagement.DataAccess.Models.Models;
using System;
using System.Linq;


namespace HRManagement.DataAccess.Repositories
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetAllEmployees();
        Employee GetById(int? id);
        void SetChangesForEmployee(int employeeId, int positionId, int projectId, string lastName, string middleName, string firstName, DateTime dateOfBirth, Gender gender, string nationality, string nID);
        Employee CreateEmployee (int positionId, int projectId, string lastName, string middleName, string firstName, DateTime dateOfBirth, Gender gender, string nationality, Language language, string nID);
        void EditEmploymentInformation(int employmentInformationId, DateTime employmentDate, DateTime jubileeDate, DateTime dateProfessionalCompetence, DateTime dateTeachingSkills);
        void EditFinancialInformation(int financialInformationId, Decimal salary, DateTime nextSalaryDiscussion, string accountNumber, string bank);
        void EditContactInformation(int contactInformationId, string address, string city, string postalCode, string state, string workPhone, string privatePhone, string workEmail, string privateEmail);
        ContactInformation AddContactInformation(int employeeId, string address, string city, string postalCode, string state, string workPhone, string privatePhone, string workEmail, string privateEmail);
        EmploymentInformation AddEmploymentInformation(int employeeId, DateTime employmentDate, DateTime jubileeDate, DateTime dateProfessionalCompetence, DateTime dateTeachingSkills);
        FinancialInformation AddFinancialInformation(int employeeId, Decimal salary, DateTime nextSalaryDiscussion, string accountNumber, string bank);
        void AttachImage(int employeeId, string imageUrl);
    }

}
