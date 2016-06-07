using System;
using System.Collections.Generic;

namespace HRManagement.DataAccess.Models.Models
{
   public class Certification : BaseEntity
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public DateTime AchievementDate { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
