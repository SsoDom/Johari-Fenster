namespace JohariFenster
{
    partial class Form3
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
            checkedListBox1 = new CheckedListBox();
            cmdWeiter = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "akzeptierend", "albern", "angespannt", "anpassungsfähig", "aufmerksam", "bescheiden", "bestimmt", "energievoll", "entspannt", "extrovertiert", "fähig", "freundlich", "fürsorglich", "geduldig", "geschickt", "genial", "glücklich", "großzügig", "heiter", "hilfreich", "idealistisch", "intelligent", "introvertiert", "kompetent", "komplex", "kühn", "liebevoll", "logisch", "mächtig", "mitfühlend", "nachdenklich", "nervös", "nett", "organisiert", "reaktionsschnell", "reif", "religiös", "ruhig", "scheu", "schlau", "selbstbewusst", "selbstsicher", "sentimental", "spontan", "still", "stolz", "suchend", "tapfer", "unabhängig", "verlässlich", "vernünftig", "vertrauenswürdig", "warmherzig", "weise", "witzig", "würdevoll" });
            checkedListBox1.Location = new Point(35, 70);
            checkedListBox1.MultiColumn = true;
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(509, 256);
            checkedListBox1.TabIndex = 63;
            // 
            // cmdWeiter
            // 
            cmdWeiter.Location = new Point(459, 343);
            cmdWeiter.Name = "cmdWeiter";
            cmdWeiter.Size = new Size(85, 38);
            cmdWeiter.TabIndex = 64;
            cmdWeiter.Text = "Weiter";
            cmdWeiter.UseVisualStyleBackColor = true;
            cmdWeiter.Click += cmdWeiter_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 31);
            label1.Name = "label1";
            label1.Size = new Size(440, 15);
            label1.TabIndex = 65;
            label1.Text = "Wählen Sie die Eigenschaften aus, die auf zutreffen (bitte wählen Sie maximum 6)";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FloralWhite;
            ClientSize = new Size(581, 402);
            Controls.Add(label1);
            Controls.Add(cmdWeiter);
            Controls.Add(checkedListBox1);
            Name = "Form3";
            Text = "Adjektive";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckedListBox checkedListBox1;
        private Button cmdWeiter;
        private Label label1;
    }
}