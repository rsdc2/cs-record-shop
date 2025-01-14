
using Microsoft.EntityFrameworkCore;

namespace RecordShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           
            if (environment == "Development")
            {
                builder.Services.AddDbContext<RecordShopDbContext>(options => options.UseInMemoryDatabase(databaseName: "RecordShopDB"));
            }
            builder.Services.AddScoped<IAlbumsModel, AlbumsModel>();
            builder.Services.AddScoped<IAlbumsService, AlbumsService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
