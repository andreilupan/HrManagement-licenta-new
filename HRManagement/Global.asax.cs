using Autofac;
using Autofac.Integration.Mvc;
using HRManagement.Application;
using HRManagement.DataAccess;
using HRManagement.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HRManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            RegisterDependencies(builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<HrContext>().InstancePerRequest();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerRequest();
            builder.RegisterType<PositionService>().As<IPositionService>().InstancePerRequest();
            builder.RegisterType<ProjectService>().As<IProjectService>().InstancePerRequest();
            builder.RegisterType<TrainingService>().As<ITrainingService>().InstancePerRequest();
            builder.RegisterType<NotesService>().As<INotesService>().InstancePerRequest();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerRequest();
            builder.RegisterType<PositionRepository>().As<IPositionRepository>().InstancePerRequest();
            builder.RegisterType<ProjectRepository>().As<IProjectRepository>().InstancePerRequest();
            builder.RegisterType<TrainingRepository>().As<ITrainingRepository>().InstancePerRequest();
            builder.RegisterType<NotesRepository>().As<INotesRepository>().InstancePerRequest();
            //builder.RegisterType<ContactInformationRepository>().As<IContactInformationRepository>().InstancePerRequest();
            builder.RegisterType<ImageService>().InstancePerRequest();
            builder.RegisterType<ExcelExporter>().As<IExcelExporter>().InstancePerRequest();

        }
    }
}
