using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cloud__.Startup))]
namespace Cloud__
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
