using HospitalBuisnessLogic.BuisnessLogic;
using HospitalContracts.BindingModels;
using HospitalContracts.BuisnessLogicsContracts;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using HospitalDatabaseImplement.Models;
using HospitalDataModels.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalView
{
    public partial class FormContract : Form
    {


        public int ExecutionStatusId
        {
            get
            {
                return Convert.ToInt32(comboBoxExecutionStatus.SelectedValue);
            }
            set
            {
                comboBoxExecutionStatus.SelectedValue = value;
            }
        }
        
        public int IdPatient
        {
            get
            {
                return Convert.ToInt32(comboBoxPatient.SelectedValue);
            }
            set
            {
                comboBoxPatient.SelectedValue = value;
            }
        }
        
        public int IdDoctor
        {
            get
            {
                return Convert.ToInt32(comboBoxDoctor.SelectedValue);
            }
            set
            {
                comboBoxDoctor.SelectedValue = value;
            }
        }
        public int IdService
        {
            get
            {
                return Convert.ToInt32(comboBoxService.SelectedValue);
            }
            set
            {
                comboBoxService.SelectedValue = value;
            }
        }
        private readonly IContractLogic _contractLogic;
        private readonly IDoctorLogic _doctorLogic;
        private readonly IServiceLogic _serviceLogic;
        private readonly IExecutionStatusLogic _executionStatusLogic;
        private readonly IPatientLogic _patientLogic;
        private readonly List<ExecutionStatusViewModel>? _listExecutionStatus;
        private readonly List<PatientViewModel>? _listPatient;
        private readonly List<DoctorViewModel>? _listDoctor;
        private readonly List<ServiceViewModel>? _listService;
        private int? _id;
        public int Id { set { _id = value; } }

        public FormContract(IContractLogic contractLogic, IServiceLogic serviceLogic, IExecutionStatusLogic executionStatusLogic, IDoctorLogic doctorLogic, IPatientLogic patientLogic)
        {
            InitializeComponent();
            _contractLogic = contractLogic;
            _executionStatusLogic = executionStatusLogic;
            _doctorLogic = doctorLogic;
            _serviceLogic = serviceLogic;
            _patientLogic = patientLogic;

            _listExecutionStatus = _executionStatusLogic.ReadList(null);
            if (_listExecutionStatus != null)
            {
                comboBoxExecutionStatus.DisplayMember = "ExecutionStatusName";
                comboBoxExecutionStatus.ValueMember = "Id";
                comboBoxExecutionStatus.DataSource = _listExecutionStatus;
                comboBoxExecutionStatus.SelectedItem = null;
            }
            _listDoctor = _doctorLogic.ReadList(null);
            if (_listDoctor != null)
            {
                comboBoxDoctor.DisplayMember = "Name";
                comboBoxDoctor.ValueMember = "Id";
                comboBoxDoctor.DataSource = _listDoctor;
                comboBoxDoctor.SelectedItem = null;
            }
            _listService = _serviceLogic.ReadList(null);
            if (_listService != null)
            {
                comboBoxService.DisplayMember = "ServiceName";
                comboBoxService.ValueMember = "Id";
                comboBoxService.DataSource = _listService;
                comboBoxService.SelectedItem = null;
            }
            _listPatient = _patientLogic.ReadList(null);
            if (_listPatient != null)
            {
                comboBoxPatient.DisplayMember = "Name";
                comboBoxPatient.ValueMember = "Id";
                comboBoxPatient.DataSource = _listPatient;
                comboBoxPatient.SelectedItem = null;
            }
        }

        private void FormContract_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    var view = _contractLogic.ReadElement(new ContractSearchModel
                    {
                        Id = _id.Value,
                    });
                    DateTime dateTime = view.ExerciseDate.ToDateTime(TimeOnly.Parse("10:00 PM"));
                    if (view != null && view.ExecutionStatusName == "Оплачен")
                    {
                        dateTimePicker.Value = dateTime;
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
            try
            {
                DateOnly dateTime;
                if (comboBoxExecutionStatus.Text == "Оплачен")
                {
                    dateTime = DateOnly.FromDateTime(dateTimePicker.Value.Date);
                }
                var model = new ContractBindingModel
                {
                    Id = _id ?? 0,

                    ExerciseDate = dateTime,
                    ExecutionStatusId = (int)comboBoxExecutionStatus.SelectedValue,
                    PatientId = (int)comboBoxPatient.SelectedValue,
                    ContractDoctorsId = (int)comboBoxPatient.SelectedValue,
                    ContractServicesId = (int)comboBoxDoctor.SelectedValue,
                };
                var operationResult = _id.HasValue ? _contractLogic.Update(model) : _contractLogic.Create(model);
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
