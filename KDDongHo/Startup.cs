using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KDDongHo.Startup))]
namespace KDDongHo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
