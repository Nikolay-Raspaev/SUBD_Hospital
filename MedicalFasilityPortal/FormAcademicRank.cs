using HospitalContracts.BindingModels;
using HospitalContracts.BuisnessLogicsContracts;
using HospitalContracts.SearchModels;

namespace HospitalView
{
    public partial class FormAcademicRank : Form
    {
        private readonly IAcademicRankLogic _perviceLogic;
        private int? _id;
        public int Id { set { _id = value; } }

        public FormAcademicRank(IAcademicRankLogic logic)
        {
            InitializeComponent();
            _perviceLogic = logic;
        }

        private void FormAcademicRank_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    var view = _perviceLogic.ReadElement(new AcademicRankSearchModel
                    {
                        Id = _id.Value,
                    });
                    if (view != null)
                    {
                        textBoxAcademicRankName.Text = view.AcademicRankName;
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
            if (string.IsNullOrEmpty(textBoxAcademicRankName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var model = new AcademicRankBindingModel
                {
                    Id = _id ?? 0,
                    AcademicRankName = textBoxAcademicRankName.Text,
                };
                var operationResult = _id.HasValue ? _perviceLogic.Update(model) : _perviceLogic.Create(model);
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