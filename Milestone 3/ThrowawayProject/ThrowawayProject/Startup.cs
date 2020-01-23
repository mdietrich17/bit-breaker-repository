using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThrowawayProject.Startup))]
namespace ThrowawayProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
