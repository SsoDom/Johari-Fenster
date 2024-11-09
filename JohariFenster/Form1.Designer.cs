namespace JohariFenster
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtMail = new TextBox();
            label3 = new Label();
            label4 = new Label();
            cmdWeiter = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(208, 141);
            txtName.Name = "txtName";
            txtName.Size = new Size(201, 23);
            txtName.TabIndex = 3;
            txtName.TextChanged += TextBox_TextChanged;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(208, 217);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(201, 23);
            txtMail.TabIndex = 4;
            txtMail.TextChanged += TextBox_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Symbol", 11.25F);
            label3.Location = new Point(10, 103);
            label3.Name = "label3";
            label3.Size = new Size(208, 20);
            label3.TabIndex = 5;
            label3.Text = "Geben Sie bitte Ihre Name ein";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Symbol", 11.25F);
            label4.Location = new Point(10, 179);
            label4.Name = "label4";
            label4.Size = new Size(211, 20);
            label4.TabIndex = 6;
            label4.Text = "Geben Sie bitte Ihre E-Mail ein";
            // 
            // cmdWeiter
            // 
            cmdWeiter.Font = new Font("Segoe UI Symbol", 11.25F);
            cmdWeiter.Location = new Point(314, 259);
            cmdWeiter.Name = "cmdWeiter";
            cmdWeiter.Size = new Size(95, 29);
            cmdWeiter.TabIndex = 7;
            cmdWeiter.Text = "Weiter";
            cmdWeiter.UseVisualStyleBackColor = true;
            cmdWeiter.Click += cmdWeiter_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.AntiqueWhite;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(72, 51);
            label1.Name = "label1";
            label1.Size = new Size(275, 25);
            label1.TabIndex = 20;
            label1.Text = "Bitte geben Sie Ihre Daten ein";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            BackgroundImage = Properties.Resources.xpx3rcev;
            ClientSize = new Size(421, 320);
            Controls.Add(label1);
            Controls.Add(cmdWeiter);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtMail);
            Controls.Add(txtName);
            Name = "Form1";
            Text = "Teilnehmer 1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtName;
        private TextBox txtMail;
        private Label label3;
        private Label label4;
        private Button cmdWeiter;
        private Label label1;
    }
}
