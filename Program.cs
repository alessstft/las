using LegoCarStoreEF.Data;
using LegoCarStoreEF.Services;
using LegoCarStoreEF.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var services = new ServiceCollection();
        services.AddDbContext<LegoCarContext>(options =>
            options.UseNpgsql(config.GetConnectionString("DefaultConnection")));

        services.AddTransient<CarStoreService>();
        services.AddTransient<ConsoleUI>();

        var serviceProvider = services.BuildServiceProvider();

        var ui = serviceProvider.GetRequiredService<ConsoleUI>();
        ui.Run();
    }
}