using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Enterprise_Program_Benefits.Startup))]
namespace Enterprise_Program_Benefits
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
