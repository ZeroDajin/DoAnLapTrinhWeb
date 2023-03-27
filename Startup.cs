using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoAnWebTruyenTranh.Startup))]
namespace DoAnWebTruyenTranh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
