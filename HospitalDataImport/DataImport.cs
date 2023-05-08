
using HospitalBuisnessLogic.BuisnessLogic;
using HospitalBuisnessLogic.BuisnessLogicsContracts;
using HospitalContracts.SearchModels;
using HospitalDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mongo.Contracts;
using Mongo.Database.Models;
using Mongo.Models;
using System.Collections.Generic;

namespace HospitalDataImport
{
    public class DataImport : IDataImport
    {
        private readonly IContractLogic _contractLogic;
        private readonly IDoctorLogic _doctorLogic;
        private readonly IServiceLogic _serviceLogic;
        private readonly IJobLogic _jobLogic;
        private readonly IPatientLogic _patientLogic;
        private readonly IMongoContractLogic _contracMongoLogic;
        private readonly IMongoDoctorLogic _doctorMongoLogic;
        private readonly IMongoServiceLogic _serviceMongoLogic;
        private readonly IMongoJobLogic _jobMongoLogic;
        private readonly IMongoPatientLogic _patientMongoLogic;

        public DataImport(
            IContractLogic contractLogic,
            IDoctorLogic doctorLogic,
            IServiceLogic serviceLogic,
            IPatientLogic patientLogic,
            IJobLogic jobLogic,
            IMongoContractLogic contracMongoLogic,
            IMongoDoctorLogic doctorMongoLogic,
            IMongoServiceLogic serviceMongoLogic,
            IMongoJobLogic jobMongoLogic,
            IMongoPatientLogic patientMongoLogic) 
        {
            _contractLogic = contractLogic;
            _doctorLogic = doctorLogic;
            _serviceLogic = serviceLogic;            
            _patientLogic = patientLogic;
            _jobLogic = jobLogic;

            _patientMongoLogic = patientMongoLogic;
            _jobMongoLogic = jobMongoLogic;
            _serviceMongoLogic = serviceMongoLogic;
            _doctorMongoLogic = doctorMongoLogic;
            _contracMongoLogic = contracMongoLogic;
        }
        public void DataImportContract()
        {
            _contracMongoLogic.DeleteAllContract();
            var listContract = _contractLogic.ReadListContract(null);
            foreach (var contract in listContract)
            {
                DateTime dateTime = contract.ExerciseDate.ToDateTime(TimeOnly.Parse("10:00 PM"));
                DateTime birthdate = contract.Patient.Birthdate.ToDateTime(TimeOnly.Parse("10:00 PM"));
                DateTime doctorBirthdate = contract.ContractNavigation.Doctors.Birthdate.ToDateTime(TimeOnly.Parse("10:00 PM"));
                List<IService> doctorServices = new List<IService>();
                foreach (var service in _doctorLogic.ReadElement(new DoctorSearchModel { Id = contract.ContractNavigation.DoctorsId }).DoctorServices)
                {
                    doctorServices.Add(new Mongo.Database.Models.Service
                    {
                        id = service.Value.Id,
                        Name = service.Value.ServiceName,
                        Price = (double)service.Value.ServicePrice,
                    });
                }
                _contracMongoLogic.CreateContract(new Mongo.Database.Models.Contract
                {
                    id = contract.Id,
                    ExerciseDate = dateTime,
                    Status = contract.ExecutionStatus.ExecutionStatusName,
                    Patient = new Mongo.Database.Models.Patient
                    {
                        id = contract.Patient.Id,
                        Surname = contract.Patient.Surname,
                        Name = contract.Patient.Name,
                        Patronymic = contract.Patient.Patronymic,
                        Birthdate = birthdate,
                        Passport = contract.Patient.Passport,
                        TelephoneNumber = contract.Patient.TelephoneNumber,
                        PatientContracts = null
                    },
                    PatientName = contract.Patient.Name,
                    Doctor = new Mongo.Database.Models.Doctor 
                    {
                        id = contract.ContractNavigation.DoctorsId,
                        Surname = contract.ContractNavigation.Doctors.Surname,
                        Name = contract.ContractNavigation.Doctors.Name,
                        Patronymic = contract.ContractNavigation.Doctors.Patronymic,
                        Birthdate = doctorBirthdate,
                        Passport = contract.ContractNavigation.Doctors.Passport,
                        TelephoneNumber = contract.ContractNavigation.Doctors.TelephoneNumber,
                        Education = contract.ContractNavigation.Doctors.Education,
                        JobTitle = contract.ContractNavigation.Doctors.Job.JobTitle,
                        AcademicRank = contract.ContractNavigation.Doctors.AcademicRank.AcademicRankName,
                        DoctorServices = doctorServices,
                    },
                    DoctorName = _doctorLogic.ReadElement(new DoctorSearchModel { Id = contract.ContractDoctorsId }).Name,
                    ServiceId = contract.ContractServicesId
                });
            }
        }

