using Microsoft.Extensions.Logging;
using MedContracts.SearchModels;
using MedContracts.BindingModel;
using MedContracts.BuisnessLogic;

namespace MedView
{
    public partial class FormService : Form
    {
        private readonly IServiceLogic _serviceLogic;
        private int? _id;
        public int Id { set { _id = value; } }

        public FormService(IServiceLogic logic)
        {
            InitializeComponent();
            _serviceLogic = logic;
        }

        private void FormComponent_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    var view = _serviceLogic.ReadElement(new ServiceSearchModel
                    {
                        Id = _id.Value
                    });
                    if (view != null)
                    {
                        textBoxName.Text = view.ServicesName;
                        textBoxCost.Text = view.ServicesPrice.ToString();
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
                var model = new ServiceBindingModel
                {
                    Id = _id ?? 0,
                    ServicesName = textBoxName.Text,
                    ServicesPrice = Convert.ToDecimal(textBoxCost.Text)
                };
                var operationResult = _id.HasValue ? _serviceLogic.Update(model) : _serviceLogic.Create(model);
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