using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(wed.Startup))]
namespace wed
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
