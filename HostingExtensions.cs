using Microsoft.EntityFrameworkCore;
using Serilog;
using YghRentalManagementSystem.Infra;
using YghRentalManagementSystem.Infra.Config;
using YghRentalManagementSystem.Services.IReservationServices;

namespace YghRentalManagementSystem
{
    public static class HostingExtensions
    {
        private const string MyAllowSpecificOrigins = "AllowOrigin";
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Host.ConfigureAppConfiguration((hostingContext, config) => { AppSettings.Instance.SetConfiguration(hostingContext.Configuration); });
            builder.Services.AddControllers();
            //Learn more about configuring Swagger / OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<IReservationService, ReservationService>();

            var str = builder.Configuration.GetConnectionString("DefaultConnection");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
            builder.Services.AddDbContext<RentalManagementContext>(options =>
            {
                options.UseMySql(str, serverVersion);
            });


            var logger = new LoggerConfiguration().ReadFrom
                                                  .Configuration(builder.Configuration)
                                                  .Enrich
                                                  .FromLogContext()
                                                  .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            builder.Services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.MapControllers();
            app.UseCors(MyAllowSpecificOrigins);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/healthy");
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("[API] Rental Management System");
                });
            });
            app.Run();
            return app;
        }
        private static async void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var utcNow = DateTime.UtcNow;
                var context = serviceScope.ServiceProvider.GetService<RentalManagementContext>();
                await context.Database.MigrateAsync();
            }
        }

    }
}
