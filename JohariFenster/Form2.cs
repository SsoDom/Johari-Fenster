using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace JohariFenster
{
    public partial class Form2 : Form
    {
        private int sessionID;
        private FormController controller;
        
        public Form2(FormController controller)
        {
            InitializeComponent();
            this.controller = controller;

            cmdWeiter2.Enabled = false;
            txtName2.TextChanged += TextBox_TextChanged;
            txtMail2.TextChanged += TextBox_TextChanged;
            txtMail2.KeyPress += TextMail_KeyPress;
            txtName2.KeyPress += TextName2_KeyPress;
        
            this.cmdWeiter2.Click += new System.EventHandler(this.cmdWeiter_Click);

        }
        public int SelbstUserID { get; set; } // Eigenschaft, um SelbstUserID zu speichern
        // Bereitstellung einer Eigenschaft zum Speichern der Namen der beiden Teilnehmer 
        public string Name1 { get; set; }
        public string Name2
        {
            get { return txtName2.Text; }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool isValidEmail = IsValidEmail(txtMail2.Text);
            bool isValidName = IsValidName(txtName2.Text);

            cmdWeiter2.Enabled = isValidName && isValidEmail;
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
        // Überprüft den Namen auf gültiges Format, erlaubt Buchstaben und bestimmte Sonderzeichen.
        private bool IsValidName(string name)
        {
            if (name.Length < 3)
            {
                txtName2.BackColor = Color.White;
                return false;
            }

            string pattern = @"^[a-zA-ZäöüßÄÖÜ\s'-]+$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            
            if (!Char.IsUpper(name[0]))
            {
                MessageBox.Show("Der Name muss mit einem Großbuchstaben beginnen.");
                txtName2.BackColor = Color.LightCoral;
                return false;
            }
            txtName2.BackColor = Color.Wheat;
            return true;

        }
        private void TextMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                cmdWeiter2.PerformClick();
            }
        }

        private void TextName2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                cmdWeiter2.PerformClick();
            }
        }
        
        private void cmdWeiter_Click(object sender, EventArgs e)
        {
            User newUserFremd = new User(txtName2.Text, txtMail2.Text);
            int fremdUserID = newUserFremd.SaveToDatabase(); // Speichern und ID abrufen


            // Erstellen einer neuen Session und Speichern in der Datenbank
            Session newSession = new Session();
            newSession.SelbstUserID = this.SelbstUserID; // Setzen der SelbstUserID
            newSession.FremdUserID = fremdUserID; // Setzen der FremdUserID
            newSession.Datum = DateTime.Now; // Setzen des aktuellen Datums
            int sessionID = newSession.SaveSessionToDatabase(); // Speichern der Session in der Datenbank

            if (sessionID > 0)
            {
                OpenForm3(sessionID); // Geändert, um sessionID als Parameter zu übergeben
            }
            else
            {
                MessageBox.Show("Fehler beim Speichern der Session.");
                return; // Beende die Methode, um nicht weiterzumachen
            }
        }
        
        private void OpenForm3(int sessionID)
        {
            Form3 form3 = new Form3(controller, sessionID);
            form3.Name1 = this.Name1;        
            form3.Name2 = this.txtName2.Text;
            controller.ShowForm(form3);
           

        }
    }
}