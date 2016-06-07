using ExporterObjects;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data;

using Excel = Microsoft.Office.Interop.Excel;
using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;
using HRManagement.Controllers;
using HRManagement;

namespace HRManagement
{
    public class ExcelExporter : IExcelExporter
    {
        private string uploadDir = @"/EmployeeData/Reports";
        private string uploadDirTraining = @"/TrainingData/Reports";
        private string uploadDirPosition = @"/PositionData/Reports";
        private string uploadDirProject = @"/ProjectData/Reports";

        public string ExportEmployees(IEnumerable<EmployeeExportViewModel> data, string filename)
        {
            var path = Path.Combine(HttpContext.Current.Server.MapPath(uploadDir)) + "\\" + filename + ".xlsx";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            Excel.Application xlAppToExport = new Excel.Application();
            xlAppToExport.Workbooks.Add("");

            // ADD A WORKSHEET.
            Excel.Worksheet xlWorkSheetToExport = default(Excel.Worksheet);
            xlWorkSheetToExport = (Excel.Worksheet)xlAppToExport.Sheets["Sheet1"];

            // ROW ID FROM WHERE THE DATA STARTS SHOWING.
            int iRowCnt = 8;

            // SHOW THE HEADER.
            xlWorkSheetToExport.Cells[1, 1] = "Employee Details";

            Excel.Range range = xlWorkSheetToExport.Cells[1, 1] as Excel.Range;
            range.EntireRow.Font.Name = "Calibri";
            range.EntireRow.Font.Bold = true;
            range.EntireRow.Font.Size = 20;

            xlWorkSheetToExport.Range["A1:D1"].MergeCells = true;       // MERGE CELLS OF THE HEADER.

            // SHOW COLUMNS ON THE TOP.
            xlWorkSheetToExport.Cells[iRowCnt - 1, 1] = "Name";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 2] = "Date of birth";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 3] = "Gender";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 4] = "Nationality";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 5] = "Positions";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 6] = "Projects";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 7] = "Trainings";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 8] = "Address";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 9] = "City";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 10] = "Postal code";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 11] = "State";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 12] = "Work phone";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 13] = "Private phone";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 14] = "Work e-mail";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 15] = "Private e-mail";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 16] = "Employment date";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 17] = "Jubilee date";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 18] = "Date for formal professional competence";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 19] = "Date for formal teaching skills";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 20] = "Salary";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 21] = "Next salary discussion";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 22] = "Account";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 23] = "Bank";


            int i;
            for (i = 0; i <= data.Count() - 1; i++)
            {
                xlWorkSheetToExport.Cells[iRowCnt, 1] = data.ElementAt(i).Name;
                xlWorkSheetToExport.Cells[iRowCnt, 2] = data.ElementAt(i).DateOfBirth;
                xlWorkSheetToExport.Cells[iRowCnt, 3] = data.ElementAt(i).Gender;
                xlWorkSheetToExport.Cells[iRowCnt, 4] = data.ElementAt(i).Nationality;
                xlWorkSheetToExport.Cells[iRowCnt, 5] = data.ElementAt(i).Positions;
                xlWorkSheetToExport.Cells[iRowCnt, 6] = data.ElementAt(i).Projects;
                xlWorkSheetToExport.Cells[iRowCnt, 7] = data.ElementAt(i).Trainings;
                xlWorkSheetToExport.Cells[iRowCnt, 8] = data.ElementAt(i).Address;
                xlWorkSheetToExport.Cells[iRowCnt, 9] = data.ElementAt(i).City;
                xlWorkSheetToExport.Cells[iRowCnt, 10] = data.ElementAt(i).PostalCode;
                xlWorkSheetToExport.Cells[iRowCnt, 11] = data.ElementAt(i).State;
                xlWorkSheetToExport.Cells[iRowCnt, 12] = data.ElementAt(i).WorkPhone;
                xlWorkSheetToExport.Cells[iRowCnt, 13] = data.ElementAt(i).PrivatePhone;
                xlWorkSheetToExport.Cells[iRowCnt, 14] = data.ElementAt(i).WorkEmail;
                xlWorkSheetToExport.Cells[iRowCnt, 15] = data.ElementAt(i).PrivateEmail;
                xlWorkSheetToExport.Cells[iRowCnt, 16] = data.ElementAt(i).EmploymentDate;
                xlWorkSheetToExport.Cells[iRowCnt, 17] = data.ElementAt(i).JubileeDate;
                xlWorkSheetToExport.Cells[iRowCnt, 18] = data.ElementAt(i).DateForFormalProfessionalCompetence;
                xlWorkSheetToExport.Cells[iRowCnt, 19] = data.ElementAt(i).DateForFormalTeachingSkills;
                xlWorkSheetToExport.Cells[iRowCnt, 20] = data.ElementAt(i).Salary;
                xlWorkSheetToExport.Cells[iRowCnt, 21] = data.ElementAt(i).NextSalaryIncrease;
                xlWorkSheetToExport.Cells[iRowCnt, 22] = data.ElementAt(i).AccountNumber;
                xlWorkSheetToExport.Cells[iRowCnt, 23] = data.ElementAt(i).Bank;
          


                iRowCnt = iRowCnt + 1;
            }

            // SAVE THE FILE IN A FOLDER.
            xlWorkSheetToExport.SaveAs(path);

            // CLEAR.
            xlAppToExport.Workbooks.Close();
            xlAppToExport.Quit();
            xlAppToExport = null;
            return path;
        }
        public string ExportTrainings(IEnumerable<TrainingController.TrainingExportViewModel> data, string filename)
        {
            var path = Path.Combine(HttpContext.Current.Server.MapPath(uploadDirTraining)) + "\\" + filename + ".xlsx";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            Excel.Application xlAppToExport = new Excel.Application();
            xlAppToExport.Workbooks.Add("");

            // ADD A WORKSHEET.
            Excel.Worksheet xlWorkSheetToExport = default(Excel.Worksheet);
            xlWorkSheetToExport = (Excel.Worksheet)xlAppToExport.Sheets["Sheet1"];

            // ROW ID FROM WHERE THE DATA STARTS SHOWING.
            int iRowCnt = 8;

            // SHOW THE HEADER.
            xlWorkSheetToExport.Cells[1, 1] = "Training Details";

            Excel.Range range = xlWorkSheetToExport.Cells[1, 1] as Excel.Range;
            range.EntireRow.Font.Name = "Calibri";
            range.EntireRow.Font.Bold = true;
            range.EntireRow.Font.Size = 20;

            xlWorkSheetToExport.Range["A1:D1"].MergeCells = true;       // MERGE CELLS OF THE HEADER.

            // SHOW COLUMNS ON THE TOP.
            xlWorkSheetToExport.Cells[iRowCnt - 1, 1] = "Name";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 2] = "Start date";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 3] = "End date";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 4] = "Status";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 5] = "Employees assigned";
        


            int i;
            for (i = 0; i <= data.Count() - 1; i++)
            {
                xlWorkSheetToExport.Cells[iRowCnt, 1] = data.ElementAt(i).Name;
                xlWorkSheetToExport.Cells[iRowCnt, 2] = data.ElementAt(i).StartDate;
                xlWorkSheetToExport.Cells[iRowCnt, 3] = data.ElementAt(i).EndDate;
                xlWorkSheetToExport.Cells[iRowCnt, 4] = data.ElementAt(i).Status;
                xlWorkSheetToExport.Cells[iRowCnt, 5] = data.ElementAt(i).Employees;


                iRowCnt = iRowCnt + 1;
            }

            // SAVE THE FILE IN A FOLDER.
            xlWorkSheetToExport.SaveAs(path);

            // CLEAR.
            xlAppToExport.Workbooks.Close();
            xlAppToExport.Quit();
            xlAppToExport = null;
            return path;
        }

        public string ExportPositions(IEnumerable<PositionsController.PositionExportViewModel> data, string filename)
        {
            var path = Path.Combine(HttpContext.Current.Server.MapPath(uploadDirPosition)) + "\\" + filename + ".xlsx";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            Excel.Application xlAppToExport = new Excel.Application();
            xlAppToExport.Workbooks.Add("");

            // ADD A WORKSHEET.
            Excel.Worksheet xlWorkSheetToExport = default(Excel.Worksheet);
            xlWorkSheetToExport = (Excel.Worksheet)xlAppToExport.Sheets["Sheet1"];

            // ROW ID FROM WHERE THE DATA STARTS SHOWING.
            int iRowCnt = 8;

            // SHOW THE HEADER.
            xlWorkSheetToExport.Cells[1, 1] = "Position Details";

            Excel.Range range = xlWorkSheetToExport.Cells[1, 1] as Excel.Range;
            range.EntireRow.Font.Name = "Calibri";
            range.EntireRow.Font.Bold = true;
            range.EntireRow.Font.Size = 20;

            xlWorkSheetToExport.Range["A1:D1"].MergeCells = true;       // MERGE CELLS OF THE HEADER.

            // SHOW COLUMNS ON THE TOP.
            xlWorkSheetToExport.Cells[iRowCnt - 1, 1] = "Name";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 2] = "Description";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 3] = "Level of experience";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 4] = "Technology";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 5] = "Employees assigned";



            int i;
            for (i = 0; i <= data.Count() - 1; i++)
            {
                xlWorkSheetToExport.Cells[iRowCnt, 1] = data.ElementAt(i).Name;
                xlWorkSheetToExport.Cells[iRowCnt, 2] = data.ElementAt(i).Description;
                xlWorkSheetToExport.Cells[iRowCnt, 3] = data.ElementAt(i).LevelOfExperience;
                xlWorkSheetToExport.Cells[iRowCnt, 4] = data.ElementAt(i).Technology;
                xlWorkSheetToExport.Cells[iRowCnt, 5] = data.ElementAt(i).Employees;


                iRowCnt = iRowCnt + 1;
            }

            // SAVE THE FILE IN A FOLDER.
            xlWorkSheetToExport.SaveAs(path);

            // CLEAR.
            xlAppToExport.Workbooks.Close();
            xlAppToExport.Quit();
            xlAppToExport = null;
            return path;
        }

        public string ExportProjects(IEnumerable<ProjectController.ProjectExportViewModel> data, string filename)
        {
            var path = Path.Combine(HttpContext.Current.Server.MapPath(uploadDirProject)) + "\\" + filename + ".xlsx";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            Excel.Application xlAppToExport = new Excel.Application();
            xlAppToExport.Workbooks.Add("");

            // ADD A WORKSHEET.
            Excel.Worksheet xlWorkSheetToExport = default(Excel.Worksheet);
            xlWorkSheetToExport = (Excel.Worksheet)xlAppToExport.Sheets["Sheet1"];

            // ROW ID FROM WHERE THE DATA STARTS SHOWING.
            int iRowCnt = 8;

            // SHOW THE HEADER.
            xlWorkSheetToExport.Cells[1, 1] = "Project Details";

            Excel.Range range = xlWorkSheetToExport.Cells[1, 1] as Excel.Range;
            range.EntireRow.Font.Name = "Calibri";
            range.EntireRow.Font.Bold = true;
            range.EntireRow.Font.Size = 20;

            xlWorkSheetToExport.Range["A1:D1"].MergeCells = true;       // MERGE CELLS OF THE HEADER.

            // SHOW COLUMNS ON THE TOP.
            xlWorkSheetToExport.Cells[iRowCnt - 1, 1] = "Name";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 2] = "Description";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 5] = "Employees assigned";



            int i;
            for (i = 0; i <= data.Count() - 1; i++)
            {
                xlWorkSheetToExport.Cells[iRowCnt, 1] = data.ElementAt(i).Name;
                xlWorkSheetToExport.Cells[iRowCnt, 2] = data.ElementAt(i).Description;
                xlWorkSheetToExport.Cells[iRowCnt, 5] = data.ElementAt(i).Employees;


                iRowCnt = iRowCnt + 1;
            }

            // SAVE THE FILE IN A FOLDER.
            xlWorkSheetToExport.SaveAs(path);

            // CLEAR.
            xlAppToExport.Workbooks.Close();
            xlAppToExport.Quit();
            xlAppToExport = null;
            return path;
        }

    }
}

