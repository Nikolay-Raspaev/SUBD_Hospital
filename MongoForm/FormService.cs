using Mongo.Contracts;
using Mongo.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoForm
{
    public partial class FormService : Form
    {
        private readonly IMongoServiceLogic _perviceLogic;
        private int? _id;
        public int Id { set { _id = value; } }

        public FormService(IMongoServiceLogic logic)
        {
            InitializeComponent();
            _perviceLogic = logic;
        }

        private void FormService_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    var view = _perviceLogic.ReadElement(_id.Value);
                    if (view != null)
                    {
                        textBoxServiceName.Text = view.Name;
                        textBoxServicePrice.Text = view.Price.ToString();
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
            if (string.IsNullOrEmpty(textBoxServiceName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var model = new Service
                {
                    id = _id ?? 0,
                    Name = textBoxServiceName.Text,
                    Price = Convert.ToDouble(textBoxServicePrice.Text)
                };
                var operationResult = _id.HasValue ? _perviceLogic.UpdateService(model) : _perviceLogic.CreateService(model);
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
