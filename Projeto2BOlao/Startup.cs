using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projeto2BOlao.Startup))]
namespace Projeto2BOlao
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
