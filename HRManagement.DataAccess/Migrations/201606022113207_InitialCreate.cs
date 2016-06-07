namespace HRManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LogoUrl = c.String(),
                        AchievementDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        Nationality = c.String(nullable: false),
                        Languages = c.Int(nullable: false),
                        NationalIdentificationNumber = c.String(),
                        ImageUrl = c.String(),
                        Company_Id = c.Int(),
                        ContactInformation_Id = c.Int(),
                        EmploymentInformation_Id = c.Int(),
                        FinancialInformation_Id = c.Int(),
                        Position_Id = c.Int(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.Company_Id)
                .ForeignKey("dbo.ContactInformation", t => t.ContactInformation_Id)
                .ForeignKey("dbo.EmploymentInformation", t => t.EmploymentInformation_Id)
                .ForeignKey("dbo.FinancialInformation", t => t.FinancialInformation_Id)
                .ForeignKey("dbo.Position", t => t.Position_Id)
                .ForeignKey("dbo.Project", t => t.Project_Id)
                .Index(t => t.Company_Id)
                .Index(t => t.ContactInformation_Id)
                .Index(t => t.EmploymentInformation_Id)
                .Index(t => t.FinancialInformation_Id)
                .Index(t => t.Position_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LogoUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Competency",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ExperiencePeriod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactInformation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        State = c.String(),
                        WorkPhone = c.String(),
                        PrivatePhone = c.String(),
                        WorkEmail = c.String(),
                        PrivateEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmploymentInformation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmploymentDate = c.DateTime(nullable: false),
                        JubileeDate = c.DateTime(nullable: false),
                        DateForFormalProfessionalCompetence = c.DateTime(nullable: false),
                        DateForFormalTeachingSkills = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FinancialInformation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NextSalaryIncrease = c.DateTime(nullable: false),
                        AccountNumber = c.String(),
                        Bank = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Technology = c.String(),
                        LevelOfExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Training",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Note",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Username = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeCertification",
                c => new
                    {
                        Employee_Id = c.Int(nullable: false),
                        Certification_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_Id, t.Certification_Id })
                .ForeignKey("dbo.Employee", t => t.Employee_Id, cascadeDelete: true)
                .ForeignKey("dbo.Certification", t => t.Certification_Id, cascadeDelete: true)
                .Index(t => t.Employee_Id)
                .Index(t => t.Certification_Id);
            
            CreateTable(
                "dbo.CompetencyEmployee",
                c => new
                    {
                        Competency_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Competency_Id, t.Employee_Id })
                .ForeignKey("dbo.Competency", t => t.Competency_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Competency_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.TrainingEmployee",
                c => new
                    {
                        Training_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Training_Id, t.Employee_Id })
                .ForeignKey("dbo.Training", t => t.Training_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Training_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainingEmployee", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.TrainingEmployee", "Training_Id", "dbo.Training");
            DropForeignKey("dbo.Employee", "Project_Id", "dbo.Project");
            DropForeignKey("dbo.Employee", "Position_Id", "dbo.Position");
            DropForeignKey("dbo.Employee", "FinancialInformation_Id", "dbo.FinancialInformation");
            DropForeignKey("dbo.Employee", "EmploymentInformation_Id", "dbo.EmploymentInformation");
            DropForeignKey("dbo.Employee", "ContactInformation_Id", "dbo.ContactInformation");
            DropForeignKey("dbo.CompetencyEmployee", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.CompetencyEmployee", "Competency_Id", "dbo.Competency");
            DropForeignKey("dbo.Employee", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.EmployeeCertification", "Certification_Id", "dbo.Certification");
            DropForeignKey("dbo.EmployeeCertification", "Employee_Id", "dbo.Employee");
            DropIndex("dbo.TrainingEmployee", new[] { "Employee_Id" });
            DropIndex("dbo.TrainingEmployee", new[] { "Training_Id" });
            DropIndex("dbo.CompetencyEmployee", new[] { "Employee_Id" });
            DropIndex("dbo.CompetencyEmployee", new[] { "Competency_Id" });
            DropIndex("dbo.EmployeeCertification", new[] { "Certification_Id" });
            DropIndex("dbo.EmployeeCertification", new[] { "Employee_Id" });
            DropIndex("dbo.Employee", new[] { "Project_Id" });
            DropIndex("dbo.Employee", new[] { "Position_Id" });
            DropIndex("dbo.Employee", new[] { "FinancialInformation_Id" });
            DropIndex("dbo.Employee", new[] { "EmploymentInformation_Id" });
            DropIndex("dbo.Employee", new[] { "ContactInformation_Id" });
            DropIndex("dbo.Employee", new[] { "Company_Id" });
            DropTable("dbo.TrainingEmployee");
            DropTable("dbo.CompetencyEmployee");
            DropTable("dbo.EmployeeCertification");
            DropTable("dbo.Note");
            DropTable("dbo.Training");
            DropTable("dbo.Project");
            DropTable("dbo.Position");
            DropTable("dbo.FinancialInformation");
            DropTable("dbo.EmploymentInformation");
            DropTable("dbo.ContactInformation");
            DropTable("dbo.Competency");
            DropTable("dbo.Company");
            DropTable("dbo.Employee");
            DropTable("dbo.Certification");
        }
    }
}
