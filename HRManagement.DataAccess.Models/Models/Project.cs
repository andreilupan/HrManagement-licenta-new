using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.DataAccess.Models.Models
{
   public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
