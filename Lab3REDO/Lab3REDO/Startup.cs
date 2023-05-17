using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab3REDO.Startup))]
namespace Lab3REDO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
