namespace JohariFenster
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            cmdWeiter2 = new Button();
            label4 = new Label();
            label3 = new Label();
            txtMail2 = new TextBox();
            txtName2 = new TextBox();
            SuspendLayout();
            // 
            // cmdWeiter2
            // 
            resources.ApplyResources(cmdWeiter2, "cmdWeiter2");
            cmdWeiter2.Name = "cmdWeiter2";
            cmdWeiter2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // txtMail2
            // 
            resources.ApplyResources(txtMail2, "txtMail2");
            txtMail2.Name = "txtMail2";
            txtMail2.TextChanged += TextBox_TextChanged;
            // 
            // txtName2
            // 
            resources.ApplyResources(txtName2, "txtName2");
            txtName2.Name = "txtName2";
            txtName2.TextChanged += TextBox_TextChanged;
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            BackgroundImage = Properties.Resources.Orange_;
            Controls.Add(cmdWeiter2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtMail2);
            Controls.Add(txtName2);
            Name = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cmdWeiter2;
        private Label label4;
        private Label label3;
        private TextBox txtMail2;
        private TextBox txtName2;
    }
}