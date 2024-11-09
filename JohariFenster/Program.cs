using System;
using System;
using System.Windows.Forms;

namespace JohariFenster
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //macht alles etwas hübscher
            Application.EnableVisualStyles();
            //Stellt neueren Text-Rendering-Modus ein
            Application.SetCompatibleTextRenderingDefault(false);

            // Zuerst den Controller erstellen
            FormController controller = new FormController();

            // Hauptformular mit dem Controller als Argument erstellen
            Form01 mainForm = new Form01(controller);

            // Den Controller mit dem Hauptformular verknüpfen
            controller.Initialize(mainForm);

            // Anwendung starten
            controller.StartApplication();

            // Nachrichtenschleife der Anwendung starten
            Application.Run(mainForm);
        }
    }
}

