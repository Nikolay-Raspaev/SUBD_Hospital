using Mongo.Contracts;
using Mongo.Database.Models;
using Mongo.Models;
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
    public partial class FormDoctorServices : Form
    {
        private List<Service>? _list;

        public int doctorId { get; set; }
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
                    if (elem.id == Id)
                    {
                        return elem;
                    }
                }
                return null;
            }
        }
        private readonly IServiceLogic _serviceLogic;

        public FormDoctorServices(IServiceLogic logic)
        {
            InitializeComponent();
            _serviceLogic = logic;

        }
        private void FormDoctor_Load(object sender, EventArgs e)
        {
            
            try
            {
                _list = _serviceLogic.ReadList();
                if (_list != null)
                {
                    comboBoxComponent.DisplayMember = "Name";
                    comboBoxComponent.ValueMember = "id";
                    comboBoxComponent.DataSource = _list;
                    comboBoxComponent.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите Блюдо", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
