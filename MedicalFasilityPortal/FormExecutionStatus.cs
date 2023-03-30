using HospitalContracts.BindingModels;
using HospitalContracts.BuisnessLogicsContracts;
using HospitalContracts.SearchModels;
using System;
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
    public partial class FormExecutionStatus : Form
    {
        private readonly IExecutionStatusLogic _executionStatusLogic;
        private int? _id;
        public int Id { set { _id = value; } }

        public FormExecutionStatus(IExecutionStatusLogic logic)
        {
            InitializeComponent();
            _executionStatusLogic = logic;
        }

        private void FormExecutionStatus_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    var view = _executionStatusLogic.ReadElement(new ExecutionStatusSearchModel
                    {
                        Id = _id.Value,
                    });
                    if (view != null)
                    {
                        textBoxStatus.Text = view.ExecutionStatusName;
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
            if (string.IsNullOrEmpty(textBoxStatus.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var model = new ExecutionStatusBindingModel
                {
                    Id = _id ?? 0,
                    ExecutionStatusName = textBoxStatus.Text,
                };
                var operationResult = _id.HasValue ? _executionStatusLogic.Update(model) : _executionStatusLogic.Create(model);
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
