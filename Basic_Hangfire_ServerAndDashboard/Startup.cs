using Hangfire;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartup(typeof(Basic_Hangfire_ServerAndDashboard.Startup))]

namespace Basic_Hangfire_ServerAndDashboard
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB; Initial Catalog = HFDemo; Integrated Security = True; MultipleActiveResultSets = True;";

            GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString);

            app.UseHangfireDashboard();
            app.UseHangfireServer();


            //Hangfire Job :
            //1.Fire n Forget
            //var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Sample Job Fire-and-forget completed successfully!"));

            //2. Delayed jobs
            //var jobDelayId = BackgroundJob.Schedule(() => Console.WriteLine("Sample Job Delayed completed successfully!"), TimeSpan.FromMinutes(2));

            ////3. Recurring jobs - based on crond schedule
            //RecurringJob.AddOrUpdate(
            //    () => Console.WriteLine("{0} Recuring Job completed successfully!", DateTime.Now.ToString()),
            //    Cron.Minutely);


            ////4. Continuations
            //BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine("Sample Job Continuation after {0} jobs completed successfully!", jobId));
        }
    }
}
