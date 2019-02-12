using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProektnaMVC.Startup))]
namespace ProektnaMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
