using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Boutique.Web.Startup))]
namespace Boutique.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
