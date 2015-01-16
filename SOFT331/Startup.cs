using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SOFT331.Startup))]
namespace SOFT331
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
