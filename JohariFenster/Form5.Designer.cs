namespace JohariFenster
{
    partial class Form5
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
            dataGridView1 = new DataGridView();
            cmdAnzeigen = new Button();
            label1 = new Label();
            cmdSchliessen = new Button();
            cmdLoeschenRow = new Button();
            txtName1 = new TextBox();
            txtName2 = new TextBox();
            txtEmail1 = new TextBox();
            txtEmail2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.HighlightText;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(26, 75);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(470, 265);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // cmdAnzeigen
            // 
            cmdAnzeigen.Location = new Point(26, 21);
            cmdAnzeigen.Name = "cmdAnzeigen";
            cmdAnzeigen.Size = new Size(70, 48);
            cmdAnzeigen.TabIndex = 1;
            cmdAnzeigen.Text = "Anzeigen";
            cmdAnzeigen.UseVisualStyleBackColor = true;
            cmdAnzeigen.Click += cmdAnzeigen_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(167, 21);
            label1.Name = "label1";
            label1.Size = new Size(167, 22);
            label1.TabIndex = 2;
            label1.Text = "Liste der Sitzungen:";
            // 
            // cmdSchliessen
            // 
            cmdSchliessen.Location = new Point(406, 419);
            cmdSchliessen.Name = "cmdSchliessen";
            cmdSchliessen.Size = new Size(90, 37);
            cmdSchliessen.TabIndex = 3;
            cmdSchliessen.Text = "Schließen ";
            cmdSchliessen.UseVisualStyleBackColor = true;
            cmdSchliessen.Click += cmdSchliessen_Click;
            // 
            // cmdLoeschenRow
            // 
            cmdLoeschenRow.Location = new Point(26, 419);
            cmdLoeschenRow.Name = "cmdLoeschenRow";
            cmdLoeschenRow.Size = new Size(90, 37);
            cmdLoeschenRow.TabIndex = 5;
            cmdLoeschenRow.Text = "Zeile löschen";
            cmdLoeschenRow.UseVisualStyleBackColor = true;
            cmdLoeschenRow.Click += cmdLoeschenRow_Click;
            // 
            // txtName1
            // 
            txtName1.Location = new Point(26, 346);
            txtName1.Name = "txtName1";
            txtName1.Size = new Size(135, 23);
            txtName1.TabIndex = 6;
            // 
            // txtName2
            // 
            txtName2.Location = new Point(26, 375);
            txtName2.Name = "txtName2";
            txtName2.Size = new Size(135, 23);
            txtName2.TabIndex = 7;
            // 
            // txtEmail1
            // 
            txtEmail1.Location = new Point(167, 346);
            txtEmail1.Name = "txtEmail1";
            txtEmail1.Size = new Size(329, 23);
            txtEmail1.TabIndex = 8;
            // 
            // txtEmail2
            // 
            txtEmail2.Location = new Point(167, 375);
            txtEmail2.Name = "txtEmail2";
            txtEmail2.Size = new Size(329, 23);
            txtEmail2.TabIndex = 9;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(528, 492);
            Controls.Add(txtEmail2);
            Controls.Add(txtEmail1);
            Controls.Add(txtName2);
            Controls.Add(txtName1);
            Controls.Add(cmdLoeschenRow);
            Controls.Add(cmdSchliessen);
            Controls.Add(label1);
            Controls.Add(cmdAnzeigen);
            Controls.Add(dataGridView1);
            Name = "Form5";
            Text = "Liste der Sitzungen:";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button cmdAnzeigen;
        private Label label1;
        private Button cmdSchliessen;
        private Button cmdLoeschenRow;
        private TextBox txtName1;
        private TextBox txtName2;
        private TextBox txtEmail1;
        private TextBox txtEmail2;
    }
}