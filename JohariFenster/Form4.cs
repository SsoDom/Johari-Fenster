using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JohariFenster
{
    public partial class Form4 : Form
    {
        private string passwort = "Pass001@";
        private FormController controller;  // Controller-Instanz zur Verwaltung von Formularenavigation

        // Konstruktor, der den FormController empfängt
        public Form4(FormController controller)
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';  // Setzt das Standardzeichen für Passworteingaben
            this.controller = controller;  // Initialisiert den übergebenen Controller
            txtPassword.KeyPress += TxtPassword_KeyPress;  // Eventhandler für Tastendruck-Ereignisse
        }

        // Wechselt die Sichtbarkeit des Passwortes zwischen verdeckt und sichtbar
        private void cmdPass_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = txtPassword.PasswordChar == '*' ? '\0' : '*';
        }

        // Überprüft, ob das eingegebene Passwort mit dem festgelegten Passwort übereinstimmt
        private bool ValidatePassword(string input)
        {
            return input == passwort;
        }
        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;  // Verhindert weiteres Bubbling des Event
                cmdOk_Click_1(sender, e);  // Ruft den OK-Button Click-Handler auf
            }
        }
        private void cmdZurueck_Click(object sender, EventArgs e)
        {
            Form01 form01 = new Form01(controller);
            controller.ShowForm(form01);
            this.Close();
        }
        private void cmdOk_Click_1(object sender, EventArgs e)
        {
            if (ValidatePassword(txtPassword.Text))
            {
                Form5 form5 = new Form5(controller);  // Form5 erwartet ebenfalls einen Controller
                controller.ShowForm(form5);  // Nutze den Controller, um Form5 zu zeigen

            }
            else
            {
                MessageBox.Show("\nPasswort nicht korrekt!\n");
            }
        }
    }
}
       
 