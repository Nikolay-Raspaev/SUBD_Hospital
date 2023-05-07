namespace MongoForm
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
            buttonCancel = new Button();
            buttonSave = new Button();
            labelPrice = new Label();
            labelBlankName = new Label();
            dateTimePicker = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            comboBoxDoctor = new ComboBox();
            comboBoxPatient = new ComboBox();
            comboBoxService = new ComboBox();
            textBoxExecutionStatus = new TextBox();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(288, 161);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(82, 22);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click_1;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(200, 161);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(82, 22);
            buttonSave.TabIndex = 10;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click_1;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(13, 67);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(54, 15);
            labelPrice.TabIndex = 7;
            labelPrice.Text = "Пациент";
            // 
            // labelBlankName
            // 
            labelBlankName.AutoSize = true;
            labelBlankName.Location = new Point(13, 40);
            labelBlankName.Name = "labelBlankName";
            labelBlankName.Size = new Size(43, 15);
            labelBlankName.TabIndex = 6;
            labelBlankName.Text = "Статус";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(87, 12);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(283, 23);
            dateTimePicker.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 12);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 17;
            label1.Text = "Дата";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 94);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 18;
            label2.Text = "Доктор";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 121);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 20;
            label4.Text = "Услуга";
            // 
            // comboBoxDoctor
            // 
            comboBoxDoctor.FormattingEnabled = true;
            comboBoxDoctor.Location = new Point(88, 94);
            comboBoxDoctor.Margin = new Padding(3, 2, 3, 2);
            comboBoxDoctor.Name = "comboBoxDoctor";
            comboBoxDoctor.Size = new Size(282, 23);
            comboBoxDoctor.TabIndex = 21;
            // 
            // comboBoxPatient
            // 
            comboBoxPatient.FormattingEnabled = true;
            comboBoxPatient.Location = new Point(87, 67);
            comboBoxPatient.Margin = new Padding(3, 2, 3, 2);
            comboBoxPatient.Name = "comboBoxPatient";
            comboBoxPatient.Size = new Size(283, 23);
            comboBoxPatient.TabIndex = 22;
            // 
            // comboBoxService
            // 
            comboBoxService.FormattingEnabled = true;
            comboBoxService.Location = new Point(88, 121);
            comboBoxService.Margin = new Padding(3, 2, 3, 2);
            comboBoxService.Name = "comboBoxService";
            comboBoxService.Size = new Size(282, 23);
            comboBoxService.TabIndex = 24;
            // 
            // textBoxExecutionStatus
            // 
            textBoxExecutionStatus.Location = new Point(87, 40);
            textBoxExecutionStatus.Margin = new Padding(3, 2, 3, 2);
            textBoxExecutionStatus.Name = "textBoxExecutionStatus";
            textBoxExecutionStatus.Size = new Size(283, 23);
            textBoxExecutionStatus.TabIndex = 25;
            // 
            // FormContract
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 196);
            Controls.Add(textBoxExecutionStatus);
            Controls.Add(comboBoxService);
            Controls.Add(comboBoxPatient);
            Controls.Add(comboBoxDoctor);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(labelPrice);
            Controls.Add(labelBlankName);
            Name = "FormContract";
            Text = "Контракт";
            Load += FormContract_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCancel;
        private Button buttonSave;
        private Label labelPrice;
        private Label labelBlankName;
        private DateTimePicker dateTimePicker;
        private Label label1;
        private Label label2;
        private Label label4;
        private ComboBox comboBoxDoctor;
        private ComboBox comboBoxPatient;
        private ComboBox comboBoxService;
        private TextBox textBoxExecutionStatus;
    }
}