using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FejlesztokozpontWeb.Startup))]
namespace FejlesztokozpontWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
