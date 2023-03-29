using HospitalContracts.BuisnessLogicsContracts;
using HospitalContracts.ViewModels;
using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalView
{
    public partial class FormJobServices : Form
    {
        private readonly List<ServiceViewModel>? _list;
        public int Id
        {
            get
            {
                return Convert.ToInt32(comboBoxComponent.SelectedValue);
            }
            set
            {
                comboBoxComponent.SelectedValue = value;
            }
        }
        public IService? ServiceModel
        {
            get
            {
                if (_list == null)
                {
                    return null;
                }
                foreach (var elem in _list)
                {
                    if (elem.Id == Id)
                    {
                        return elem;
                    }
                }
                return null;
            }
        }

        public FormJobServices(IServiceLogic logic)
        {
            InitializeComponent();
            _list = logic.ReadList(null);
            if (_list != null)
            {
                comboBoxComponent.DisplayMember = "ServiceName";
                comboBoxComponent.ValueMember = "Id";
                comboBoxComponent.DataSource = _list;
                comboBoxComponent.SelectedItem = null;
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите Блюдо", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
