using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GoogleAuth.Data;

[assembly: HostingStartup(typeof(GoogleAuth.Areas.Identity.IdentityHostingStartup))]
namespace GoogleAuth.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<QuizzerContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("QuizzerContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<QuizzerContext>();
            });
        }
    }
}