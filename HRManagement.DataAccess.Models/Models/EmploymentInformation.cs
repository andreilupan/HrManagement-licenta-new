using System;

namespace HRManagement.DataAccess.Models.Models
{
    public class EmploymentInformation : BaseEntity
    {
        public DateTime EmploymentDate { get; set; }
        public DateTime JubileeDate { get; set; }
        public DateTime DateForFormalProfessionalCompetence { get; set; }
        public DateTime DateForFormalTeachingSkills { get; set; }

    }
}
