using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(uiShopBridge.Startup))]
namespace uiShopBridge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
