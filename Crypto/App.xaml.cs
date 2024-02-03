using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using Crypto.View;
using Crypto.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crypto
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider? ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs eventArgs)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(MainWindow));
            serviceCollection.AddSingleton<NavigationViewModel>();
            serviceCollection.AddSingleton<AssetsViewModel>();
            serviceCollection.AddSingleton<SearchViewModel>();
        }
    }

}
