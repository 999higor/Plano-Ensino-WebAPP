using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlanoEnsinoWEB.Startup))]
namespace PlanoEnsinoWEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
