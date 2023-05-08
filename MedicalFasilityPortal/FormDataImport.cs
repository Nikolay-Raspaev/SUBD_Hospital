using HospitalBuisnessLogic.BuisnessLogic;
using HospitalBuisnessLogic.BuisnessLogicsContracts;
using HospitalContracts.BindingModels;
using HospitalDataImport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace HospitalView
{
    public partial class FormDataImport : Form
    {
        private readonly IDataImport _dataImport;
        public FormDataImport(IDataImport dataImport)
        {
            InitializeComponent();
            _dataImport = dataImport;
        }

        private void buttonService_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _dataImport.DataImportService();
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            string elapsedTime4 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
            label.Text = ("RunTime " + elapsedTime4);
        }

        private void buttonJob_Click(object sender, EventArgs e)
        {          
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            _dataImport.DataImportJob();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
            label.Text = ("RunTime " + elapsedTime);
        }

        private void buttonContract_Click(object sender, EventArgs e)
        {           
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            _dataImport.DataImportContract();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
            label.Text = ("RunTime " + elapsedTime);
        }

        private void buttonPatient_Click(object sender, EventArgs e)
        {         
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            _dataImport.DataImportPatient();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
            label.Text = ("RunTime " + elapsedTime);
        }

        private void buttonDoctor_Click(object sender, EventArgs e)
        {         
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            _dataImport.DataImportDoctor();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
            label.Text = ("RunTime " + elapsedTime);
        }
    }
}
