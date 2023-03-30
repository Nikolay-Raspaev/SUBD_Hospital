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
        private readonly List<ExecutionStatusViewModel>? _listExecutionStatus;
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
        public IExecutionStatus? _executionStatus
        {
            get
            {
                if (_listExecutionStatus == null)
                {
                    return null;
                }
                foreach (var elem in _listExecutionStatus)
                {
                    if (elem.Id == ExecutionStatusId)
                    {
                        return elem;
                    }
                }
                return null;
            }
        }
        private readonly List<PatientViewModel>? _listPatient;
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
        public IPatient? _patient
        {
            get
            {
                if (_listPatient == null)
                {
                    return null;
                }
                foreach (var elem in _listPatient)
                {
                    if (elem.Id == IdPatient)
                    {
                        return elem;
                    }
                }
                return null;
            }
        }
        private readonly List<DoctorServiceViewModel>? _listDoctorService;
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
        public IDoctorService? _doctorService
        {
            get
            {
                if (_listDoctorService == null)
                {
                    return null;
                }
                foreach (var elem in _listDoctorService)
                {
                    if (elem.DoctorsId == IdDoctor && elem.ServicesId == IdService)
                    {
                        return elem;
                    }
                }
                return null;
            }
        }
        private readonly IContractLogic _contractLogic;
        private readonly IDoctorServiceLogic _doctorServicetLogic;
        private readonly IExecutionStatusLogic _executionStatusLogic;
        private readonly IPatientLogic _patientLogic;
        private int? _id;
        public int Id { set { _id = value; } }

        public FormContract(IContractLogic contractLogic, IExecutionStatusLogic executionStatusLogic, IDoctorServiceLogic doctorServicetLogic, IPatientLogic patientLogic)
        {
            InitializeComponent();
            _contractLogic = contractLogic;
            _executionStatusLogic = executionStatusLogic;
            _doctorServicetLogic = doctorServicetLogic;
            _patientLogic = patientLogic;

            _listExecutionStatus = _executionStatusLogic.ReadList(null);
            if (_list != null)
            {
                comboBoxComponent.DisplayMember = "ComponentName";
                comboBoxComponent.ValueMember = "Id";
                comboBoxComponent.DataSource = _list;
                comboBoxComponent.SelectedItem = null;
            }
            _listPatient = _doctorServicetLogic.ReadList(null);
            if (_list != null)
            {
                comboBoxComponent.DisplayMember = "ComponentName";
                comboBoxComponent.ValueMember = "Id";
                comboBoxComponent.DataSource = _list;
                comboBoxComponent.SelectedItem = null;
            }
            _listDoctorService = _patientLogic.ReadList(null);
            if (_list != null)
            {
                comboBoxComponent.DisplayMember = "ComponentName";
                comboBoxComponent.ValueMember = "Id";
                comboBoxComponent.DataSource = _list;
                comboBoxComponent.SelectedItem = null;
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
                    if (view != null)
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
                DateOnly dateTime = DateOnly.FromDateTime(dateTimePicker.Value.Date);
                var model = new ContractBindingModel
                {
                    Id = _id ?? 0,
                    ExerciseDate = dateTime,
                    ExecutionStatusId = comboBoxExecutionStatus.SelectedValue,
                    PatientId = comboBoxPatient.SelectedValue,
                    ContractDoctorsId = comboBoxPatient.SelectedValue,
                    ContractServicesId = comboBoxDoctor.SelectedValue,
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
