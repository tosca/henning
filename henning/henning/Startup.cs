using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(henning.Startup))]
namespace henning
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
