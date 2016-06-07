using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRManagement.Startup))]
namespace HRManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