        public void DataImportDoctor()
        {
            throw new NotImplementedException();
        }

        public void DataImportJob()
        {
            _jobMongoLogic.DeleteAllJob();
            var listJob = _jobLogic.ReadList(null);
            foreach (var job in listJob)
            {
                _jobMongoLogic.CreateJob(new Mongo.Database.Models.Job
                {
                    id = job.Id,
                    jobTitle = job.JobTitle
                });
            }
        }
        int id { get; }
        DateTime? ExerciseDate { get; }
        string Status { get; }
        IDoctor Doctor { get; }
        string DoctorName { get; }
        int ServiceId { get; }
        public void DataImportPatient()
        {
            _patientMongoLogic.DeleteAllPatient();
            var listPatient = _patientLogic.ReadListPatient();
            foreach (var patient in listPatient)
            {
                DateTime dateTime = patient.Birthdate.ToDateTime(TimeOnly.Parse("10:00 PM"));
                
                List<INoUserContract> patientContracts = new List<INoUserContract>();
                foreach (var contract in patient.Contracts)
                {
                    DateTime dateTime2 = contract.ExerciseDate.ToDateTime(TimeOnly.Parse("10:00 PM"));
                    DateTime doctorBirthdate = contract.ContractNavigation.Doctors.Birthdate.ToDateTime(TimeOnly.Parse("10:00 PM"));
                    List<IService> doctorServices = new List<IService>();
                    foreach (var service in _doctorLogic.ReadElement(new DoctorSearchModel { Id = contract.ContractNavigation.DoctorsId }).DoctorServices)
                    {
                        doctorServices.Add(new Mongo.Database.Models.Service
                        {
                            id = service.Value.Id,
                            Name = service.Value.ServiceName,
                            Price = (double)service.Value.ServicePrice,
                        });
                    }
                    patientContracts.Add(new NoUserContract
                    {
                        id = contract.Id,
                        ExerciseDate = dateTime2,
                        Status = contract.ExecutionStatus.ExecutionStatusName,
                        Doctor = new Mongo.Database.Models.Doctor
                        {
                            id = contract.ContractNavigation.DoctorsId,
                            Surname = contract.ContractNavigation.Doctors.Surname,
                            Name = contract.ContractNavigation.Doctors.Name,
                            Patronymic = contract.ContractNavigation.Doctors.Patronymic,
                            Birthdate = doctorBirthdate,
                            Passport = contract.ContractNavigation.Doctors.Passport,
                            TelephoneNumber = contract.ContractNavigation.Doctors.TelephoneNumber,
                            Education = contract.ContractNavigation.Doctors.Education,
                            JobTitle = contract.ContractNavigation.Doctors.Job.JobTitle,
                            AcademicRank = contract.ContractNavigation.Doctors.AcademicRank.AcademicRankName,
                            DoctorServices = doctorServices,
                        },
                        DoctorName = _doctorLogic.ReadElement(new DoctorSearchModel { Id = contract.ContractDoctorsId }).Name,
                        ServiceId = contract.ContractServicesId
                    });
                    _patientMongoLogic.CreatePatient(new Mongo.Database.Models.Patient
                    {
                        id = patient.Id,
                        Surname = patient.Surname,
                        Name = patient.Name,
                        Patronymic = patient.Patronymic,
                        Birthdate = dateTime,
                        Passport = patient.Passport,
                        TelephoneNumber = patient.TelephoneNumber,
                        PatientContracts = patientContracts,
                    });
                }
            }
        }

        public void DataImportService()
        {
            _serviceMongoLogic.DeleteAllService();
            var listService = _serviceLogic.ReadList(0);
            foreach (var service in listService)
            {
                _serviceMongoLogic.CreateService(new Mongo.Database.Models.Service
                {
                    id = service.Id,
                    Name = service.ServiceName,
                    Price = (double)service.ServicePrice
                });
            }
        }
    }
}