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
        public int Id { get; set; }

        [DisplayName("Дата оплаты")]
        public DateOnly ExerciseDate { get; set; }

        [DisplayName("Статус контракта")]
        public string ExecutionStatusName { get; set; } = string.Empty;

        [DisplayName("ФИО пациента")]
        public string PatientFIO { get; set; } = string.Empty;

        [DisplayName("ФИО врача")]
        public string DoctorFIO { get; set; } = string.Empty;

        [DisplayName("Услуга")]
        public string ServiceName { get; set; } = string.Empty;

        [DisplayName("Цена услуги")]
        public decimal ServicePrice { get; set; }
    }
}
