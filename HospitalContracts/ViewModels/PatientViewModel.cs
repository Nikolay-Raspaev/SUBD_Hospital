using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.ViewModels
{
    public class PatientViewModel : IPatient
    {
        public int Id { get; }

        [DisplayName("Фамилия")]
        public string Surname { get; } = string.Empty;

        [DisplayName("Имя")]
        public string Name { get; } = string.Empty;

        [DisplayName("Отчество")]
        public string Patronymic { get; } = string.Empty;

        [DisplayName("Дата рождения")]
        public DateOnly Birthdate { get; }

        [DisplayName("Паспорт")]
        public string Passport { get; } = string.Empty;

        [DisplayName("Телефон")]
        public string TelephoneNumber { get; } = string.Empty;
    }
}
