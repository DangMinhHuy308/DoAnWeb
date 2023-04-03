using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_4TL.Startup))]
namespace _4TL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
