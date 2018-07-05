using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YellowPages.Startup))]
namespace YellowPages
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
