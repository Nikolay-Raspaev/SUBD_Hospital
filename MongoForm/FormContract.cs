using Mongo.Contracts;
using Mongo.Database.Models;
using Mongo.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MongoForm
{
    public partial class FormContract : Form
    {

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
        private readonly IMongoContractLogic _contractLogic;
        private readonly IMongoDoctorLogic _doctorLogic;
        private readonly IMongoServiceLogic _serviceLogic;
        private readonly IMongoPatientLogic _patientLogic;
        private readonly List<Patient>? _listPatient;
        private readonly List<Doctor>? _listDoctor;
        private readonly List<Service>? _listService;
        private int? _id;
        public int Id { set { _id = value; } }

        public FormContract(IMongoContractLogic contractLogic, IMongoServiceLogic serviceLogic, IMongoDoctorLogic doctorLogic, IMongoPatientLogic patientLogic)
        {
            InitializeComponent();
            _contractLogic = contractLogic;
            _doctorLogic = doctorLogic;
            _serviceLogic = serviceLogic;
            _patientLogic = patientLogic;
            _listDoctor = _doctorLogic.ReadList();
            if (_listDoctor != null)
            {
                comboBoxDoctor.DisplayMember = "Name";
                comboBoxDoctor.ValueMember = "Id";
                comboBoxDoctor.DataSource = _listDoctor;
                comboBoxDoctor.SelectedItem = null;
            }
            _listService = _serviceLogic.ReadList();
            if (_listService != null)
            {
                comboBoxService.DisplayMember = "Name";
                comboBoxService.ValueMember = "Id";
                comboBoxService.DataSource = _listService;
                comboBoxService.SelectedItem = null;
            }
            _listPatient = _patientLogic.ReadList();
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
                    var view = _contractLogic.ReadElement(_id.Value);
                    if (view != null)
                    {
                        if (view.ExerciseDate != null && view.Status == "Оплачен") dateTimePicker.Value = (DateTime)view.ExerciseDate;
                        textBoxExecutionStatus.Text = view.Status;
                        comboBoxPatient.Text = view.Patient.id.ToString();
                        comboBoxDoctor.Text = view.Doctor.id.ToString();
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
                var patient = _patientLogic.ReadElement((int)comboBoxPatient.SelectedValue);
                patient.PatientContracts = null;
                var model = new Contract
                {
                    id = _id ?? 0,
                    ExerciseDate = dateTimePicker.Value.Date,
                    Status = textBoxExecutionStatus.Text,
                    Patient = patient,
                    PatientName = _patientLogic.ReadElement((int)comboBoxPatient.SelectedValue).Name,
                    Doctor = _doctorLogic.ReadElement((int)comboBoxDoctor.SelectedValue),
                    DoctorName = _doctorLogic.ReadElement((int)comboBoxDoctor.SelectedValue).Name,
                    ServiceId = (int)comboBoxService.SelectedValue,
                };
                var operationResult = false;
                if (_id == null)
                {
                    var contract = _contractLogic.CreateContract(model);
                    _id = contract.id;
                    var noUserContract = new NoUserContract
                    {
                        id = contract.id,
                        ExerciseDate = contract.ExerciseDate,
                        Status = contract.Status,
                        Doctor = contract.Doctor,
                        DoctorName = contract.Doctor.Name,
                        ServiceId = contract.ServiceId
                    };
                    List<INoUserContract> listContract = new List<INoUserContract>();
                    var patient1 = _patientLogic.ReadElement(model.Patient.id);
                    if (patient1.PatientContracts == null)
                    {
                        listContract = new() { noUserContract };
                    }
                    else 
                    {
                        foreach (var contr in patient1.PatientContracts)
                        {
                            listContract.Add(new NoUserContract{
                                id = contr.id,
                                ExerciseDate = contr.ExerciseDate,
                                Status = contr.Status,
                                Doctor = contr.Doctor,
                                DoctorName = contr.Doctor.Name,
                                ServiceId = contr.ServiceId
                            });
                        }
                        listContract.Add(noUserContract);
                    }
                    
                    
                    _patientLogic.UpdatePatient(new Patient
                    {
                        id = model.Patient.id,
                        Surname = model.Patient.Surname,
                        Name = model.Patient.Name,
                        Patronymic = model.Patient.Patronymic,
                        Birthdate = model.Patient.Birthdate,
                        Passport = model.Patient.Passport,
                        TelephoneNumber = model.Patient.TelephoneNumber,
                        PatientContracts = listContract
                    });
                    if (_id != null) operationResult = true;
                }
                else
                {
                    operationResult = _contractLogic.UpdateContract(model);
                    var noUserContract = new NoUserContract
                    {
                        ExerciseDate = model.ExerciseDate,
                        Status = model.Status,
                        Doctor = model.Doctor,
                        DoctorName = model.Doctor.Name,
                        ServiceId = model.ServiceId
                    };
                    if (model.Patient.PatientContracts == null) model.Patient.PatientContracts = new List<INoUserContract> { noUserContract };
                    else model.Patient.PatientContracts.Add(noUserContract);
                    _patientLogic.UpdatePatient(new Patient
                    {
                        Surname = model.Patient.Surname,
                        Name = model.Patient.Name,
                        Patronymic = model.Patient.Patronymic,
                        Birthdate = model.Patient.Birthdate,
                        Passport = model.Patient.Passport,
                        TelephoneNumber = model.Patient.TelephoneNumber,
                        PatientContracts = model.Patient.PatientContracts
                    });

                }
                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                }
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
