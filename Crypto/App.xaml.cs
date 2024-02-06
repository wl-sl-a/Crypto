using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using Crypto.View;
using Crypto.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Crypto.Services;
using System.Net.Http;
using System;

namespace Crypto
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder().ConfigureServices(services => ConfigureServices(services)).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (host)
            {
                await host.StartAsync();

                var mainWindow = host.Services.GetService<MainWindow>();
                var mainWindowViewModel = host.Services.GetService<NavigationViewModel>();

                mainWindow.DataContext = mainWindowViewModel;
                mainWindow.Show();
            }
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            using (host)
            {
                await host.StopAsync();
            }
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<NavigationViewModel>();
            services.AddSingleton<AssetsViewModel>();
            services.AddSingleton<SearchViewModel>();
            services.AddSingleton<AssetDetailsViewModel>();
            services.AddSingleton<IAssetService, AssetService>();
            services.AddSingleton<IAssetMarketService, AssetMarketService>();
            services.AddSingleton<IApiService, ApiService>();
        }
    }

}
