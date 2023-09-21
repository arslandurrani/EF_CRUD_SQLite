using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Windows;

using Task2.Database.Repositories;
using Task2.DB;

namespace Task2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Private members
        private readonly ServiceProvider serviceProvider;
        #endregion

        #region Constructor
        public App()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<AppDbContext>();
            services.AddSingleton<EmployeeRepository>();
            services.AddSingleton<MainWindow>();

            serviceProvider = services.BuildServiceProvider();

            // Run migration on ensure the DB is updated
            var db = serviceProvider.GetRequiredService<AppDbContext>();
            db.Database.Migrate();
        }
        #endregion


        #region Event Handlers
        private void OnStartup(object s, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
        #endregion
    }
}
