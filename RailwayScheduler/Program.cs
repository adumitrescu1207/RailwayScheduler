using RailwayScheduler.Database;
using RailwayScheduler.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;

namespace RailwayScheduler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RailwayScheduler API", Version = "v1" });
            });
            builder.Services.AddScoped<TrainService>();
            builder.Services.AddDbContext<DatabaseContext>(o =>
                o.UseSqlite("Data Source=TrainDatabase.db"));
            //Add CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder => builder.WithOrigins("http://localhost:5173")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            var app = builder.Build();

            // Ensure the database is created and migrations are applied
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                dbContext.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RailwayScheduler API V1");
                c.RoutePrefix = string.Empty; 
            });

            app.Run();
        }
    }
}
