using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YellowpagesCustomer.Startup))]
namespace YellowpagesCustomer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
