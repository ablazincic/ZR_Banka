using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using ZR_Banka.Models;
using Microsoft.EntityFrameworkCore;


namespace ZR_Banka;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    public static ZrBankaDbContext context;

    protected override void OnStartup(StartupEventArgs e)
    {
        var services = new ServiceCollection();

        // Registracija DbContext-a s konekcijskim stringom
        services.AddDbContext<ZrBankaDbContext>(options =>
            options.UseNpgsql("Host=localhost;Database=ZR_BankaDB;Username=postgres;Password=admin"));

        ServiceProvider = services.BuildServiceProvider();
        base.OnStartup(e);

        context = App.ServiceProvider.GetService<ZrBankaDbContext>(); // service za spajanje sa bazom 
    }
}

