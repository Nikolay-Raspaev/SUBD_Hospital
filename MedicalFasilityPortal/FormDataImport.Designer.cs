namespace HospitalView
{
    partial class FormDataImport
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
            buttonContract = new Button();
            buttonDoctor = new Button();
            buttonService = new Button();
            buttonJob = new Button();
            buttonPatient = new Button();
            label = new Label();
            SuspendLayout();
            // 
            // buttonContract
            // 
            buttonContract.Location = new Point(14, 12);
            buttonContract.Name = "buttonContract";
            buttonContract.Size = new Size(70, 25);
            buttonContract.TabIndex = 1;
            buttonContract.Text = "Contract";
            buttonContract.UseVisualStyleBackColor = true;
            buttonContract.Click += buttonContract_Click;
            // 
            // buttonDoctor
            // 
            buttonDoctor.Location = new Point(90, 12);
            buttonDoctor.Name = "buttonDoctor";
            buttonDoctor.Size = new Size(56, 25);
            buttonDoctor.TabIndex = 2;
            buttonDoctor.Text = "Doctor";
            buttonDoctor.UseVisualStyleBackColor = true;
            buttonDoctor.Click += buttonDoctor_Click;
            // 
            // buttonService
            // 
            buttonService.Location = new Point(276, 12);
            buttonService.Name = "buttonService";
            buttonService.Size = new Size(56, 25);
            buttonService.TabIndex = 3;
            buttonService.Text = "Service";
            buttonService.UseVisualStyleBackColor = true;
            buttonService.Click += buttonService_Click;
            // 
            // buttonJob
            // 
            buttonJob.Location = new Point(152, 12);
            buttonJob.Name = "buttonJob";
            buttonJob.Size = new Size(56, 25);
            buttonJob.TabIndex = 4;
            buttonJob.Text = "Job";
            buttonJob.UseVisualStyleBackColor = true;
            buttonJob.Click += buttonJob_Click;
            // 
            // buttonPatient
            // 
            buttonPatient.Location = new Point(214, 12);
            buttonPatient.Name = "buttonPatient";
            buttonPatient.Size = new Size(56, 25);
            buttonPatient.TabIndex = 5;
            buttonPatient.Text = "Patient";
            buttonPatient.UseVisualStyleBackColor = true;
            buttonPatient.Click += buttonPatient_Click;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(14, 57);
            label.Name = "label";
            label.Size = new Size(38, 15);
            label.TabIndex = 6;
            label.Text = "label1";
            // 
            // FormDataImport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label);
            Controls.Add(buttonPatient);
            Controls.Add(buttonJob);
            Controls.Add(buttonService);
            Controls.Add(buttonDoctor);
            Controls.Add(buttonContract);
            Name = "FormDataImport";
            Text = "FormDataImport";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonContract;
        private Button buttonDoctor;
        private Button buttonService;
        private Button buttonJob;
        private Button buttonPatient;
        private Label label;
    }
}