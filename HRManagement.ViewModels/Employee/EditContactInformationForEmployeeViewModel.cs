using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModels.Employee
{
   public class EditContactInformationForEmployeeViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }
        public string State { get; set; }
        [Display(Name = "Work phone")]
        public string WorkPhone { get; set; }
        [Display(Name = "Private phone")]
        public string PrivatePhone { get; set; }
        [Display(Name = "Work e-mail")]
        public string WorkEmail { get; set; }
        [Display(Name = "Private e-mail")]
        public string PrivateEmail { get; set; }
        public int EmployeeId { get; set; }
    }
}
