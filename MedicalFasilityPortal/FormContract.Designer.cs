namespace HospitalView
{
    partial class FormContract
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelBlankName = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDoctor = new System.Windows.Forms.ComboBox();
            this.comboBoxPatient = new System.Windows.Forms.ComboBox();
            this.comboBoxExecutionStatus = new System.Windows.Forms.ComboBox();
            this.comboBoxService = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(200, 331);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(82, 22);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click_1);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(112, 331);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(82, 22);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click_1);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(3, 118);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(31, 15);
            this.labelPrice.TabIndex = 7;
            this.labelPrice.Text = "Имя";
            // 
            // labelBlankName
            // 
            this.labelBlankName.AutoSize = true;
            this.labelBlankName.Location = new System.Drawing.Point(3, 91);
            this.labelBlankName.Name = "labelBlankName";
            this.labelBlankName.Size = new System.Drawing.Size(58, 15);
            this.labelBlankName.TabIndex = 6;
            this.labelBlankName.Text = "Фамилия";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(123, 63);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Дата";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Отчество";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Номер телефона";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Паспорт";
            // 
            // comboBoxDoctor
            // 
            this.comboBoxDoctor.FormattingEnabled = true;
            this.comboBoxDoctor.Location = new System.Drawing.Point(113, 145);
            this.comboBoxDoctor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxDoctor.Name = "comboBoxDoctor";
            this.comboBoxDoctor.Size = new System.Drawing.Size(282, 23);
            this.comboBoxDoctor.TabIndex = 21;
            // 
            // comboBoxPatient
            // 
            this.comboBoxPatient.FormattingEnabled = true;
            this.comboBoxPatient.Location = new System.Drawing.Point(112, 118);
            this.comboBoxPatient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPatient.Name = "comboBoxPatient";
            this.comboBoxPatient.Size = new System.Drawing.Size(282, 23);
            this.comboBoxPatient.TabIndex = 22;
            // 
            // comboBoxExecutionStatus
            // 
            this.comboBoxExecutionStatus.FormattingEnabled = true;
            this.comboBoxExecutionStatus.Location = new System.Drawing.Point(112, 91);
            this.comboBoxExecutionStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxExecutionStatus.Name = "comboBoxExecutionStatus";
            this.comboBoxExecutionStatus.Size = new System.Drawing.Size(282, 23);
            this.comboBoxExecutionStatus.TabIndex = 23;
            // 
            // comboBoxService
            // 
            this.comboBoxService.FormattingEnabled = true;
            this.comboBoxService.Location = new System.Drawing.Point(113, 172);
            this.comboBoxService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxService.Name = "comboBoxService";
            this.comboBoxService.Size = new System.Drawing.Size(282, 23);
            this.comboBoxService.TabIndex = 24;
            // 
            // FormContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 378);
            this.Controls.Add(this.comboBoxService);
            this.Controls.Add(this.comboBoxExecutionStatus);
            this.Controls.Add(this.comboBoxPatient);
            this.Controls.Add(this.comboBoxDoctor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelBlankName);
            this.Name = "FormContract";
            this.Text = "Блюдо";
            this.Load += new System.EventHandler(this.FormContract_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonCancel;
        private Button buttonSave;
        private Label labelPrice;
        private Label labelBlankName;
        private DateTimePicker dateTimePicker;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxDoctor;
        private ComboBox comboBoxPatient;
        private ComboBox comboBoxExecutionStatus;
        private ComboBox comboBoxService;
    }
}