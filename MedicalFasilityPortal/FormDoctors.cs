﻿using HospitalContracts.BindingModels;
using HospitalBuisnessLogic.BuisnessLogicsContracts;
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
    public partial class FormDoctors : Form
    {
        private readonly IDoctorLogic _doctorLogic;
        public FormDoctors(IDoctorLogic logic)
        {
            InitializeComponent();
            _doctorLogic = logic;
        }

        private void FormDocuments_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = _doctorLogic.ReadList(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns["Id"].Visible = false;
                    dataGridView.Columns["Passport"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns["Education"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns["DoctorServices"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormDoctor));
            if (service is FormDoctor form)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormDoctor));
                if (service is FormDoctor form)
                {
                    form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                    try
                    {
                        if (!_doctorLogic.Delete(new DoctorBindingModel
                        {
                            Id = id
                        }))
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

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
