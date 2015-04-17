using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularJsTest.Startup))]
namespace AngularJsTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
