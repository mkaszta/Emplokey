using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Emplokey_WebAdmin.Startup))]
namespace Emplokey_WebAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
