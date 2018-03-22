using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieGuideApi.Models;
using System;

namespace MovieGuideApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<MovieGuideContext>(options => options.UseSqlite("Data Source=LittleGods.db"));
            //services.AddDbContext<MovieGuideContext>(opt => opt.UseSqlServer("Server=movieguideapi.ch7je3w2pwwt.ca-central-1.rds.amazonaws.com,1433;User Id=sa;password=Duffmckagan1994;Database=movieguide;MultipleActiveResultSets=true"));
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                services.AddDbContext<MovieGuideContext>(options =>
                        options.UseSqlServer("Server=tcp:movieguide.database.windows.net,1433;Initial Catalog=movieguide;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            else
                services.AddDbContext<MovieGuideContext>(options =>
                        options.UseSqlite("Data Source=MovieGuide.db"));

            // Automatically perform database migration
            services.BuildServiceProvider().GetService<MovieGuideContext>().Database.Migrate();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
