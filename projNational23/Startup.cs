using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projNational23.Startup))]
namespace projNational23
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
