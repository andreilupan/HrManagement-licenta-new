using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.DataAccess.Models.Models
{
  public class FinancialInformation : BaseEntity
    {
        public Decimal Salary { get; set; }
        public DateTime NextSalaryIncrease { get; set; }
        public string AccountNumber { get; set; }
        public string Bank { get; set; }
    }
}
