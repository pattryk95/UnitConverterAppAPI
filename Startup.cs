using UnitConverterAppAPI.Entities;
using AutoMapper;
using UnitConverterAppAPI.Services;
using UnitConverterAppAPI.Middleware;

namespace UnitConverterAppAPI
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
            services.AddControllers();
            services.AddDbContext<UnitConverterDbContext>();
            services.AddScoped<UnitSeeder>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<ErrorHandlingMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UnitSeeder seeder)
        {

            seeder.Seed();
           /* if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           */
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
