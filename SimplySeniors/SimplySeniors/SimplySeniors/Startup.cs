using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimplySeniors.Startup))]
namespace SimplySeniors
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
