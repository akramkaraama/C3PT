using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WPGICSC.Startup))]
namespace WPGICSC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
