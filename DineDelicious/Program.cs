using DineDelicious.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace DineDelicious
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddDbContext<RestaurantDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            
            builder.Services.AddControllers();

            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Dine Delicious API",
                    Version = "v1"
                });
            });

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Dine Delicious API v1");
                    options.RoutePrefix = string.Empty; // Swagger at root URL
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
