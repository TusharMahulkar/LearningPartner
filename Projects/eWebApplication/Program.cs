using DataLayer.DataModel;
using eShopWebApplication.Services;
using eShopWebApplication.Services.IServiceInterface;
using Microsoft.EntityFrameworkCore;

namespace eWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddDbContext<eShopWebDB>(options => 
                options.UseSqlServer()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            );

            builder.Services.AddScoped<ICustomerService, CustomerService>();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI();

            //app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
