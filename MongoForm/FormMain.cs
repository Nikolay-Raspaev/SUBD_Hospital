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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        private void ContractsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormContracts));
            if (service is FormContracts form)
            {
                form.ShowDialog();
            }
        }

        private void DoctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormDoctors));
            if (service is FormDoctors form)
            {
                form.ShowDialog();
            }
        }

        private void Job_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormJobs));
            if (service is FormJobs form)
            {
                form.ShowDialog();
            }
        }

        private void PatientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormPatients));
            if (service is FormPatients form)
            {
                form.ShowDialog();
            }
        }

        private void ServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormServices));
            if (service is FormServices form)
            {
                form.ShowDialog();
            }
        }
    }
}
