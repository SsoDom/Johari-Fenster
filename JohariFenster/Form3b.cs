using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace JohariFenster
{
    public partial class Form3b : Form
    {
        private FormController controller;
        private List<int> firstParticipantSelections;
        private List<int> secondParticipantSelections;
        private List<int> nonSelectedAdjectives;
        private int sessionID;
        public Form3b(FormController controller, int sessionID, List<int> firstParticipantSelections)
        {
            InitializeComponent();
            this.controller = controller;
            this.sessionID = sessionID;
            this.firstParticipantSelections = firstParticipantSelections;
            this.nonSelectedAdjectives = Enumerable.Range(1, 56).Except(firstParticipantSelections).ToList();
            this.checkedListBox1.KeyPress += checkedListBox1_KeyPress;
        }

        public string Name1 { get; set; }  
        public string Name2 { get; set; } 

        private void cmdWeiter_Click(object sender, EventArgs e)
        {
            secondParticipantSelections = new List<int>();
            foreach (int index in checkedListBox1.CheckedIndices)
            {
                secondParticipantSelections.Add(index + 1);
            }

            if (secondParticipantSelections.Count != 6)
            {
                MessageBox.Show("Bitte wählen Sie genau 6 Adjektive aus.", "Auswahl überprüfen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            nonSelectedAdjectives = nonSelectedAdjectives.Except(secondParticipantSelections).ToList();

            Auswahl auswahl = new Auswahl(sessionID);
            auswahl.CompareAndSaveSelections(firstParticipantSelections, secondParticipantSelections);

            OpenForm3c(sessionID);
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
        private void OpenForm3c(int sessionID)
        {
            List<string> nonSelectedAdjectiveNames = new List<string>();
            foreach (var id in nonSelectedAdjectives)
            {
                nonSelectedAdjectiveNames.Add(checkedListBox1.Items[id - 1].ToString());
            }
            Form3c form3c = new Form3c(this.controller, sessionID);
            form3c.Name1 = this.Name1;
            form3c.Name2 = this.Name2;
            form3c.NonSelectedAdjectives = nonSelectedAdjectiveNames;
            controller.ShowForm(form3c);
        }
    }
}
