using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalContracts.BuisnessLogicsContracts;
using HospitalContracts.SearchModels;
using HospitalContracts.BindingModels;

namespace HospitalView
{
    public partial class FormPatient : Form
    {
        private readonly IPatientLogic _patientLogic;
        private int? _id;
        public int Id { set { _id = value; } }

        public FormPatient(IPatientLogic logic)
        {
            InitializeComponent();
            _patientLogic = logic;
        }

        private void FormPatient_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    var view = _patientLogic.ReadElement(new PatientSearchModel
                    {
                        Id = _id.Value,
                    });
                    DateTime dateTime = view.Birthdate.ToDateTime(TimeOnly.Parse("10:00 PM"));
                    if (view != null)
                    {
                        textBoxName.Text = view.Name;
                        textBoxSurname.Text = view.Surname;
                        textBoxName.Text = view.Name;
                        textBoxPatronymic.Text = view.Patronymic;
                        dateTimePicker.Value = dateTime;
                        textBoxPassport.Text = view.Passport;
                        textBoxTelephoneNumber.Text = view.TelephoneNumber;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DateOnly Birthdate = DateOnly.FromDateTime(dateTimePicker.Value.Date);
                var model = new PatientBindingModel
                {
                    Id = _id ?? 0,
                    Surname = textBoxSurname.Text,
                    Name = textBoxName.Text,
                    Patronymic = textBoxPatronymic.Text,
                    Birthdate = Birthdate,
                    Passport = textBoxPassport.Text,
                    TelephoneNumber = textBoxTelephoneNumber.Text,
                };
                var operationResult = _id.HasValue ? _patientLogic.Update(model) : _patientLogic.Create(model);
                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
