namespace HospitalView
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer Components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (Components != null))
            {
                Components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            AcademicRanksToolStripMenuItem = new ToolStripMenuItem();
            ContractsToolStripMenuItem = new ToolStripMenuItem();
            DoctorsToolStripMenuItem = new ToolStripMenuItem();
            ExecutionStatusToolStripMenuItem = new ToolStripMenuItem();
            Job = new ToolStripMenuItem();
            PatientsToolStripMenuItem = new ToolStripMenuItem();
            ServicesToolStripMenuItem = new ToolStripMenuItem();
            рандомToolStripMenuItem = new ToolStripMenuItem();
            dataGridView = new DataGridView();
            монгоToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { AcademicRanksToolStripMenuItem, ContractsToolStripMenuItem, DoctorsToolStripMenuItem, ExecutionStatusToolStripMenuItem, Job, PatientsToolStripMenuItem, ServicesToolStripMenuItem, рандомToolStripMenuItem, монгоToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(975, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // AcademicRanksToolStripMenuItem
            // 
            AcademicRanksToolStripMenuItem.Name = "AcademicRanksToolStripMenuItem";
            AcademicRanksToolStripMenuItem.Size = new Size(104, 20);
            AcademicRanksToolStripMenuItem.Text = "Учёная степень";
            AcademicRanksToolStripMenuItem.Click += AcademicRanksToolStripMenuItem_Click;
            // 
            // ContractsToolStripMenuItem
            // 
            ContractsToolStripMenuItem.Name = "ContractsToolStripMenuItem";
            ContractsToolStripMenuItem.Size = new Size(78, 20);
            ContractsToolStripMenuItem.Text = "Контракты";
            ContractsToolStripMenuItem.Click += ContractsToolStripMenuItem_Click;
            // 
            // DoctorsToolStripMenuItem
            // 
            DoctorsToolStripMenuItem.Name = "DoctorsToolStripMenuItem";
            DoctorsToolStripMenuItem.Size = new Size(65, 20);
            DoctorsToolStripMenuItem.Text = "Доктора";
            DoctorsToolStripMenuItem.Click += DoctorsToolStripMenuItem_Click;
            // 
            // ExecutionStatusToolStripMenuItem
            // 
            ExecutionStatusToolStripMenuItem.Name = "ExecutionStatusToolStripMenuItem";
            ExecutionStatusToolStripMenuItem.Size = new Size(113, 20);
            ExecutionStatusToolStripMenuItem.Text = "Статус контракта";
            ExecutionStatusToolStripMenuItem.Click += ExecutionStatusToolStripMenuItem_Click;
            // 
            // Job
            // 
            Job.Name = "Job";
            Job.Size = new Size(83, 20);
            Job.Text = "Профессии";
            Job.Click += Job_Click;
            // 
            // PatientsToolStripMenuItem
            // 
            PatientsToolStripMenuItem.Name = "PatientsToolStripMenuItem";
            PatientsToolStripMenuItem.Size = new Size(75, 20);
            PatientsToolStripMenuItem.Text = "Пациенты";
            PatientsToolStripMenuItem.Click += PatientsToolStripMenuItem_Click;
            // 
            // ServicesToolStripMenuItem
            // 
            ServicesToolStripMenuItem.Name = "ServicesToolStripMenuItem";
            ServicesToolStripMenuItem.Size = new Size(57, 20);
            ServicesToolStripMenuItem.Text = "Услуги";
            ServicesToolStripMenuItem.Click += ServicesToolStripMenuItem_Click;
            // 
            // рандомToolStripMenuItem
            // 
            рандомToolStripMenuItem.Name = "рандомToolStripMenuItem";
            рандомToolStripMenuItem.Size = new Size(61, 20);
            рандомToolStripMenuItem.Text = "Рандом";
            рандомToolStripMenuItem.Click += рандомToolStripMenuItem_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Left;
            dataGridView.Location = new Point(0, 24);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(975, 426);
            dataGridView.TabIndex = 7;
            // 
            // монгоToolStripMenuItem
            // 
            монгоToolStripMenuItem.Name = "монгоToolStripMenuItem";
            монгоToolStripMenuItem.Size = new Size(56, 20);
            монгоToolStripMenuItem.Text = "Монго";
            монгоToolStripMenuItem.Click += монгоToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 450);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "FormMain";
            Text = "Портал медицинского учреждения";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem PatientsToolStripMenuItem;
        private DataGridView dataGridView;
        private ToolStripMenuItem AcademicRanksToolStripMenuItem;
        private ToolStripMenuItem ContractsToolStripMenuItem;
        private ToolStripMenuItem DoctorsToolStripMenuItem;
        private ToolStripMenuItem ExecutionStatusToolStripMenuItem;
        private ToolStripMenuItem Job;
        private ToolStripMenuItem ServicesToolStripMenuItem;
        private ToolStripMenuItem рандомToolStripMenuItem;
        private ToolStripMenuItem монгоToolStripMenuItem;
    }
}