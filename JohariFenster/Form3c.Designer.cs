namespace JohariFenster
{
    partial class Form3c
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3c));
            button1 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblNutzer1 = new Label();
            lblNutzer2 = new Label();
            ttMirBekannt = new ToolTip(components);
            ttMirUnbekannt = new ToolTip(components);
            ttGeheimnis = new ToolTip(components);
            i = new ToolTip(components);
            cmdSave = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(764, 633);
            button1.Name = "button1";
            button1.Size = new Size(75, 40);
            button1.TabIndex = 0;
            button1.Text = "Beenden";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.BackColor = Color.LightCyan;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Location = new Point(39, 102);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(400, 250);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.MistyRose;
            flowLayoutPanel2.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel2.Location = new Point(439, 102);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(400, 250);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.LightBlue;
            flowLayoutPanel3.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel3.Location = new Point(39, 352);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(400, 250);
            flowLayoutPanel3.TabIndex = 3;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.AutoScroll = true;
            flowLayoutPanel4.BackColor = Color.Thistle;
            flowLayoutPanel4.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel4.Location = new Point(439, 352);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(400, 250);
            flowLayoutPanel4.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 12F);
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(82, 65);
            label1.Name = "label1";
            label1.Size = new Size(122, 21);
            label1.TabIndex = 5;
            label1.Text = "MIR BEKANNT";
            ttMirBekannt.SetToolTip(label1, "Diese Informationen sind sowohl dir als auch anderen Personen über dich bekannt.\r\nErweitere diesen Bereich, indem du offen und ehrlich kommunizierst.\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 12F);
            label2.Location = new Point(495, 65);
            label2.Name = "label2";
            label2.Size = new Size(146, 21);
            label2.TabIndex = 6;
            label2.Text = "MIR UNBEKANNT";
            ttMirUnbekannt.SetToolTip(label2, "Diese Informationen sind anderen über dich bekannt, du selbst bist dir jedoch nicht darüber bewusst.\r\nReduziere diesen \"blinden Fleck\", indem du dir aktiv Feedback von anderen einholst.\r\n");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic", 12F);
            label3.Location = new Point(82, 621);
            label3.Name = "label3";
            label3.Size = new Size(148, 21);
            label3.TabIndex = 7;
            label3.Text = "MEIN GEHEIMNIS";
            ttGeheimnis.SetToolTip(label3, "Das sind Informationen, die du über dich selbst weißt, aber vor anderen zurückhältst.\r\n Verringere diesen Bereich, indem du offener wirst und mehr von dir preisgibst.\r\n");
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic", 12F);
            label4.Location = new Point(495, 621);
            label4.Name = "label4";
            label4.Size = new Size(110, 21);
            label4.TabIndex = 8;
            label4.Text = "UNBEKANNT";
            i.SetToolTip(label4, resources.GetString("label4.ToolTip"));
            // 
            // lblNutzer1
            // 
            lblNutzer1.AutoSize = true;
            lblNutzer1.Font = new Font("Segoe UI", 11.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblNutzer1.Location = new Point(39, 20);
            lblNutzer1.Name = "lblNutzer1";
            lblNutzer1.Size = new Size(50, 20);
            lblNutzer1.TabIndex = 9;
            lblNutzer1.Text = "label5";
            // 
            // lblNutzer2
            // 
            lblNutzer2.AutoSize = true;
            lblNutzer2.Font = new Font("Segoe UI", 11.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblNutzer2.Location = new Point(440, 20);
            lblNutzer2.Name = "lblNutzer2";
            lblNutzer2.Size = new Size(50, 20);
            lblNutzer2.TabIndex = 10;
            lblNutzer2.Text = "label6";
            // 
            // ttMirBekannt
            // 
            ttMirBekannt.ShowAlways = true;
            // 
            // cmdSave
            // 
            cmdSave.Location = new Point(764, 20);
            cmdSave.Name = "cmdSave";
            cmdSave.Size = new Size(75, 40);
            cmdSave.TabIndex = 11;
            cmdSave.Text = "Speichern";
            cmdSave.UseMnemonic = false;
            cmdSave.UseVisualStyleBackColor = true;
            cmdSave.Click += cmdSave_Click;
            // 
            // Form3c
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(896, 719);
            Controls.Add(cmdSave);
            Controls.Add(flowLayoutPanel3);
            Controls.Add(lblNutzer2);
            Controls.Add(lblNutzer1);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(flowLayoutPanel4);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button1);
            Name = "Form3c";
            Text = "Form3c";
            Load += Form3c_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblNutzer1;
        private Label lblNutzer2;
        private ToolTip ttMirBekannt;
        private ToolTip ttMirUnbekannt;
        private ToolTip ttGeheimnis;
        private ToolTip i;
        private Button cmdSave;
    }
}