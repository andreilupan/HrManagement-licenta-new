using System.Collections.Generic;

namespace HRManagement.DataAccess.Models.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
