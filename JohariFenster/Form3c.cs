using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JohariFenster
{
    public partial class Form3c : Form
    {
        private FormController controller; // Kontrollinstanz für die Formularnavigation
        public string Name1 { get; set; } // Name des ersten Teilnehmers
        public string Name2 { get; set; } // Name des zweiten Teilnehmers
        private int sessionID; // Session-ID für Datenzugriff
        public List<string> NonSelectedAdjectives { get; set; } // Liste der nicht ausgewählten Adjektivnamen

        // Konstruktor, der den Controller und die Session-ID initialisiert

        public Form3c(FormController controller, int sessionID)
        {
            InitializeComponent();
            this.controller = controller;
            this.sessionID = sessionID;
        }
        // Lädt beim Öffnen der Form die Daten und zeigt die nicht ausgewählten Adjektive an
        private void Form3c_Load(object sender, EventArgs e)
        {
            lblNutzer1.Text = $"Teilnehmer 1: {Name1}";
            lblNutzer2.Text = $"Teilnehmer 2: {Name2}";
            LoadData(sessionID);
            DisplayNonSelectedAdjectives();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Lädt die ausgewählten Adjektive aus der Datenbank
        private void LoadData(int sessionID)
        {
            var selections = new Auswahl(sessionID).LoadSelectionData(sessionID);
            foreach (var selection in selections)
            {
                int auswahlStatus = selection.AuswahlStatus;
                string adjektiv = selection.Adjektiv;

                switch (auswahlStatus)
                {
                    case 3:
                        AddAdjektivToPanel(flowLayoutPanel1, adjektiv);
                        break;
                    case 2:
                        AddAdjektivToPanel(flowLayoutPanel2, adjektiv);
                        break;
                    case 1:
                        AddAdjektivToPanel(flowLayoutPanel3, adjektiv);
                        break;
                }
            }
        }

        // Zeigt die nicht ausgewählten Adjektive auf dem entsprechenden Panel an
        private void DisplayNonSelectedAdjectives()
        {
            foreach (string adjektiv in NonSelectedAdjectives)
            {
                AddAdjektivToPanel(flowLayoutPanel4, adjektiv);
            }
        }

        // Hilfsmethode zum Hinzufügen von Adjektiven zu einem FlowLayoutPanel
        private void AddAdjektivToPanel(FlowLayoutPanel panel, string adjektiv)
        {
            Label label = new Label
            {
                Text = adjektiv,
                AutoSize = true,
                Margin = new Padding(3),  // Definiert den äußeren Abstand des Labels zu seinen Nachbarn im Panel
                Padding = new Padding(3)  // Definiert den inneren Abstand des Textes zum Rand des Labels
            };
            panel.Controls.Add(label);
        }
         private void cmdSave_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Entwicklung\VisualStudio\JohariFenster\AdjektiveAuswahl.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Ausgewählte Adjektive:");

                writer.WriteLine("MIR BEKANNT:");
                SavePanelData(flowLayoutPanel1, writer);

                writer.WriteLine("MIR UNBEKANNT:");
                SavePanelData(flowLayoutPanel2, writer);

                writer.WriteLine("MEIN GEHEIMNIS:");
                SavePanelData(flowLayoutPanel3, writer);

                writer.WriteLine("UNBEKANNT (Nicht ausgewählte Adjektive):");

                SavePanelData(flowLayoutPanel4, writer);
            }

            MessageBox.Show("Daten erfolgreich gespeichert!");
        }
        private void SavePanelData(FlowLayoutPanel panel, StreamWriter writer)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is Label label)
                {
                    writer.WriteLine(label.Text);
                }
            }
        }

    }
}

