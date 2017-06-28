using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectExam.Startup))]
namespace ProjectExam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
