using Microsoft.Extensions.DependencyInjection;
using Mongo.Contracts;
using Mongo.Database.Implements;
using Mongo.Database.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;

namespace MongoForm
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

            BsonClassMap.RegisterClassMap<Service>();
            BsonClassMap.RegisterClassMap<Patient>();
            BsonClassMap.RegisterClassMap<Doctor>();
            BsonClassMap.RegisterClassMap<Contract>();
            BsonClassMap.RegisterClassMap<NoUserContract>();
            var objectSerializer = new ObjectSerializer(type => ObjectSerializer.DefaultAllowedTypes(type) || type.FullName.StartsWith("Mongo"));
            BsonSerializer.RegisterSerializer(objectSerializer);

            Application.Run(_serviceProvider.GetRequiredService<FormMain>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {

            services.AddTransient<IMongoContractLogic, MongoContractLogic>();
            services.AddTransient<IMongoDoctorLogic, MongoDoctorLogic>();
            services.AddTransient<IMongoJobLogic, MongoJobLogic>();
            services.AddTransient<IMongoPatientLogic, MongoPatientLogic>();
            services.AddTransient<IMongoServiceLogic, MongoServiceLogic>();

            services.AddTransient<FormMain>();
            services.AddTransient<FormContract>();
            services.AddTransient<FormContracts>();
            services.AddTransient<FormDoctor>();
            services.AddTransient<FormDoctors>();
            services.AddTransient<FormDoctorServices>();
            services.AddTransient<FormJobs>();
            services.AddTransient<FormJob>();
            services.AddTransient<FormPatient>();
            services.AddTransient<FormPatients>();
            services.AddTransient<FormService>();
            services.AddTransient<FormServices>();
        }
    }
}