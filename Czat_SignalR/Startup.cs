using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Czat_SignalR.Startup))]
namespace Czat_SignalR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
