using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCprojesi.Startup))]
namespace MVCprojesi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
