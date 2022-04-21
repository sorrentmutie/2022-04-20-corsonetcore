using HelloCore.Interfaces;
using HelloCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HelloCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<ISaluto, HelloService>();
            //services.AddSingleton<IClock, OrologioAtomicoService>();

            services.AddTransient<ISaluto, HelloService>();
            services.AddTransient<IClock, OrologioAtomicoService>();

            //services.AddScoped<IClock, OrologioAtomicoService>();
            //services.AddScoped<ISaluto, HelloService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
            IConfiguration configuration, ISaluto saluto, ILogger<Startup> logger)
        {
            // var salutoClassico = new HelloService();
            // var salutoNotturno = new BuonanotteService();
            if (env.IsEnvironment("Development"))
            {
               app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            //app.UseWelcomePage();

            app.Use(async (context, next) =>
           {
               logger.LogInformation("Sono nel mio middleware");
               await next.Invoke();
           });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("Sono nel mio secondo middleware");
                if (context.Request.Path.StartsWithSegments("/esempio"))
                {
                    logger.LogInformation("Questo è un percorso proibito");
                    await context.Response.WriteAsync("Esci fuori!");
                } else
                {
                    logger.LogWarning("In uscita dal secondo middleware");
                    await next.Invoke();
                }
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    //throw new System.Exception("Aiuto");
                    var esempio = configuration["Esempio"];
                    var result = saluto.SalutoDelGiorno();
                    await context.Response.WriteAsync(result);
                });
            });
        }
    }
}
