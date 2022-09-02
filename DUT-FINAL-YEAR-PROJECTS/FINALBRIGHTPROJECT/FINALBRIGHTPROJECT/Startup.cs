using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FINALBRIGHTPROJECT.Startup))]
namespace FINALBRIGHTPROJECT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
