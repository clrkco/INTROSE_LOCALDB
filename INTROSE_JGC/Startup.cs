using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(INTROSE_JGC.Startup))]
namespace INTROSE_JGC
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
