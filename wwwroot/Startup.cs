using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(wwwroot.Startup))]
namespace wwwroot
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();

            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
            TextBuffer tb = new TextBuffer();
            RecurringJob.AddOrUpdate(
                () => tb.executeExcel(), Cron.MinuteInterval(5));
        }
    }
}