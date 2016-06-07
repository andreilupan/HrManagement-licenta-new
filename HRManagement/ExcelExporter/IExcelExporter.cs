using HRManagement.Controllers;
using System.Collections.Generic;

namespace HRManagement
{
    public interface IExcelExporter
    {
        string ExportEmployees(IEnumerable<EmployeeExportViewModel> data, string filename);
        string ExportTrainings(IEnumerable<TrainingController.TrainingExportViewModel> data, string filename);
        string ExportPositions(IEnumerable<PositionsController.PositionExportViewModel> data, string filename);
        string ExportProjects(IEnumerable<ProjectController.ProjectExportViewModel> data, string filename);
    }
}
