using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webtest.Startup))]
namespace webtest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
