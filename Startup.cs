using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FileUpload.Startup))]
namespace FileUpload
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
