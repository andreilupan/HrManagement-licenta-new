using System.Collections.Generic;

namespace HRManagement.DataAccess.Models.Models
{
  public  class ContactInformation : BaseEntity
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string WorkPhone { get; set; }
        public string PrivatePhone { get; set; }
        public string WorkEmail { get; set; }
        public string PrivateEmail { get; set; }

    }
}
