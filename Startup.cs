using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieGuideApi.Models;

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
            services.AddDbContext<MovieGuideContext>(opt => opt.UseSqlServer("Server=movieguideapi.ch7je3w2pwwt.ca-central-1.rds.amazonaws.com,1433;User Id=sa;password=Duffmckagan1994;Database=movieguide;MultipleActiveResultSets=true"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
