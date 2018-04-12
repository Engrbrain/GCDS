using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GCDS.Startup))]
namespace GCDS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
