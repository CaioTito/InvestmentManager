using Microsoft.Extensions.Options;
using Quartz;

namespace InvestmentManager.Infra.Email
{
    public class EmailBackgroundJobSetup : IConfigureOptions<QuartzOptions>
    {
        public void Configure(QuartzOptions options)
        {
            var emailJobKey = JobKey.Create(nameof(EmailBackgoundJob));

            options
                .AddJob<EmailBackgoundJob>(jobBuilder => jobBuilder.WithIdentity(emailJobKey))
                .AddTrigger(trigger =>
                    trigger
                        .ForJob(emailJobKey)
                        //.WithSimpleSchedule(schedule =>
                        //    schedule.WithIntervalInMinutes(5).RepeatForever()));
                        .WithCronSchedule("0 0 8 ? * * *"));
        }
    }
}
