namespace JohariFenster
{
    partial class Form4
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
            label1 = new Label();
            txtPassword = new TextBox();
            cmdOk = new Button();
            cmdPass = new Button();
            cmdZurueck = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 29);
            label1.Name = "label1";
            label1.Size = new Size(170, 25);
            label1.TabIndex = 0;
            label1.Text = "Passwort eingeben";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.Beige;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(49, 69);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(132, 27);
            txtPassword.TabIndex = 1;
            // 
            // cmdOk
            // 
            cmdOk.BackColor = Color.Beige;
            cmdOk.Location = new Point(77, 120);
            cmdOk.Name = "cmdOk";
            cmdOk.Size = new Size(86, 37);
            cmdOk.TabIndex = 2;
            cmdOk.Text = "Ok";
            cmdOk.UseVisualStyleBackColor = false;
            cmdOk.Click += cmdOk_Click_1;
            // 
            // cmdPass
            // 
            cmdPass.BackColor = Color.Linen;
            cmdPass.ForeColor = SystemColors.ActiveCaptionText;
            cmdPass.Location = new Point(187, 69);
            cmdPass.Name = "cmdPass";
            cmdPass.Size = new Size(29, 27);
            cmdPass.TabIndex = 4;
            cmdPass.Text = "👁";
            cmdPass.UseVisualStyleBackColor = false;
            cmdPass.Click += cmdPass_Click;
            // 
            // cmdZurueck
            // 
            cmdZurueck.BackColor = Color.Beige;
            cmdZurueck.Location = new Point(77, 172);
            cmdZurueck.Name = "cmdZurueck";
            cmdZurueck.Size = new Size(86, 37);
            cmdZurueck.TabIndex = 5;
            cmdZurueck.Text = "Zurück";
            cmdZurueck.UseVisualStyleBackColor = false;
            cmdZurueck.Click += cmdZurueck_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(264, 252);
            Controls.Add(cmdZurueck);
            Controls.Add(cmdPass);
            Controls.Add(cmdOk);
            Controls.Add(txtPassword);
            Controls.Add(label1);
            Name = "Form4";
            Text = "Administrator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPassword;
        private Button cmdOk;
        private Button cmdPass;
        private Button cmdZurueck;
        //  private Button cmdAugen;
    }
}