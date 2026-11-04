using FTELMarket.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FTELMarket;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var frontCorsPolicy = "AllowFrontend";

        builder.Services.AddCors(options => 
        {
            options.AddPolicy(frontCorsPolicy, policy => {
                policy.WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Services.AddDbContext<FtelMarketDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("FtelMarket")));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseCors(frontCorsPolicy);
        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
