using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GroceryApp.Startup))]
namespace GroceryApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
