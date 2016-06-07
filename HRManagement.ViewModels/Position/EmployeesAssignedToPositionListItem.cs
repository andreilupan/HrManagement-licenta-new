namespace HRManagement.ViewModels.Position
{
    public class EmployeesAssignedToPositionListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Technology { get; set; }
        public DataAccess.Models.Models.LevelOfExperience LevelOfExperience { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeMiddleName { get; set; }
        public string EmployeeLastName { get; set; }
    }
}
