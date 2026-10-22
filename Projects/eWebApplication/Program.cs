using DataLayer.DataModel;
using eShopWebApplication.Services;
using eShopWebApplication.Services.IServiceInterface;
using Microsoft.EntityFrameworkCore;
using SQLDataLayer.Repository;

namespace eWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

           var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<eShopWebDB>(options => 
                options.UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            );

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IProductService, ProductService>();


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
