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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.AcademicRanksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContractsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoctorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExecutionStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Job = new System.Windows.Forms.ToolStripMenuItem();
            this.PatientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.рандомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AcademicRanksToolStripMenuItem,
            this.ContractsToolStripMenuItem,
            this.DoctorsToolStripMenuItem,
            this.ExecutionStatusToolStripMenuItem,
            this.Job,
            this.PatientsToolStripMenuItem,
            this.ServicesToolStripMenuItem,
            this.рандомToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(975, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // AcademicRanksToolStripMenuItem
            // 
            this.AcademicRanksToolStripMenuItem.Name = "AcademicRanksToolStripMenuItem";
            this.AcademicRanksToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.AcademicRanksToolStripMenuItem.Text = "Учёная степень";
            this.AcademicRanksToolStripMenuItem.Click += new System.EventHandler(this.AcademicRanksToolStripMenuItem_Click);
            // 
            // ContractsToolStripMenuItem
            // 
            this.ContractsToolStripMenuItem.Name = "ContractsToolStripMenuItem";
            this.ContractsToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.ContractsToolStripMenuItem.Text = "Контракты";
            this.ContractsToolStripMenuItem.Click += new System.EventHandler(this.ContractsToolStripMenuItem_Click);
            // 
            // DoctorsToolStripMenuItem
            // 
            this.DoctorsToolStripMenuItem.Name = "DoctorsToolStripMenuItem";
            this.DoctorsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.DoctorsToolStripMenuItem.Text = "Доктора";
            this.DoctorsToolStripMenuItem.Click += new System.EventHandler(this.DoctorsToolStripMenuItem_Click);
            // 
            // ExecutionStatusToolStripMenuItem
            // 
            this.ExecutionStatusToolStripMenuItem.Name = "ExecutionStatusToolStripMenuItem";
            this.ExecutionStatusToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.ExecutionStatusToolStripMenuItem.Text = "Статус контракта";
            this.ExecutionStatusToolStripMenuItem.Click += new System.EventHandler(this.ExecutionStatusToolStripMenuItem_Click);
            // 
            // Job
            // 
            this.Job.Name = "Job";
            this.Job.Size = new System.Drawing.Size(83, 20);
            this.Job.Text = "Профессии";
            this.Job.Click += new System.EventHandler(this.Job_Click);
            // 
            // PatientsToolStripMenuItem
            // 
            this.PatientsToolStripMenuItem.Name = "PatientsToolStripMenuItem";
            this.PatientsToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.PatientsToolStripMenuItem.Text = "Пациенты";
            this.PatientsToolStripMenuItem.Click += new System.EventHandler(this.PatientsToolStripMenuItem_Click);
            // 
            // ServicesToolStripMenuItem
            // 
            this.ServicesToolStripMenuItem.Name = "ServicesToolStripMenuItem";
            this.ServicesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.ServicesToolStripMenuItem.Text = "Услуги";
            this.ServicesToolStripMenuItem.Click += new System.EventHandler(this.ServicesToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView.Location = new System.Drawing.Point(0, 24);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(975, 426);
            this.dataGridView.TabIndex = 7;
            // 
            // рандомToolStripMenuItem
            // 
            this.рандомToolStripMenuItem.Name = "рандомToolStripMenuItem";
            this.рандомToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.рандомToolStripMenuItem.Text = "Рандом";
            this.рандомToolStripMenuItem.Click += new System.EventHandler(this.рандомToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Портал медицинского учреждения";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}