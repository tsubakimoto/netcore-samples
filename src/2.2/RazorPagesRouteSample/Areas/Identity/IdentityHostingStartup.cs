using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesRouteSample.Areas.Identity.Data;

[assembly: HostingStartup(typeof(RazorPagesRouteSample.Areas.Identity.IdentityHostingStartup))]
namespace RazorPagesRouteSample.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RazorPagesRouteSampleIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RazorPagesRouteSampleIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<RazorPagesRouteSampleIdentityDbContext>();
            });
        }
    }
}