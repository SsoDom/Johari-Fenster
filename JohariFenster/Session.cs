using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;

namespace JohariFenster
{
    public class Session
    {
        // Privates Feld, um die ID der Session zu speichern
        private int sessionID;
        private int _selbstUserID; // Speichert die User ID des Teilnehmers, der die Beurteilung startet
        private int _fremdUserID;  // Speichert die User ID des beurteilten Teilnehmers
        private DateTime _datum;   // Datum der Session

        // Öffentliche Eigenschaft zur Rückgabe der SessionID
        public int SessionID
        {
            get { return sessionID; }
        }

        // Öffentliche Eigenschaft für den selbst bewertenden Teilnehmer
        public int SelbstUserID
        {
            get { return _selbstUserID; }
            set { _selbstUserID = value; }
        }

        // Öffentliche Eigenschaft für den bewerteten Teilnehmer
        public int FremdUserID
        {
            get { return _fremdUserID; }
            set { _fremdUserID = value; }
        }

        // Öffentliche Eigenschaft für das Datum der Session
        public DateTime Datum
        {
            get { return _datum; }
            set { _datum = value; }
        }

        // Methode zum Speichern der Session-Daten in der Datenbank
        public int SaveSessionToDatabase()
        {
            // Verbindungszeichenfolge zur Access-Datenbank
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            int localSessionID = 0; // Lokale Variable zum Speichern der neu erstellten SessionID

            try
            {
                // Verbindungsaufbau zur Datenbank
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    con.Open(); // Öffnet die Datenbankverbindung

                    // Beginne eine Transaktion, um die Atomarität zu gewährleisten
                    OleDbTransaction transaction = con.BeginTransaction();

                    // SQL-Befehl zum Einfügen einer neuen Session
                    string cmdText = "INSERT INTO Sessions (SelbstUserID, FremdUserID, Datum) VALUES (?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(cmdText, con, transaction))
                    {
                        // Aktuelles Datum wird im gewünschten Format 'dd.MM.yyyy' verwendet
                        DateTime now = DateTime.Now;
                        Debug.WriteLine("Datum vor Datenbankeingabe: " + now.ToString("dd.MM.yyyy"));
                        string formattedDate = now.ToString("dd.MM.yyyy");

                        // Parameter für den SQL-Befehl hinzufügen
                        cmd.Parameters.Add("@SelbstUserID", OleDbType.Integer).Value = this.SelbstUserID;
                        cmd.Parameters.Add("@FremdUserID", OleDbType.Integer).Value = this.FremdUserID;
                        //cmd.Parameters.Add("@Datum", OleDbType.Date).Value = formattedDate;
                        //cmd.Parameters.Add("@Datum", OleDbType.Date).Value = now;
                        cmd.Parameters.Add("@Datum", OleDbType.Date).Value = DateTime.ParseExact(formattedDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);

                        // Führt den Einfügebefehl aus
                        cmd.ExecuteNonQuery();

                        // Hole die zuletzt generierte SessionID
                        cmd.CommandText = "SELECT @@IDENTITY";
                        object result = cmd.ExecuteScalar(); // Gibt das erste Ergebnis der Abfrage zurück
                        if (result != null)
                        {
                            localSessionID = Convert.ToInt32(result); // Konvertiert das Ergebnis in einen Integer
                        }
                    }

                    // Erfolgreiches Abschließen der Transaktion
                    transaction.Commit();
                }
            }
            catch (OleDbException oleDbEx)
            {
                // Datenbankspezifische Fehlerbehandlung
                Console.WriteLine("Datenbankfehler: " + oleDbEx.Message);
                throw new Exception("Fehler beim Speichern der Session in die Datenbank.", oleDbEx);
            }
            catch (Exception ex)
            {
                // Allgemeine Fehlerbehandlung
                Console.WriteLine("Allgemeiner Fehler: " + ex.Message);
                throw new Exception("Fehler beim Speichern der Session in die Datenbank.", ex);
            }

            // Speichert die SessionID in das Klassenfeld
            this.sessionID = localSessionID;
            return this.sessionID; // Gibt die neu generierte SessionID zurück
        }
    }
}
