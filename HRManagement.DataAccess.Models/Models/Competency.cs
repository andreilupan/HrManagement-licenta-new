using System.Collections.Generic;

namespace HRManagement.DataAccess.Models.Models
{
  public class Competency : BaseEntity
    {
        public string Name { get; set; }
        public int ExperiencePeriod { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
