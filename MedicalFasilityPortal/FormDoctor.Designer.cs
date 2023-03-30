namespace HospitalView
{
    partial class FormDoctor
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
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxEducation = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelEducation = new System.Windows.Forms.Label();
            this.groupBoxComponents = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComponentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.textBoxPassport = new System.Windows.Forms.TextBox();
            this.textBoxTelephoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxPatronymic = new System.Windows.Forms.TextBox();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelBlankName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxJob = new System.Windows.Forms.ComboBox();
            this.comboBoxAcademicRank = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBoxComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(154, 360);
            this.textBoxPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.ReadOnly = true;
            this.textBoxPrice.Size = new System.Drawing.Size(138, 23);
            this.textBoxPrice.TabIndex = 7;
            // 
            // textBoxEducation
            // 
            this.textBoxEducation.Location = new System.Drawing.Point(153, 54);
            this.textBoxEducation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEducation.Name = "textBoxEducation";
            this.textBoxEducation.Size = new System.Drawing.Size(282, 23);
            this.textBoxEducation.TabIndex = 6;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(-98, 337);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(70, 15);
            this.labelPrice.TabIndex = 5;
            this.labelPrice.Text = "Стоимость:";
            // 
            // labelEducation
            // 
            this.labelEducation.AutoSize = true;
            this.labelEducation.Location = new System.Drawing.Point(63, 54);
            this.labelEducation.Name = "labelEducation";
            this.labelEducation.Size = new System.Drawing.Size(80, 15);
            this.labelEducation.TabIndex = 4;
            this.labelEducation.Text = "Образование";
            // 
            // groupBoxComponents
            // 
            this.groupBoxComponents.Controls.Add(this.buttonCancel);
            this.groupBoxComponents.Controls.Add(this.dataGridView);
            this.groupBoxComponents.Controls.Add(this.buttonAdd);
            this.groupBoxComponents.Controls.Add(this.buttonSave);
            this.groupBoxComponents.Controls.Add(this.buttonEdit);
            this.groupBoxComponents.Controls.Add(this.buttonDelete);
            this.groupBoxComponents.Controls.Add(this.buttonUpdate);
            this.groupBoxComponents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxComponents.Location = new System.Drawing.Point(0, 387);
            this.groupBoxComponents.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxComponents.Name = "groupBoxComponents";
            this.groupBoxComponents.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxComponents.Size = new System.Drawing.Size(599, 206);
            this.groupBoxComponents.TabIndex = 8;
            this.groupBoxComponents.TabStop = false;
            this.groupBoxComponents.Text = "Услуги предоставляемые специалистом";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(505, 176);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(79, 22);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ColumnComponentName,
            this.ColumnCount});
            this.dataGridView.Location = new System.Drawing.Point(5, 20);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(494, 182);
            this.dataGridView.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // ColumnComponentName
            // 
            this.ColumnComponentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnComponentName.HeaderText = "Услуга";
            this.ColumnComponentName.MinimumWidth = 6;
            this.ColumnComponentName.Name = "ColumnComponentName";
            this.ColumnComponentName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnComponentName.Width = 312;
            // 
            // ColumnCount
            // 
            this.ColumnCount.HeaderText = "Цена";
            this.ColumnCount.MinimumWidth = 6;
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.Width = 125;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(505, 20);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(79, 22);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(505, 150);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(79, 22);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(505, 46);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(79, 22);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Изменить";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.ButtonUpd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(505, 72);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(79, 22);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDel_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(505, 98);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(79, 22);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(154, 19);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker.TabIndex = 22;
            // 
            // textBoxPassport
            // 
            this.textBoxPassport.Location = new System.Drawing.Point(153, 281);
            this.textBoxPassport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPassport.Name = "textBoxPassport";
            this.textBoxPassport.Size = new System.Drawing.Size(282, 23);
            this.textBoxPassport.TabIndex = 21;
            // 
            // textBoxTelephoneNumber
            // 
            this.textBoxTelephoneNumber.Location = new System.Drawing.Point(153, 319);
            this.textBoxTelephoneNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTelephoneNumber.Name = "textBoxTelephoneNumber";
            this.textBoxTelephoneNumber.Size = new System.Drawing.Size(282, 23);
            this.textBoxTelephoneNumber.TabIndex = 20;
            // 
            // textBoxPatronymic
            // 
            this.textBoxPatronymic.Location = new System.Drawing.Point(153, 243);
            this.textBoxPatronymic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPatronymic.Name = "textBoxPatronymic";
            this.textBoxPatronymic.Size = new System.Drawing.Size(282, 23);
            this.textBoxPatronymic.TabIndex = 19;
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(153, 166);
            this.textBoxSurname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(282, 23);
            this.textBoxSurname.TabIndex = 18;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(153, 204);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(282, 23);
            this.textBoxName.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "Паспорт";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "Номер телефона";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "Отчество";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Дата оказания услуги";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "Имя";
            // 
            // labelBlankName
            // 
            this.labelBlankName.AutoSize = true;
            this.labelBlankName.Location = new System.Drawing.Point(85, 169);
            this.labelBlankName.Name = "labelBlankName";
            this.labelBlankName.Size = new System.Drawing.Size(58, 15);
            this.labelBlankName.TabIndex = 23;
            this.labelBlankName.Text = "Фамилия";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 30;
            this.label6.Text = "Профессия";
            // 
            // comboBoxJob
            // 
            this.comboBoxJob.FormattingEnabled = true;
            this.comboBoxJob.Location = new System.Drawing.Point(153, 91);
            this.comboBoxJob.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxJob.Name = "comboBoxJob";
            this.comboBoxJob.Size = new System.Drawing.Size(282, 23);
            this.comboBoxJob.TabIndex = 31;
            // 
            // comboBoxAcademicRank
            // 
            this.comboBoxAcademicRank.FormattingEnabled = true;
            this.comboBoxAcademicRank.Location = new System.Drawing.Point(153, 127);
            this.comboBoxAcademicRank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxAcademicRank.Name = "comboBoxAcademicRank";
            this.comboBoxAcademicRank.Size = new System.Drawing.Size(282, 23);
            this.comboBoxAcademicRank.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 15);
            this.label7.TabIndex = 33;
            this.label7.Text = "Учёная степень";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 360);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 15);
            this.label8.TabIndex = 34;
            this.label8.Text = "Стоимость всех услуг:";
            // 
            // FormDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 593);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxAcademicRank);
            this.Controls.Add(this.comboBoxJob);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelBlankName);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.textBoxPassport);
            this.Controls.Add(this.textBoxTelephoneNumber);
            this.Controls.Add(this.textBoxPatronymic);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.groupBoxComponents);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxEducation);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelEducation);
            this.Name = "FormDoctor";
            this.Text = "Доктор";
            this.Load += new System.EventHandler(this.FormDoctor_Load);
            this.groupBoxComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxPrice;
        private TextBox textBoxEducation;
        private Label labelPrice;
        private Label labelEducation;
        private GroupBox groupBoxComponents;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonEdit;
        private Button buttonAdd;
        private DataGridView dataGridView;
        private Button buttonCancel;
        private Button buttonSave;
        private DateTimePicker dateTimePicker;
        private TextBox textBoxPassport;
        private TextBox textBoxTelephoneNumber;
        private TextBox textBoxPatronymic;
        private TextBox textBoxSurname;
        private TextBox textBoxName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label labelBlankName;
        private Label label6;
        private ComboBox comboBoxJob;
        private ComboBox comboBoxAcademicRank;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ColumnComponentName;
        private DataGridViewTextBoxColumn ColumnCount;
        private Label label7;
        private Label label8;
    }
}