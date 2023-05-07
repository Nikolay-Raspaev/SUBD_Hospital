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
using Mongo.Contracts;
using Mongo.Database.Models;
using Mongo.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic.Logging;

namespace MongoForm
{
    public partial class FormJob : Form
    {
        private readonly IJobLogic _jobLogic;
        private int? _id;
        public int Id { set { _id = value; } }
        public FormJob(IJobLogic logic)
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
                    IJob view = _jobLogic.ReadElement(_id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.jobTitle;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (_id == null)
            {
                var res = _jobLogic.CreateJob(new Job
                {
                    id = _jobLogic.ReadList() != null ? _jobLogic.ReadList().Count + 1 : 1,
                    jobTitle = textBoxName.Text,
                });
                if (!res)
                {
                    MessageBox.Show("Произошла ошибка");
                    Close();
                }
                else 
                {
                    MessageBox.Show("Успешно");
                    Close();
                }         
            }
            else
            {
                var res = _jobLogic.UpdateJob(new Job
                {
                    id = _id.Value,
                    jobTitle = textBoxName.Text,
                });
                if (!res)
                {
                    MessageBox.Show("Произошла ошибка");
                    Close();
                }
                else
                {
                    MessageBox.Show("Успешно");
                    Close();
                }
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
