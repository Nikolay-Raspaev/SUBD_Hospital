using MedDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedContracts.ViewModels
{
    public class PatientViewModel : IPatient
    {
        [DisplayName("Фамилия")]
        public string Surname { get; set; } = string.Empty;

        [DisplayName("Имя")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Отчество")]
        public string Patronymic { get; set; } = string.Empty;

        [DisplayName("Дата рождения")]
        public DateOnly Birthdate { get; set; }

        [DisplayName("Серия номер паспорта")]
        public string Passport { get; set; } = string.Empty;

        [DisplayName("Номер телефона")]
        public string? TelephoneNumber { get; set; }

        public int Id { get; set; }
    }
}
