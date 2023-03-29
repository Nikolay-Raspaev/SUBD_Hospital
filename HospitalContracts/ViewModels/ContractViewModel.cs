using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.ViewModels
{
    public class ContractViewModel : IContract
    {
        public int Id { get; }

        [DisplayName("Дата оплаты")]
        public DateOnly ExerciseDate { get; }

        [DisplayName("Статус контракта")]
        public string ExecutionStatusName { get; } = string.Empty;

        [DisplayName("ФИО пациента")]
        public string PatientFIO { get; } = string.Empty;

        [DisplayName("ФИО врача")]
        public string DoctorFIO { get; } = string.Empty;

        [DisplayName("Услуга")]
        public string ServiceName { get; } = string.Empty;

        [DisplayName("Цена услуги")]
        public decimal ServicePrice { get; }
    }
}
