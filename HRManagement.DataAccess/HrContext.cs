using HRManagement.DataAccess.Models.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HRManagement.DataAccess
{
    public class HrContext : DbContext
    {
        public HrContext() : base("HrContext")
            {

            }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Competency> Competencies { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }
        public DbSet<EmploymentInformation> EmploymentInformation { get; set; }
        public DbSet<FinancialInformation> FinancialInformation { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Note> Notes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
