namespace HospitalView
{
    partial class FormContracts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonEdit = new Button();
            buttonAdd = new Button();
            dataGridView = new DataGridView();
            buttonGetReport = new Button();
            textBoxSum = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(998, 89);
            buttonUpdate.Margin = new Padding(3, 2, 3, 2);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(130, 22);
            buttonUpdate.TabIndex = 9;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(998, 63);
            buttonDelete.Margin = new Padding(3, 2, 3, 2);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(130, 22);
            buttonDelete.TabIndex = 8;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(998, 37);
            buttonEdit.Margin = new Padding(3, 2, 3, 2);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(130, 22);
            buttonEdit.TabIndex = 7;
            buttonEdit.Text = "Изменить";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(998, 11);
            buttonAdd.Margin = new Padding(3, 2, 3, 2);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(130, 22);
            buttonAdd.TabIndex = 6;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click_1;
            // 
            // dataGridView
            // 
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Left;
            dataGridView.GridColor = Color.White;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(969, 431);
            dataGridView.TabIndex = 5;
            // 
            // buttonGetReport
            // 
            buttonGetReport.Location = new Point(998, 115);
            buttonGetReport.Margin = new Padding(3, 2, 3, 2);
            buttonGetReport.Name = "buttonGetReport";
            buttonGetReport.Size = new Size(130, 22);
            buttonGetReport.TabIndex = 10;
            buttonGetReport.Text = "Получить отчёт";
            buttonGetReport.UseVisualStyleBackColor = true;
            buttonGetReport.Click += buttonGetReport_Click;
            // 
            // textBoxSum
            // 
            textBoxSum.Location = new Point(998, 141);
            textBoxSum.Margin = new Padding(3, 2, 3, 2);
            textBoxSum.Name = "textBoxSum";
            textBoxSum.ReadOnly = true;
            textBoxSum.Size = new Size(130, 23);
            textBoxSum.TabIndex = 11;
            // 
            // FormContracts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 431);
            Controls.Add(textBoxSum);
            Controls.Add(buttonGetReport);
            Controls.Add(dataGridView);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(buttonAdd);
            Name = "FormContracts";
            Text = "Контракты";
            Load += FormContracts_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonEdit;
        private Button buttonAdd;
        private DataGridView dataGridView;
        private Button buttonGetReport;
        private TextBox textBoxSum;
    }
}