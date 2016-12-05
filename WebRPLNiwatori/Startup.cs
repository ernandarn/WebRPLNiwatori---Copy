using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebRPLNiwatori.Startup))]
namespace WebRPLNiwatori
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
