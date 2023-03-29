using Microsoft.Extensions.Logging;
using MedContracts.SearchModels;
using MedContracts.BindingModel;
using MedContracts.BuisnessLogics;

namespace MedView
{
    public partial class FormJob : Form
    {
        private readonly IJobLogig _jobLogic;
        private int? _id;
        public int Id { set { _id = value; } }

        public FormJob(IJobLogig logic)
        {
            InitializeComponent();
            _jobLogic = logic;
        }

        private void FormComponent_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    var view = _jobLogic.ReadElement(new JobSearchModel
                    {
                        Id = _id.Value
                    });
                    if (view != null)
                    {
                        textBoxName.Text = view.JobTitle;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var model = new JobBindingModel
                {
                    Id = _id ?? 0,
                    JobTitle = textBoxName.Text,
                };
                var operationResult = _id.HasValue ? _jobLogic.Update(model) : _jobLogic.Create(model);
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

    }
}