namespace HospitalView
{
    partial class FormRandom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            buttonAdd = new Button();
            comboBoxWhat = new ComboBox();
            textBoxCount = new TextBox();
            label = new Label();
            comboBoxQuary = new ComboBox();
            SuspendLayout();
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(118, 146);
            buttonAdd.Margin = new Padding(3, 2, 3, 2);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(82, 22);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // comboBoxWhat
            // 
            comboBoxWhat.FormattingEnabled = true;
            comboBoxWhat.Items.AddRange(new object[] { "Пациенты", "Услуги", "Профессии", "Врачи", "Join" });
            comboBoxWhat.Location = new Point(68, 31);
            comboBoxWhat.Margin = new Padding(3, 2, 3, 2);
            comboBoxWhat.Name = "comboBoxWhat";
            comboBoxWhat.Size = new Size(133, 23);
            comboBoxWhat.TabIndex = 1;
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(68, 6);
            textBoxCount.Margin = new Padding(3, 2, 3, 2);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(133, 23);
            textBoxCount.TabIndex = 2;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(10, 89);
            label.Name = "label";
            label.Size = new Size(38, 15);
            label.TabIndex = 3;
            label.Text = "label1";
            // 
            // comboBoxQuary
            // 
            comboBoxQuary.FormattingEnabled = true;
            comboBoxQuary.Items.AddRange(new object[] { "Добавить", "Select?" });
            comboBoxQuary.Location = new Point(68, 56);
            comboBoxQuary.Margin = new Padding(3, 2, 3, 2);
            comboBoxQuary.Name = "comboBoxQuary";
            comboBoxQuary.Size = new Size(133, 23);
            comboBoxQuary.TabIndex = 4;
            // 
            // FormRandom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(319, 176);
            Controls.Add(comboBoxQuary);
            Controls.Add(label);
            Controls.Add(textBoxCount);
            Controls.Add(comboBoxWhat);
            Controls.Add(buttonAdd);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormRandom";
            Text = "FormRandom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAdd;
        private ComboBox comboBoxWhat;
        private TextBox textBoxCount;
        private Label label;
        private ComboBox comboBoxQuary;
    }
}