using Microsoft.Extensions.Logging;
using MedContracts.SearchModels;
using MedContracts.BindingModel;
using MedContracts.BuisnessLogics;
using BuisnessLogic;
using MedDataBaseImplement.Models;

namespace FoodOrdersView
{
    public partial class FormJobs : Form
    {
        private readonly IJobLogig _jobLogic;
        private int? _id;
        public int Id { set { _id = value; } }

        public List<Service> _services;

        public FormJobs(ILogger<FormJobs> logger, IJobLogig logic)
        {
            InitializeComponent();
            _jobLogic = logic;
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
                        _services = _jobLogic.ReadList();
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
                if (_dishComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var dc in _dishComponents)
                    {
                        dataGridView.Rows.Add(new object[] { dc.Key, dc.Value.Item1.ComponentName, dc.Value.Item2 });
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
            var service = Program.ServiceProvider?.GetService(typeof(FormJobComponents));
            if (service is FormJobComponents form)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.ComponentModel == null)
                    {
                        return;
                    }
                    if (_dishComponents.ContainsKey(form.Id))
                    {
                        _dishComponents[form.Id] = (form.ComponentModel, form.Count);
                    }
                    else
                    {
                        _dishComponents.Add(form.Id, (form.ComponentModel, form.Count));
                    }
                    LoadData();
                }
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormJobComponents));
                if (service is FormJobComponents form)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    form.Id = id;
                    form.Count = _dishComponents[id].Item2;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (form.ComponentModel == null)
                        {
                            return;
                        }
                        _dishComponents[form.Id] = (form.ComponentModel, form.Count);
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
                        _dishComponents?.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
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
            if (_dishComponents == null || _dishComponents.Count == 0)
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
                    JobName = textBoxName.Text,
                    Price = Convert.ToDouble(textBoxPrice.Text),
                    JobComponents = _dishComponents
                };
                var operationResult = _id.HasValue ? _logicD.Update(model) : _logicD.Create(model);
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
            double price = 0;
            foreach (var elem in _dishComponents)
            {
                price += ((elem.Value.Item1?.Cost ?? 0) * elem.Value.Item2);
            }
            return Math.Round(price * 1.1, 2);
        }
    }
}
