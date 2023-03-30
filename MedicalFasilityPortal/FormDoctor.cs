using HospitalContracts.BindingModels;
using HospitalContracts.BuisnessLogicsContracts;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using HospitalDatabaseImplement.Models;
using HospitalDataModels.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalView
{
    public partial class FormDoctor : Form
    {

        private Dictionary<int, IService> _doctorServices;

        private readonly List<AcademicRankViewModel>? _listAcademicRanks;

        private readonly List<JobViewModel>? _listJobs;

        public int IdJob
        {
            get
            {
                return Convert.ToInt32(comboBoxJob.SelectedValue);
            }
            set
            {
                comboBoxJob.SelectedValue = value;
            }
        }

        private readonly IDoctorLogic _doctorLogic;

        private readonly IJobLogic _jobLogic;

        private readonly IAcademicRankLogic _academicRankLogic;

        private int? _id;



        public int Id { set { _id = value; } }

        public FormDoctor(IDoctorLogic doctorLogic, IJobLogic jobLogic, IAcademicRankLogic academicRankLogic)
        {
            InitializeComponent();
            _doctorLogic = doctorLogic;
            _jobLogic = jobLogic;
            _academicRankLogic = academicRankLogic;

            _doctorServices = new Dictionary<int, IService>();

            _listJobs = _jobLogic.ReadList(null);
            _listAcademicRanks = _academicRankLogic.ReadList(null);

            if (_listJobs != null)
            {
                comboBoxJob.DisplayMember = "JobTitle";
                comboBoxJob.ValueMember = "Id";
                comboBoxJob.DataSource = _listJobs;
                comboBoxJob.SelectedItem = null;
            }

            if (_listAcademicRanks != null)
            {
                comboBoxAcademicRank.DisplayMember = "AcademicRankName";
                comboBoxAcademicRank.ValueMember = "Id";
                comboBoxAcademicRank.DataSource = _listAcademicRanks;
                comboBoxAcademicRank.SelectedItem = null;
            }
        }
        private void FormDoctor_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    var view = _doctorLogic.ReadElement(new DoctorSearchModel
                    {
                        Id = _id.Value
                    });
                    DateTime dateTime = view.Birthdate.ToDateTime(TimeOnly.Parse("10:00 PM"));
                    if (view != null)
                    {
                        textBoxSurname.Text = view.Surname;
                        textBoxName.Text = view.Name;
                        textBoxPatronymic.Text = view.Patronymic;
                        dateTimePicker.Value = dateTime;
                        textBoxPassport.Text = view.Passport;
                        textBoxTelephoneNumber.Text = view.TelephoneNumber;
                        textBoxEducation.Text = view.Education;
                        comboBoxJob.Text = view.JobTitle;
                        comboBoxAcademicRank.Text = view.AcademicRankName;
                        _doctorServices = view.DoctorServices ?? new Dictionary<int, IService>();
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private void LoadData()
        {
            try
            {
                if (_doctorServices != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var dc in _doctorServices)
                    {
                        dataGridView.Rows.Add(new object[] { dc.Key, dc.Value.ServiceName, dc.Value.ServicePrice });
                    }
                    textBoxPrice.Text = CalcPrice().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormDoctorServices));
            if (service is FormDoctorServices form)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.ServiceModel == null)
                    {
                        return;
                    }
                    if (_doctorServices.ContainsKey(form.Id))
                    {
                        _doctorServices[form.Id] = form.ServiceModel;
                    }
                    else
                    {
                        _doctorServices.Add(form.Id, form.ServiceModel);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormDoctorServices));
                if (service is FormDoctorServices form)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    form.Id = id;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (form.ServiceModel == null)
                        {
                            return;
                        }
                        _doctorServices[form.Id] = form.ServiceModel;
                        LoadData();
                    }
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _doctorServices?.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEducation.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DateOnly Birthdate = DateOnly.FromDateTime(dateTimePicker.Value.Date);
                var model = new DoctorBindingModel
                {
                    Id = _id ?? 0,
                    Surname = textBoxSurname.Text,
                    Name = textBoxName.Text,
                    Patronymic = textBoxPatronymic.Text,
                    Birthdate = Birthdate,
                    Passport = textBoxPassport.Text,
                    TelephoneNumber = textBoxTelephoneNumber.Text,
                    Education = textBoxEducation.Text,
                    Jobid = (int)comboBoxJob.SelectedValue,
                    AcademicRankId = (int)comboBoxAcademicRank.SelectedValue,
                    DoctorServices = _doctorServices,
                };
                var operationResult = _id.HasValue ? _doctorLogic.Update(model) : _doctorLogic.Create(model);
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
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private decimal CalcPrice()
        {
            decimal price = 0;
            foreach (var elem in _doctorServices)
            {
                price += (elem.Value.ServicePrice);
            }
            return Decimal.Multiply(price, 1.1m);
        }
    }
}
