using MedDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedContracts.ViewModels
{
    public class ContractViewModel : IContract
    {
        [DisplayName("Дата оплаты заказа")]
        public DateOnly? ExerciseDate { get; set; }

        public int ExecutionStatusId { get; set; }

        [DisplayName("Статус заказа")]
        public string ExecutionStatusName { get; set; } = string.Empty;

        public int PatientId { get; set; }

        [DisplayName("ФИО пациента")]
        public string PatientFIO { get; set; } = string.Empty;

        public int ContractDoctorsId { get; set; }

        public int ContractServicesId { get; set; }

        [DisplayName("Название услуги")]
        public string ServiceName { get; set; } = string.Empty;

        [DisplayName("ФИО врача")]
        public string DoctorFIO { get; set; } = string.Empty;

        [DisplayName("Цена услуги")]
        public decimal ServicePrice { get; set; }

        public int Id { get; set; }
    }
}