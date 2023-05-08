using HospitalBuisnessLogic.BuisnessLogicsContracts;
using HospitalDataImport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            _dataImport.DataImportService();
        }

        private void buttonJob_Click(object sender, EventArgs e)
        {
            _dataImport.DataImportJob();
        }

        private void buttonContract_Click(object sender, EventArgs e)
        {
            _dataImport.DataImportContract();
        }

        private void buttonPatient_Click(object sender, EventArgs e)
        {
            _dataImport.DataImportPatient();
        }

        private void buttonDoctor_Click(object sender, EventArgs e)
        {
            _dataImport.DataImportDoctor();
        }
    }
}
