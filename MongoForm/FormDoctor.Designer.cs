namespace MongoForm
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
            textBoxPrice = new TextBox();
            textBoxEducation = new TextBox();
            labelPrice = new Label();
            labelEducation = new Label();
            groupBoxComponents = new GroupBox();
            buttonCancel = new Button();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            ColumnComponentName = new DataGridViewTextBoxColumn();
            ColumnCount = new DataGridViewTextBoxColumn();
            buttonAdd = new Button();
            buttonSave = new Button();
            buttonDelete = new Button();
            buttonUpdate = new Button();
            dateTimePicker = new DateTimePicker();
            textBoxPassport = new TextBox();
            textBoxTelephoneNumber = new TextBox();
            textBoxPatronymic = new TextBox();
            textBoxSurname = new TextBox();
            textBoxName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            labelBlankName = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            textBoxAcademicRank = new TextBox();
            textBoxJob = new TextBox();
            groupBoxComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(154, 360);
            textBoxPrice.Margin = new Padding(3, 2, 3, 2);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.ReadOnly = true;
            textBoxPrice.Size = new Size(138, 23);
            textBoxPrice.TabIndex = 7;
            // 
            // textBoxEducation
            // 
            textBoxEducation.Location = new Point(153, 54);
            textBoxEducation.Margin = new Padding(3, 2, 3, 2);
            textBoxEducation.Name = "textBoxEducation";
            textBoxEducation.Size = new Size(282, 23);
            textBoxEducation.TabIndex = 6;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(-98, 337);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(70, 15);
            labelPrice.TabIndex = 5;
            labelPrice.Text = "Стоимость:";
            // 
            // labelEducation
            // 
            labelEducation.AutoSize = true;
            labelEducation.Location = new Point(63, 54);
            labelEducation.Name = "labelEducation";
            labelEducation.Size = new Size(80, 15);
            labelEducation.TabIndex = 4;
            labelEducation.Text = "Образование";
            // 
            // groupBoxComponents
            // 
            groupBoxComponents.Controls.Add(buttonCancel);
            groupBoxComponents.Controls.Add(dataGridView);
            groupBoxComponents.Controls.Add(buttonAdd);
            groupBoxComponents.Controls.Add(buttonSave);
            groupBoxComponents.Controls.Add(buttonDelete);
            groupBoxComponents.Controls.Add(buttonUpdate);
            groupBoxComponents.Dock = DockStyle.Bottom;
            groupBoxComponents.Location = new Point(0, 387);
            groupBoxComponents.Margin = new Padding(3, 2, 3, 2);
            groupBoxComponents.Name = "groupBoxComponents";
            groupBoxComponents.Padding = new Padding(3, 2, 3, 2);
            groupBoxComponents.Size = new Size(599, 206);
            groupBoxComponents.TabIndex = 8;
            groupBoxComponents.TabStop = false;
            groupBoxComponents.Text = "Услуги предоставляемые специалистом";
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(505, 176);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(79, 22);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, ColumnComponentName, ColumnCount });
            dataGridView.Location = new Point(5, 20);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(494, 182);
            dataGridView.TabIndex = 0;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.Visible = false;
            ID.Width = 125;
            // 
            // ColumnComponentName
            // 
            ColumnComponentName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColumnComponentName.HeaderText = "Услуга";
            ColumnComponentName.MinimumWidth = 6;
            ColumnComponentName.Name = "ColumnComponentName";
            ColumnComponentName.Resizable = DataGridViewTriState.True;
            ColumnComponentName.Width = 312;
            // 
            // ColumnCount
            // 
            ColumnCount.HeaderText = "Цена";
            ColumnCount.MinimumWidth = 6;
            ColumnCount.Name = "ColumnCount";
            ColumnCount.Width = 125;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(505, 20);
            buttonAdd.Margin = new Padding(3, 2, 3, 2);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(79, 22);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += ButtonAdd_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(505, 137);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(79, 22);
            buttonSave.TabIndex = 5;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(505, 61);
            buttonDelete.Margin = new Padding(3, 2, 3, 2);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(79, 22);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += ButtonDel_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(505, 98);
            buttonUpdate.Margin = new Padding(3, 2, 3, 2);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(79, 22);
            buttonUpdate.TabIndex = 4;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += ButtonRef_Click;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(154, 19);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(200, 23);
            dateTimePicker.TabIndex = 22;
            // 
            // textBoxPassport
            // 
            textBoxPassport.Location = new Point(153, 281);
            textBoxPassport.Margin = new Padding(3, 2, 3, 2);
            textBoxPassport.Name = "textBoxPassport";
            textBoxPassport.Size = new Size(282, 23);
            textBoxPassport.TabIndex = 21;
            // 
            // textBoxTelephoneNumber
            // 
            textBoxTelephoneNumber.Location = new Point(153, 319);
            textBoxTelephoneNumber.Margin = new Padding(3, 2, 3, 2);
            textBoxTelephoneNumber.Name = "textBoxTelephoneNumber";
            textBoxTelephoneNumber.Size = new Size(282, 23);
            textBoxTelephoneNumber.TabIndex = 20;
            // 
            // textBoxPatronymic
            // 
            textBoxPatronymic.Location = new Point(153, 243);
            textBoxPatronymic.Margin = new Padding(3, 2, 3, 2);
            textBoxPatronymic.Name = "textBoxPatronymic";
            textBoxPatronymic.Size = new Size(282, 23);
            textBoxPatronymic.TabIndex = 19;
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new Point(153, 166);
            textBoxSurname.Margin = new Padding(3, 2, 3, 2);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(282, 23);
            textBoxSurname.TabIndex = 18;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(153, 204);
            textBoxName.Margin = new Padding(3, 2, 3, 2);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(282, 23);
            textBoxName.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(89, 281);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 28;
            label4.Text = "Паспорт";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 319);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 27;
            label3.Text = "Номер телефона";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 243);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 26;
            label2.Text = "Отчество";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 19);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 25;
            label1.Text = "Дата оказания услуги";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(112, 204);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 24;
            label5.Text = "Имя";
            // 
            // labelBlankName
            // 
            labelBlankName.AutoSize = true;
            labelBlankName.Location = new Point(85, 169);
            labelBlankName.Name = "labelBlankName";
            labelBlankName.Size = new Size(58, 15);
            labelBlankName.TabIndex = 23;
            labelBlankName.Text = "Фамилия";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(73, 91);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 30;
            label6.Text = "Профессия";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(51, 127);
            label7.Name = "label7";
            label7.Size = new Size(92, 15);
            label7.TabIndex = 33;
            label7.Text = "Учёная степень";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(13, 360);
            label8.Name = "label8";
            label8.Size = new Size(130, 15);
            label8.TabIndex = 34;
            label8.Text = "Стоимость всех услуг:";
            // 
            // textBoxAcademicRank
            // 
            textBoxAcademicRank.Location = new Point(154, 127);
            textBoxAcademicRank.Margin = new Padding(3, 2, 3, 2);
            textBoxAcademicRank.Name = "textBoxAcademicRank";
            textBoxAcademicRank.Size = new Size(282, 23);
            textBoxAcademicRank.TabIndex = 35;
            // 
            // textBoxJob
            // 
            textBoxJob.Location = new Point(154, 91);
            textBoxJob.Margin = new Padding(3, 2, 3, 2);
            textBoxJob.Name = "textBoxJob";
            textBoxJob.Size = new Size(282, 23);
            textBoxJob.TabIndex = 36;
            // 
            // FormDoctor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 593);
            Controls.Add(textBoxJob);
            Controls.Add(textBoxAcademicRank);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(labelBlankName);
            Controls.Add(dateTimePicker);
            Controls.Add(textBoxPassport);
            Controls.Add(textBoxTelephoneNumber);
            Controls.Add(textBoxPatronymic);
            Controls.Add(textBoxSurname);
            Controls.Add(textBoxName);
            Controls.Add(groupBoxComponents);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxEducation);
            Controls.Add(labelPrice);
            Controls.Add(labelEducation);
            Name = "FormDoctor";
            Text = "Доктор";
            Load += FormDoctor_Load;
            groupBoxComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxPrice;
        private TextBox textBoxEducation;
        private Label labelPrice;
        private Label labelEducation;
        private GroupBox groupBoxComponents;
        private Button buttonUpdate;
        private Button buttonDelete;
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
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ColumnComponentName;
        private DataGridViewTextBoxColumn ColumnCount;
        private Label label7;
        private Label label8;
        private TextBox textBoxAcademicRank;
        private TextBox textBoxJob;
    }
}