using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedMCOCAW.Startup))]
namespace RedMCOCAW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
