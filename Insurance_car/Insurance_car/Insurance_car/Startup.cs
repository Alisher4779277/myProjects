using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Insurance_car.Startup))]
namespace Insurance_car
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
