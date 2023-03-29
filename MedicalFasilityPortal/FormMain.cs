using Microsoft.Extensions.Logging;

namespace MedView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
      
        private void ComponentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormServices));
            if (service is FormServices form)
            {
                form.ShowDialog();
            }
        }
        private void DishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormJobs));
            if (service is FormJobs form)
            {
                form.ShowDialog();
            }
        }
    }
}