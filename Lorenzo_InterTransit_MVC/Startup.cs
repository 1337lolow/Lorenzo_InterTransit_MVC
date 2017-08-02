
using Lorenzo_InterTransit_MVC.DAL;
using Lorenzo_InterTransit_MVC.Models;
using Microsoft.Owin;
using Owin;
using System.Configuration;
using System.Data.Entity;
[assembly: OwinStartupAttribute(typeof(Lorenzo_InterTransit_MVC.Migrations.Startup))]
namespace Lorenzo_InterTransit_MVC.Migrations
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Configuration laConfYalta = new Configuration();

            Database.SetInitializer(new dbInitializer());

            using (var context = new InterTransit())
            {

                context.Database.Initialize(false);

            }

        }

    }
}
