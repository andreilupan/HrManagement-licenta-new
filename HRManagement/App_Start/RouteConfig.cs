using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HRManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "GetEmployeesForPosition",
                url: "{controller}/{employeeId}/EmployeesAssignedToPosition",
                defaults: new { controller = "Positions", action = "EmployeesAssignedToPosition" }
                );

            routes.MapRoute(
                name: "EditEmployeeContactInformation",
                url: "{controller}/{employeeId}/editContactInformation",
                defaults: new { controller = "Employees", action = "EditContactInformation" }
                );

            routes.MapRoute(
                name: "EditEmployeeFinancialInformation",
                url: "{controller}/{employeeId}/editFinancialInformation",
                defaults: new { controller = "Employees", action = "EditFinancialInformation" }
                );


            routes.MapRoute(
               name: "EditEmployeeEmploymentInformation",
               url: "{controller}/{employeeId}/editEmploymentInformation",
               defaults: new { controller = "Employees", action = "EditEmploymentInformation" }
               );

            routes.MapRoute(
                name: "EmployeeTrainings",
                url: "{controller}/{employeeId}/trainings",
                defaults: new { controller = "Employees", action = "GetTrainingsForEmployee" }
                );

            routes.MapRoute(
               name: "EmployeeContactInformation",
               url: "{controller}/{employeeId}/contactInformation",
               defaults: new { controller = "Employees", action = "GetContactInformationForEmployee" }
               );

            routes.MapRoute(
              name: "EmployeeFinancialInformation",
              url: "{controller}/{employeeId}/financialInformation",
              defaults: new { controller = "Employees", action = "GetFinancialInformationForEmployee" }
              );

            routes.MapRoute(
               name: "EmployeeEmploymentInformation",
               url: "{controller}/{employeeId}/employmentInformation",
               defaults: new { controller = "Employees", action = "GetEmploymentInformationForEmployee" }
               );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
