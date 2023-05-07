using Mongo.Contracts;
using Mongo.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoForm
{
    public partial class FormContracts : Form
    {
        private readonly IContractLogic _ContractLogic;
        public FormContracts(IContractLogic logic)
        {
            InitializeComponent();
            _ContractLogic = logic;
        }
        private void FormContracts_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = _ContractLogic.ReadList();
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns["Id"].Visible = false;
                    dataGridView.Columns["Patient"].Visible = false;
                    dataGridView.Columns["Doctor"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormContract));
            if (service is FormContract form)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormContract));
                if (service is FormContract form)
                {
                    form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                    try
                    {
                        if (!_ContractLogic.DeleteContract(new Contract { id = id }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonGetReport_Click(object sender, EventArgs e)
        {
            var list = _ContractLogic.ReadList();
            double sum = 0;
            foreach (var contract in list)
            {
                foreach (var service in contract.Doctor.DoctorServices) 
                {
                    if (service.id == contract.ServiceId)
                    {
                        sum += service.Price;
                    }
                }
            }
            textBoxSum.Text = sum.ToString();
        }
    }
}
