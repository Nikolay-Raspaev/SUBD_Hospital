using BuisnessLogic;
using MedContracts.BuisnessLogics;
using MedContracts.StoragesContracts;
using MedDataBaseImplement;
using MedDataBaseImplement.Implements;
using Microsoft.Extensions.DependencyInjection;

namespace MedView
{
    public static class Program
    {
        private static ServiceProvider? _serviceProvider;
        public static ServiceProvider? ServiceProvider => _serviceProvider;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            Application.Run(_serviceProvider.GetRequiredService<FormMain>());
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<IServiceStorage, ServiceStorage>();
            services.AddTransient<IJobStorage, JobStorage>();
            services.AddTransient<IServiceLogic, ServiceLogic>();
            services.AddTransient<IJobLogig, JobLogic>();
            services.AddTransient<FormServices>();
            services.AddTransient<FormService>();
            services.AddTransient<FormJobs>();
            services.AddTransient<FormJob>();
            services.AddTransient<FormMain>();
        }
    }
}