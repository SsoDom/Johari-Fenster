using System;
using System.Data.OleDb;
using System.Configuration;

namespace JohariFenster
{
    public class User
    {
        // Die UserID wird automatisch in der Datenbank generiert und ist nur lesbar
        public int UserID { get; private set; }

        // Öffentlich zugängliche Eigenschaften für den Benutzernamen und die E-Mail
        public string UserName { get; set; }
        public string Email { get; set; }

        // Konstruktor zum Initialisieren des Benutzernamens und der E-Mail-Adresse
        public User(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }

        // Speichert die Benutzerdetails in der Datenbank und gibt die generierte UserID zurück
        public int SaveToDatabase()
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    con.Open(); // Öffnet die Datenbankverbindung

                    // Beginnt eine Transaktion, um die Atomarität zu gewährleisten
                    OleDbTransaction transaction = con.BeginTransaction();

                    // SQL-Befehl zum Einfügen der Benutzerdaten
                    string cmdText = "INSERT INTO Teilnehmer (TeilnehmerName, Email) VALUES (?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(cmdText, con, transaction))
                    {
                        // Parameter für den SQL-Befehl setzen und SQL-Injection vorbeugen
                        cmd.Parameters.Add("@TeilnehmerName", OleDbType.VarChar).Value = this.UserName;
                        cmd.Parameters.Add("@Email", OleDbType.VarChar).Value = this.Email;

                        // Führt den Einfügebefehl aus
                        cmd.ExecuteNonQuery();

                        // Hole die zuletzt generierte UserID
                        cmd.CommandText = "SELECT @@IDENTITY";
                        object result = cmd.ExecuteScalar(); // Führt den Befehl aus und gibt das erste Ergebnis zurück

                        // Wenn eine UserID generiert wurde, weise sie der Eigenschaft zu
                        if (result != null)
                        {
                            UserID = Convert.ToInt32(result);
                        }

                        // Transaktion erfolgreich abschließen
                        transaction.Commit();
                    }
                }
            }
            catch (OleDbException oleDbEx)
            {
                // Datenbankspezifische Fehlerbehandlung
                Console.WriteLine("Datenbankfehler: " + oleDbEx.Message);
                throw new Exception("Fehler beim Speichern des Benutzers in die Datenbank.", oleDbEx);
            }
            catch (Exception ex)
            {
                // Allgemeine Fehlerbehandlung
                Console.WriteLine("Allgemeiner Fehler: " + ex.Message);
                throw new Exception("Fehler beim Speichern des Benutzers in die Datenbank.", ex);
            }

            // Rückgabe der neu generierten UserID
            return UserID;
        }
    }
}
