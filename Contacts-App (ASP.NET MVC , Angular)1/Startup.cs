using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Contacts_App__ASP.NET_MVC___Angular_.Startup))]
namespace Contacts_App__ASP.NET_MVC___Angular_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
