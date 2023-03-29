using HospitalContracts.BuisnessLogicsContracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalDataModels.Models;
using HospitalContracts.SearchModels;
using HospitalContracts.BindingModels;

namespace HospitalView
{
    public partial class FormJob : Form
    {
        private readonly IJobLogic _jobLogic;
        private int? _id;
        private Dictionary<int, IService> _jobServices;
        public int Id { set { _id = value; } }
        public FormJob(IJobLogic logic)
        {
            InitializeComponent();
            _jobLogic = logic;
            _jobServices = new Dictionary<int, IService>();
        }
        private void FormJob_Load(object sender, EventArgs e)
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
                        //если не null то слева, если null то справа
                        _jobServices = view.JobServices ?? new Dictionary<int, IService>();
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
                if (_jobServices != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var dc in _jobServices)
                    {
                        dataGridView.Rows.Add(new object[] { dc.Key, dc.Value.ServiceName, dc.Value.ServicePrice });
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
            var service = Program.ServiceProvider?.GetService(typeof(FormJobServices));
            if (service is FormJobServices form)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.ServiceModel == null)
                    {
                        return;
                    }
                    if (_jobServices.ContainsKey(form.Id))
                    {
                        _jobServices[form.Id] = (form.ServiceModel, form.Count);
                    }
                    else
                    {
                        _jobServices.Add(form.Id, (form.ServiceModel, form.Count));
                    }
                    LoadData();
                }
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormJobServices));
                if (service is FormJobServices form)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    form.Id = id;
                    form.Count = _jobServices[id].Item2;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (form.ServiceModel == null)
                        {
                            return;
                        }
                        _jobServices[form.Id] = (form.ServiceModel, form.Count);
                        LoadData();
                    }
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
                        _jobServices?.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
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
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (_jobServices == null || _jobServices.Count == 0)
            {
                MessageBox.Show("Заполните Блюда", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var model = new JobBindingModel
                {
                    Id = _id ?? 0,
                    JobTitle = textBoxName.Text,
                    JobServices = _jobServices
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
        private double CalcPrice()
        {
            decimal price = 0;
            decimal 
            foreach (var elem in _jobServices)
            {
                price += (elem.Value.ServicePrice);
            }
            return Decimal.Multiply(price, 1,1);
        }
    }
}
