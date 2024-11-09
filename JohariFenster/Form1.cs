using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace JohariFenster
{
    public partial class Form1 : Form
    {
        private FormController controller; // Controller für die Navigation zwischen den Formularen.

        // Konstruktor, der den FormController akzeptiert und initialisiert.
        public Form1(FormController controller)
        {
            InitializeComponent(); // Initialisiert die Form-Komponenten.
            this.controller = controller;

            // Initialisiert den Button als deaktiviert, wird aktiviert, wenn Eingaben validiert sind.
            cmdWeiter.Enabled = false;

            // Event-Handler für die Textänderungen in den Eingabefeldern.
            txtName.TextChanged += TextBox_TextChanged;
            txtMail.TextChanged += TextBox_TextChanged;
            txtMail.KeyPress += TxtMail_KeyPress;
            txtName.KeyPress += TxtName_KeyPress;
        }
        // Eigenschaft zum Zugriff auf den Namen direkt aus dem Textfeld.
        public string Name1
        {
            get { return txtName.Text; }
        }

        // Validiert die Eingaben jedes Mal, wenn der Text in den Textfeldern geändert wird.
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool isValidEmail = IsValidEmail(txtMail.Text);
            bool isValidName = IsValidName(txtName.Text);

            // Aktiviert den Weiter-Button nur, wenn beide Eingaben gültig sind.
            cmdWeiter.Enabled = isValidName && isValidEmail;
        }
        // Überprüft die E-Mail-Adresse auf gültiges Format.
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
                txtName.BackColor = Color.White;
                return false;
            }

            string pattern = @"^[a-zA-ZäöüßÄÖÜ\s'-]+$";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            
            if (!Char.IsUpper(name[0]))
            {
                MessageBox.Show("Der Name muss mit einem Großbuchstaben beginnen.");
                txtName.BackColor = Color.LightCoral;
                return false;
            }
            txtName.BackColor = Color.Wheat;
            return true;

        }
        // Ermöglicht die Eingabe der E-Mail durch Drücken der Enter-Taste zu bestätigen.
        private void TxtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                cmdWeiter.PerformClick();
            }
        }
        private void TxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                cmdWeiter.PerformClick();
            }
        }

        // Wird aufgerufen, wenn der Weiter-Button geklickt wird.
        private void cmdWeiter_Click(object sender, EventArgs e)
        {
            

            // Erstellt einen neuen Benutzer und speichert ihn in der Datenbank.
            User newUserSelbst = new User(txtName.Text, txtMail.Text);
            int selbstUserID = newUserSelbst.SaveToDatabase();

            // Navigiert zum nächsten Formular.
            OpenForm2(selbstUserID);
        }

        // Öffnet das Formular Form2 und übergibt die UserID.
        private void OpenForm2(int selbstUserID)
        {
            Form2 form2 = new Form2(controller);
            form2.SelbstUserID = selbstUserID; // Setzen der SelbstUserID für Form2
            form2.Name1 = this.txtName.Text;
            controller.ShowForm(form2);
        }

        

    }
}
