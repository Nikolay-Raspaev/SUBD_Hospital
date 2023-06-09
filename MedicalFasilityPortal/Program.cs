using HospitalBuisnessLogic.BuisnessLogic;
using HospitalDatabaseImplement;
using HospitalDatabaseImplement.Implements;
using Microsoft.Extensions.DependencyInjection;
using HospitalDataImport;
using Mongo.Contracts;
using Mongo.Database.Implements;
using HospitalDatabaseImplement.StoragesContracts;
using HospitalBuisnessLogic.BuisnessLogicsContracts;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;

namespace HospitalView
{
    internal static class Program
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
            var objectSerializer = new ObjectSerializer(type => ObjectSerializer.DefaultAllowedTypes(type) || type.FullName.StartsWith("Mongo"));
            BsonSerializer.RegisterSerializer(objectSerializer);

            Application.Run(_serviceProvider.GetRequiredService<FormMain>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<IAcademicRankStorage, AcademicRankStorage>();
            services.AddTransient<IContractStorage, ContractStorage>();
            services.AddTransient<IDoctorStorage, DoctorStorage>();
            services.AddTransient<IExecutionStatusStorage, ExecutionStatusStorage>();
            services.AddTransient<IJobStorage, JobStorage>();
            services.AddTransient<IPatientStorage, PatientStorage>();
            services.AddTransient<IServiceStorage, ServiceStorage>();

            services.AddTransient<IAcademicRankLogic, AcademicRankLogic>();
            services.AddTransient<IContractLogic, ContractLogic>();
            services.AddTransient<IDoctorLogic, DoctorLogic>();
            services.AddTransient<IExecutionStatusLogic, ExecutionStatusLogic>();
            services.AddTransient<IJobLogic, JobLogic>();
            services.AddTransient<IPatientLogic, PatientLogic>();
            services.AddTransient<IServiceLogic, ServiceLogic>();

            services.AddTransient<IMongoContractLogic, MongoContractLogic>();
            services.AddTransient<IMongoDoctorLogic, MongoDoctorLogic>();
            services.AddTransient<IMongoJobLogic, MongoJobLogic>();
            services.AddTransient<IMongoPatientLogic, MongoPatientLogic>();
            services.AddTransient<IMongoServiceLogic, MongoServiceLogic>();

            services.AddTransient<IDataImport, DataImport>();
            
            services.AddTransient<FormMain>();
            services.AddTransient<FormAcademicRank>();
            services.AddTransient<FormAcademicRanks>();
            services.AddTransient<FormContract>();
            services.AddTransient<FormContracts>();
            services.AddTransient<FormDoctor>();
            services.AddTransient<FormDoctors>();
            services.AddTransient<FormDoctorServices>();
            services.AddTransient<FormExecutionStatus>();
            services.AddTransient<FormExecutionStatuses>();
            services.AddTransient<FormJob>();
            services.AddTransient<FormJobs>();
            services.AddTransient<FormJobServices>();
            services.AddTransient<FormPatient>();
            services.AddTransient<FormPatients>();
            services.AddTransient<FormService>();
            services.AddTransient<FormServices>();
            services.AddTransient<FormRandom>(); 
            services.AddTransient<FormDataImport>(); 
        }
    }
}