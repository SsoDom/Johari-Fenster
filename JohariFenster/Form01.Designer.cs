namespace JohariFenster
{
    partial class Form01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form01));
            menuStrip1 = new MenuStrip();
            johariFenserToolStripMenuItem = new ToolStripMenuItem();
            miStart = new ToolStripMenuItem();
            datenToolStripMenuItem = new ToolStripMenuItem();
            miAnzeigen = new ToolStripMenuItem();
            miInformation = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Orange;
            menuStrip1.Items.AddRange(new ToolStripItem[] { johariFenserToolStripMenuItem, datenToolStripMenuItem, miInformation });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(479, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // johariFenserToolStripMenuItem
            // 
            johariFenserToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miStart });
            johariFenserToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            johariFenserToolStripMenuItem.Name = "johariFenserToolStripMenuItem";
            johariFenserToolStripMenuItem.Size = new Size(97, 20);
            johariFenserToolStripMenuItem.Text = "Johari Fenster";
            // 
            // miStart
            // 
            miStart.BackColor = Color.Yellow;
            miStart.Name = "miStart";
            miStart.Size = new Size(102, 22);
            miStart.Text = "Start";
            miStart.Click += miStart_Click;
            // 
            // datenToolStripMenuItem
            // 
            datenToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miAnzeigen });
            datenToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            datenToolStripMenuItem.Name = "datenToolStripMenuItem";
            datenToolStripMenuItem.Size = new Size(53, 20);
            datenToolStripMenuItem.Text = "Daten";
            // 
            // miAnzeigen
            // 
            miAnzeigen.BackColor = Color.Yellow;
            miAnzeigen.Name = "miAnzeigen";
            miAnzeigen.Size = new Size(180, 22);
            miAnzeigen.Text = "Anzeigen";
            miAnzeigen.Click += miAnzeigen_Click;
            // 
            // miInformation
            // 
            miInformation.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            miInformation.Name = "miInformation";
            miInformation.Size = new Size(86, 20);
            miInformation.Text = "Information";
            miInformation.Click += miInformation_Click;
            // 
            // Form01
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 128);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(479, 427);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form01";
            Text = "Johari Window Start";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem johariFenserToolStripMenuItem;
        private ToolStripMenuItem miStart;
        private ToolStripMenuItem datenToolStripMenuItem;
        private ToolStripMenuItem miAnzeigen;
        private ToolStripMenuItem miInformation;
    }
}