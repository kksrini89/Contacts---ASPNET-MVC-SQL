using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContactsAppUI.Startup))]
namespace ContactsAppUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
