using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModels.Employee
{
   public class GetFinancialInformationForEmployeeViewModel
    {
        public int Id { get; set; }
        public Decimal Salary { get; set; }
        [Display(Name = "Next salary discussion")]
        public DateTime NextSalaryIncrease { get; set; }
        [Display(Name = "Account number")]
        public string AccountNumber { get; set; }
        [Display(Name = "Bank")]
        public string Bank { get; set; }
        public int EmployeeId { get; set; }
    }
}
