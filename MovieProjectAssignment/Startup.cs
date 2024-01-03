using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieProjectAssignment.Startup))]
namespace MovieProjectAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
