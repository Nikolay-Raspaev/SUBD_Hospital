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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxWhat = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.comboBoxQuary = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(118, 146);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(82, 22);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // comboBoxWhat
            // 
            this.comboBoxWhat.FormattingEnabled = true;
            this.comboBoxWhat.Items.AddRange(new object[] {
            "Пациенты",
            "Услуги",
            "Профессии"});
            this.comboBoxWhat.Location = new System.Drawing.Point(68, 31);
            this.comboBoxWhat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxWhat.Name = "comboBoxWhat";
            this.comboBoxWhat.Size = new System.Drawing.Size(133, 23);
            this.comboBoxWhat.TabIndex = 1;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(68, 6);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(133, 23);
            this.textBoxCount.TabIndex = 2;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(10, 89);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(38, 15);
            this.label.TabIndex = 3;
            this.label.Text = "label1";
            // 
            // comboBoxQuary
            // 
            this.comboBoxQuary.FormattingEnabled = true;
            this.comboBoxQuary.Items.AddRange(new object[] {
            "Добавить",
            "Select?"});
            this.comboBoxQuary.Location = new System.Drawing.Point(68, 56);
            this.comboBoxQuary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxQuary.Name = "comboBoxQuary";
            this.comboBoxQuary.Size = new System.Drawing.Size(133, 23);
            this.comboBoxQuary.TabIndex = 4;
            // 
            // FormRandom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 176);
            this.Controls.Add(this.comboBoxQuary);
            this.Controls.Add(this.label);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxWhat);
            this.Controls.Add(this.buttonAdd);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormRandom";
            this.Text = "FormRandom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonAdd;
        private ComboBox comboBoxWhat;
        private TextBox textBoxCount;
        private Label label;
        private ComboBox comboBoxQuary;
    }
}