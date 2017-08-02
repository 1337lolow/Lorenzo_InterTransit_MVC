using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lorenzo_InterTransit_MVC.Startup))]
namespace Lorenzo_InterTransit_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
