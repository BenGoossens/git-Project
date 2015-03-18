using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_Krekelhof.Startup))]
namespace Project_Krekelhof
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}