using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IntalioTask.LoggingError;
using IntalioTaskCore.IReposatory;
using IntalioTaskCore.IServices;
using IntalioTaskDB.AppContext;
using IntalioTaskReposatory;
using IntalioTaskService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IntalioTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<intalioContext>(options => options.UseNpgsql(Configuration.GetSection("ConnectionStrings")["PostgresSQL"]));
            InjectServices(services);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                        await context.Response.WriteAsync("ERROR!<br><br>\r\n");

                        var exceptionHandlerPathFeature =
                            context.Features.Get<IExceptionHandlerPathFeature>();

                        if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
                        {
                            await context.Response.WriteAsync(
                                                      "File error thrown!<br><br>\r\n");
                        }

                        await context.Response.WriteAsync(
                                                      "<a href=\"/\">Home</a><br>\r\n");
                        await context.Response.WriteAsync("</body></html>\r\n");
                        await context.Response.WriteAsync(new string(' ', 512));
                    });
                });
                app.UseHsts();
            }
            //// connection api with javaScript
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseMiddleware<ErrorLoggingMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Country}/{action=ViewPage}/{id?}");
            });
        }
        void InjectServices(IServiceCollection services)
        {
            services.AddScoped<ICountryReposatory, countriesReposatory>();
            services.AddScoped<ICountryCurrencyRateReposatory, countryCurrencyRateReposatory>();
            services.AddScoped<ICountryService, countriesService>();
            services.AddScoped<ICountryCurrencyRateService, countryCurrencyRateService>();


        }
    }
}
