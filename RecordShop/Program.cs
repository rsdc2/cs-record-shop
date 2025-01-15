
using Microsoft.EntityFrameworkCore;


namespace RecordShop
{
    //public void 

    public class Program
    {
        public static void Main(string[] args)
        {
            // Environments
            var options = new WebApplicationOptions() { EnvironmentName = Environments.Development };
            var builder = WebApplication.CreateBuilder(options);
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var dbtype = DatabaseType.SqlServer;
            
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Connect to the database 
            if (builder.Environment.IsDevelopment())
            {
                if (dbtype == DatabaseType.InMemory)
                {
                    builder.Services.AddDbContext<RecordShopDbContext>(
                        options => options.UseInMemoryDatabase(databaseName: "RecordShopInMemory"));
                }
                else if (dbtype == DatabaseType.SqlServer)
                {
                    var connectionString = builder.Configuration.GetConnectionString("RecordShop");
                    builder.Services.AddDbContext<RecordShopDbContext>(
                        options => options.UseSqlServer(connectionString: connectionString));
                }
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

            if (dbtype == DatabaseType.InMemory)
            {
                Development.InjectDevelopmentDataIntoApp(app);
            }
            app.MapControllers();

            app.Run();
        }


    }
}
