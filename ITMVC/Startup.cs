using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITMVC.Startup))]
namespace ITMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
