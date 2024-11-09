using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JohariFenster
{
    public partial class Form01 : Form

    { // Controller, der für die Navigation und das Formularmanagement verantwortlich ist.
        private FormController controller;

        // Konstruktor, der den Controller akzeptiert und initialisiert.
        public Form01(FormController controller)
        {
            InitializeComponent();
            this.controller = controller;  // Speichert die Referenz auf den Controller.
        }

        // Event-Handler für den Menüpunkt "Start", der aufgerufen wird, wenn der Benutzer auf "Start" klickt.
        private void miStart_Click(object sender, EventArgs e)
        {
            // Verwendet den Controller, um das Formular für Form1 anzuzeigen. Übergibt dabei eine Instanz von Form1.
            controller.ShowForm(new Form1(controller));
        }

        // Event-Handler für den Menüpunkt "Anzeigen", der aufgerufen wird, wenn der Benutzer auf "Anzeigen" klickt.
        private void miAnzeigen_Click(object sender, EventArgs e)
        {
            // Verwendet den Controller, um das Formular für Form4 anzuzeigen. Übergibt dabei eine Instanz von Form4.
            controller.ShowForm(new Form4(controller));
        }
        // Event-Handler für den Menüpunkt "Information", der aufgerufen wird, wenn der Benutzer auf "Information" klickt.
        private void miInformation_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = @"C:\Entwicklung\VisualStudio\JohariFenster\JohariFenster\Resources\Infornation.txt";
                string fileContent = File.ReadAllText(filePath);

                MessageBox.Show(fileContent, "Information");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Datei nicht gefunden. Stellen Sie sicher, dass die Datei unter dem angegebenen Pfad existiert.","Fehler");
            }
        }
    }
}