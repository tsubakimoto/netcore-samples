using HealthCheckSample.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCheckSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<HealthCheckSampleContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("HealthCheckSampleContext")));

            // https://blogs.msdn.microsoft.com/webdev/2018/08/22/asp-net-core-2-2-0-preview1-healthcheck/
            //services.AddHealthChecks(); //default

            // BeatPlus-> https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks
            services.AddHealthChecks()
                .AddSqlServer(Configuration.GetConnectionString("HealthCheckSampleContext")) //AspNetCore.HealthChecks.SqlServer (default)
                //.AddSqlServer( //AspNetCore.HealthChecks.SqlServer (manual)
                //    connectionString: Configuration.GetConnectionString("HealthCheckSampleContext"),
                //    healthQuery: "SELECT 1;",
                //    name: "sql",
                //    failureStatus: Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Degraded,
                //    tags: new string[] { "db", "sql", "sqlserver" })
                .AddAzureBlobStorage(Configuration.GetConnectionString("AzureStorage")) //AspNetCore.HealthChecks.AzureStorage
                ;
            services.AddHealthChecksUI(); //AspNetCore.HealthChecks.UI
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // https://blogs.msdn.microsoft.com/webdev/2018/08/22/asp-net-core-2-2-0-preview1-healthcheck/
            //app.UseHealthChecks("/healthz"); //default
            //app.UseHealthChecks("/healthz", new HealthCheckOptions //customized message
            //{
            //    ResponseWriter = async (context, health) =>
            //    {
            //        await context.Response.WriteAsync("who are you?");
            //    }
            //});

            // UI-> https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks
            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true
            });
            app.UseHealthChecks("/healthz", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = HealthChecks.UI.Client.UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseHealthChecksUI(); //AspNetCore.HealthChecks.UI

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
