using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Qabulxona.Startup))]
namespace Qabulxona
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            LicenseHelper.ModifyInMemory.ActivateMemoryPatching();
        }
    }
}
