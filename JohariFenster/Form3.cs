using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace JohariFenster
{
    public partial class Form3 : Form
    {
        // Speichert die ausgewählten Adjektive
        public List<int> SelectedAdjectives { get; private set; } = new List<int>();

        // Session-ID für den Datenkontext
        private int sessionID;

        // Controller zur Navigation zwischen den Formen
        private FormController controller;

        // Konstruktor, der den Controller und die Session-ID benötigt
        public Form3(FormController controller, int sessionID)
        {
            InitializeComponent();
            this.controller = controller;
            this.sessionID = sessionID;
            this.checkedListBox1.KeyPress += checkedListBox1_KeyPress;

        }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        private void cmdWeiter_Click(object sender, EventArgs e)
        {
            SelectedAdjectives.Clear(); // Zuerst die Liste leeren
            // Durchläuft die ausgewählten Indices in der CheckedListBox und fügt sie der Liste hinzu
            foreach (int index in checkedListBox1.CheckedIndices)
            {
                SelectedAdjectives.Add(index + 1); // +1, da die Indices in C# bei 0 beginnen, aber die AdjektivIDs in der DB bei 1 starten
            }

            // Überprüft, ob genau 6 Adjektive ausgewählt wurden
            if (SelectedAdjectives.Count != 6)
            {
                MessageBox.Show("Bitte wählen Sie genau 6 Adjektive aus.", "Auswahl überprüfen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Frühzeitiger Rückkehr, wenn nicht genau 6 Adjektive ausgewählt wurden
            }

            this.Hide(); // Versteckt die aktuelle Form
            OpenForm3b(); // Ruft die Methode auf, um Form3b zu öffnen
        }
        private void checkedListBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                if (checkedListBox1.CheckedItems.Count < 6)
                {
                    int selectedIndex = checkedListBox1.SelectedIndex;

                    if (selectedIndex != -1) // Wenn ein Element ausgewählt ist
                    {
                        bool isChecked = checkedListBox1.GetItemChecked(selectedIndex);
                        
                        checkedListBox1.SetItemChecked(selectedIndex, !isChecked);
                    }
                }
                // Wenn genau 6 Kästchen markiert sind, rufe cmdWeiter
                if (checkedListBox1.CheckedItems.Count == 6)
                {
                    cmdWeiter.PerformClick();
                }
            }
        }
        private void OpenForm3b()
        {
            Form3b form3b = new Form3b(controller, sessionID, SelectedAdjectives); // Erstellt eine Instanz von Form3b
            controller.ShowForm(form3b); // Öffnet Form3b über den Controller

            form3b.Name1 = this.Name1; // Setzt den Namen des ersten Teilnehmers in Form3b
            form3b.Name2 = this.Name2; // Setzt den Namen des zweiten Teilnehmers in Form3b
        }
    }
}

