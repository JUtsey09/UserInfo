using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserInfo.Startup))]
namespace UserInfo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
