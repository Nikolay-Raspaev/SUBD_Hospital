using MedDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedContracts.ViewModels
{
    public class DoctorViewModels : IDoctor
    {
        [DisplayName("Фамилия")]
        public string Surname { get; set; } = string.Empty;

        [DisplayName("Имя")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Отчество")]
        public string Patronymic { get; set; } = string.Empty;

        [DisplayName("Датарождения")]
        public DateOnly? Birthdate { get; set; }

        [DisplayName("Серия номер паспорта")]
        public string Passport { get; set; } = string.Empty;

        [DisplayName("Номер телефона")]
        public string? TelephoneNumber { get; set; } = string.Empty;

        [DisplayName("Образование")]
        public string Education { get; set; } = string.Empty;

        public int JobId { get; set; }

        [DisplayName("Название должности")]
        public string JobName { get; set; } = string.Empty;

        public int? AcademicRankId { get; set; }

        [DisplayName("Учёная степень")]
        public string? AcademicRankName { get; set; }

        public int Id { get; set; }
    }
}