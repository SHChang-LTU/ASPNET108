using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNET108.Startup))]
namespace ASPNET108
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
