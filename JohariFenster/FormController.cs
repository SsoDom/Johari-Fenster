using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JohariFenster
{
        public class FormController
        {
            private Form mainForm;  // Referenz auf das Hauptformular der Anwendung
            private List<Form> openForms = new List<Form>();  // Liste aller derzeit geöffneten Formulare

            public FormController()
            {
                // Konstruktor für den FormController
            }

            // Initialisiert den Controller mit dem Hauptformular
            public void Initialize(Form mainForm)
            {
                this.mainForm = mainForm;
                this.mainForm.FormClosed += MainForm_FormClosed; // Registriere das FormClosed-Event für das Hauptformular
                openForms.Add(mainForm);  // Füge das Hauptformular zur Liste der geöffneten Formulare hinzu
            }

            // Event-Handler, der aufgerufen wird, wenn das Hauptformular geschlossen wird
            private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
            {
                Application.Exit(); // Beendet die Anwendung, wenn das Hauptformular geschlossen wird
            }

            // Zeigt das Hauptformular an und startet die Anwendung
            public void StartApplication()
            {
                mainForm.Show();
            }

            // Zeigt ein neues Formular an und sorgt dafür, dass alle anderen Formulare geschlossen werden
            public void ShowForm(Form form)
            {
                form.FormClosed += Form_FormClosed; // Registriere das FormClosed-Event für neue Formulare
                openForms.Add(form); // Füge das neue Formular zur Liste der geöffneten Formulare hinzu

                CloseAllFormsExcept(form); // Schließt alle anderen Formulare, außer dem aktuellen

                form.Show();
                mainForm.Hide(); // Versteckt das Hauptformular, anstatt es zu schließen
            }

            // Event-Handler, der aufgerufen wird, wenn ein Formular geschlossen wird
            private void Form_FormClosed(object sender, FormClosedEventArgs e)
            {
                Form closedForm = sender as Form;
                openForms.Remove(closedForm); // Entferne das geschlossene Formular aus der Liste

                if (closedForm is Form3c || closedForm is Form5)
                {
                    mainForm.Show(); // Zeigt das Hauptformular erneut an, wenn Form3c oder Form5 geschlossen wird
                }
                else if (Application.OpenForms.Count == 0)
                {
                    Application.Exit(); // Schließt die Anwendung, wenn keine weiteren Formulare offen sind
                }
            }

            // Schließt alle Formulare außer dem angegebenen Formular
            private void CloseAllFormsExcept(Form currentForm)
            {
                foreach (Form form in openForms.ToArray()) // Iteriere über eine Kopie der Liste, um Modifikationen während der Iteration zu vermeiden
                {
                    if (form != currentForm && form != mainForm)
                    {
                        form.Close(); // Schließt das Formular
                    }
                }
            }
        }
    }
