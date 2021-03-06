using BookShop.BLL;
using BookShop.DAL;
using BookShop.Models;
using BookShop.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BookShop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public static IConfigurationRoot Configuration { get; set; }

        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            // NOTE: configuration implementation might cause problems later.
            services.AddDbContext<LibraryContext>();
            services.AddScoped<IProductRepository<Book>, BookRepository>();
            services.AddScoped<IProductRepository<Journal>, JournalRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}