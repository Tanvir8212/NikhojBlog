using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NikhojBlog04.Startup))]
namespace NikhojBlog04
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
