using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace HolidayPizza
{
    public class Startup
    {

        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //adding DBContext
           services.AddDbContext<AppDbContext>(options =>
{
#pragma warning disable CS8604 // Possible null reference argument.
    options.UseMySQL(this.configuration.GetConnectionString("DefaultConnection"));
#pragma warning restore CS8604 // Possible null reference argument.
});

  CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;


            //adding controllers
            services.AddControllersWithViews(); // Add MVC

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage(); // Developer exception page

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute(); // Map default controller route
            });
        }
    }
}
