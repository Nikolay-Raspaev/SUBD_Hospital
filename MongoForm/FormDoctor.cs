using Mongo.Contracts;
using Mongo.Database.Models;
using Mongo.Models;

namespace MongoForm
{
    public partial class FormDoctor : Form
    {
        private List<IService> _doctorServices = new List<IService>();

        private readonly IMongoDoctorLogic _doctorLogic;

        private int? _id;



        public int Id { set { _id = value; } }

        public FormDoctor(IMongoDoctorLogic doctorLogic, IMongoServiceLogic serviceLogic)
        {
            InitializeComponent();
            _doctorLogic = doctorLogic;
        }
        private void FormDoctor_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    var view = _doctorLogic.ReadElement(_id.Value);
                    if (view != null)
                    {
                        textBoxSurname.Text = view.Surname;
                        textBoxName.Text = view.Name;
                        textBoxPatronymic.Text = view.Patronymic;
                        dateTimePicker.Value = (DateTime)view.Birthdate;
                        textBoxPassport.Text = view.Passport;
                        textBoxTelephoneNumber.Text = view.TelephoneNumber;
                        textBoxEducation.Text = view.Education;
                        textBoxJob.Text = view.JobTitle;
                        textBoxAcademicRank.Text = view.AcademicRank;
                        _doctorServices = view.DoctorServices.ToList();
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
                        dataGridView.Rows.Add(new object[] { dc.id, dc.Name, dc.Price });
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
                if (dataGridView.SelectedRows.Count == 1) 
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    form.Id = id;
                }
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.ServiceModel == null)
                    {
                        return;
                    }
                    _doctorServices.Add(form.ServiceModel);
                    //_doctorServices[form.Id] = form.ServiceModel;
                    LoadData();
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
                        _doctorServices?.RemoveAt(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value) -1);
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
                var model = new Doctor
                {
                    id = _id ?? 0,
                    Surname = textBoxSurname.Text,
                    Name = textBoxName.Text,
                    Patronymic = textBoxPatronymic.Text,
                    Birthdate = dateTimePicker.Value.Date,
                    Passport = textBoxPassport.Text,
                    TelephoneNumber = textBoxTelephoneNumber.Text,
                    Education = textBoxEducation.Text,
                    JobTitle = textBoxJob.Text,
                    AcademicRank = textBoxAcademicRank.Text,
                    DoctorServices = _doctorServices,
                };
                var operationResult = false;
                if (_id == null)
                {
                    _id = _doctorLogic.CreateDoctor(model).id;
                    if (_id != null) operationResult = true;
                }
                else
                {
                    operationResult = _doctorLogic.UpdateDoctor(model);
                }
                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        private double CalcPrice()
        {
            double price = 0;
            foreach (var elem in _doctorServices)
            {
                price += (elem.Price);
            }
            return price * 1.1;
        }
    }
}
