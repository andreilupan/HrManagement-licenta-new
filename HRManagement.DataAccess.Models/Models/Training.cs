using System;
using System.Collections.Generic;

namespace HRManagement.DataAccess.Models.Models
{
    public class Training : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TrainingStatus Status { get; set; }
        public virtual List<Employee> Employees { get; set; }



    }
}
