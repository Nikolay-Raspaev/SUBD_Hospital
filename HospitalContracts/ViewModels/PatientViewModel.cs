using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.ViewModels
{
    public class PatientSearchModel : IPatient
    {
        public int Id { get; set; }

        [DisplayName("Фамилия")]
        public string Surname { get; set; } = string.Empty;

        [DisplayName("Имя")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Отчество")]
        public string Patronymic { get; set; } = string.Empty;

        [DisplayName("Дата рождения")]
        public DateOnly Birthdate { get; set; }

        [DisplayName("Паспорт")]
        public string Passport { get; set; } = string.Empty;

        [DisplayName("Телефон")]
        public string TelephoneNumber { get; set; } = string.Empty;
    }
}
