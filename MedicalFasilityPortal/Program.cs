using MedicalFasilityPortalView;
using MedicalFacilityPortalBuisnesLogic.BusinessLogics;
using MedicalFacilityPortalContracts.BusinessLogicsContracts;
using MedicalFacilityPortalDatabaseImplement2.Implements;
using MedicalFacilityPortalDataBaseImplement2;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MedicalFasilityPortalView
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

            Application.Run(_serviceProvider.GetRequiredService<FormServices>());
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<IServiceStorage, ServiceStorage>();
            services.AddTransient<IServiceLogic, ServiceLogic>();
            services.AddTransient<FormServices>();
        }
    }
}