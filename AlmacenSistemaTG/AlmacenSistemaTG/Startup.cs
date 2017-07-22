using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlmacenSistemaTG.Startup))]
namespace AlmacenSistemaTG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
