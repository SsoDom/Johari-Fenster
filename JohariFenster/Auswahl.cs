using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Configuration;

namespace JohariFenster
{
    public class Auswahl
    {
        // Eigenschaften der Klasse, um Informationen zur Auswahl zu speichern
        public int AuswahlID { get; private set; }  // ID der Auswahl (Primärschlüssel)
        public int SessionID { get; set; }  // ID der Session, um die Auswahl zu referenzieren
        public int AdjektivID { get; set; }  // ID des Adjektivs, das gewählt wurde
        public int AuswahlStatus { get; set; }  // Status der Auswahl (z.B. 1, 2, 3 für verschiedene Auswahlmöglichkeiten)

        // Konstruktor, der eine SessionID als Parameter erfordert
        public Auswahl(int sessionID)
        {
            this.SessionID = sessionID;  // Speichert die SessionID für spätere Datenbankoperationen
        }

        // Methode zum Vergleichen und Speichern der Adjektivauswahl in die Datenbank
        public void CompareAndSaveSelections(List<int> selections1, List<int> selections2)
        {
            // Definierung des Connection Strings zur Access-Datenbank
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(connectionString))  // Öffnen einer neuen Datenbankverbindung
            {
                con.Open();  // Öffnen der Datenbankverbindung

                // Transaktion starten, um sicherzustellen, dass alle Datenbankoperationen als Einheit durchgeführt werden
                using (OleDbTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Schleife über alle möglichen Adjektiv-IDs (angenommen, es gibt 56 Adjektive)
                        for (int adjID = 1; adjID <= 56; adjID++)
                        {
                            int status = 0;  // Initialstatus für jedes Adjektiv

                            // Überprüfen, ob das Adjektiv von Teilnehmer 1 und/oder Teilnehmer 2 gewählt wurde
                            bool isSelectedByFirst = selections1.Contains(adjID);
                            bool isSelectedBySecond = selections2.Contains(adjID);

                            // Setzen des Status, basierend auf den Auswahlen der beiden Teilnehmer
                            if (isSelectedByFirst && isSelectedBySecond)
                                status = 3;  // Beide Teilnehmer haben das Adjektiv ausgewählt
                            else if (isSelectedByFirst)
                                status = 1;  // Nur Teilnehmer 1 hat das Adjektiv ausgewählt
                            else if (isSelectedBySecond)
                                status = 2;  // Nur Teilnehmer 2 hat das Adjektiv ausgewählt

                            // Nur Adjektive speichern, die einen gültigen Status haben (also nicht 0)
                            if (status != 0)
                            {
                                // SQL-Befehl zum Einfügen in die Tabelle "Auswahl"
                                using (OleDbCommand cmd = new OleDbCommand("INSERT INTO Auswahl (SessionID, AdjektivID, AuswahlStatus) VALUES (?, ?, ?)", con, transaction))
                                {
                                    // Parameter hinzufügen und explizit die Typen angeben
                                    cmd.Parameters.Add("@SessionID", OleDbType.Integer).Value = this.SessionID;
                                    cmd.Parameters.Add("@AdjektivID", OleDbType.Integer).Value = adjID;
                                    cmd.Parameters.Add("@AuswahlStatus", OleDbType.Integer).Value = status;

                                    // Ausführen des SQL-Befehls und überprüfen, ob die Operation erfolgreich war
                                    int rowsAffected = cmd.ExecuteNonQuery();
                                    if (rowsAffected != 1)
                                    {
                                        throw new Exception("Fehler beim Speichern des Adjektivs.");  // Fehler werfen, wenn der Eintrag nicht erfolgreich war
                                    }
                                }
                            }
                        }

                        // Erfolgreich, also Transaktion bestätigen (commit)
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Bei Fehler Transaktion zurückrollen (rollback)
                        transaction.Rollback();
                        // Fehler weiterleiten mit zusätzlicher Information
                        throw new Exception("Fehler beim Speichern der Adjektivauswahl: " + ex.Message);
                    }
                }
            }
        }

        // Methode zum Laden der Auswahl aus der Datenbank basierend auf der SessionID
        public List<(int AdjektivID, int AuswahlStatus, string Adjektiv)> LoadSelectionData(int sessionID)
        {
            // Liste, die die Ergebnisse speichert, die aus der Datenbank geladen werden
            List<(int AdjektivID, int AuswahlStatus, string Adjektiv)> results = new List<(int AdjektivID, int AuswahlStatus, string Adjektiv)>();

            // Verbindungsstring zur Access-Datenbank
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            // SQL-Abfrage zum Laden der Adjektivauswahl und deren Status
            string query = @"
                SELECT a.AdjektivID, a.AuswahlStatus, ad.Adjektiv
                FROM Auswahl a
                INNER JOIN Adjektive ad ON a.AdjektivID = ad.AdjektivID
                WHERE a.SessionID = ?";

            try
            {
                // Öffnen einer Verbindung zur Datenbank
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    con.Open();  // Verbindung öffnen

                    // SQL-Befehl vorbereiten
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        // Parameter für die SessionID hinzufügen
                        cmd.Parameters.Add("@SessionID", OleDbType.Integer).Value = sessionID;

                        // Ausführen des SQL-Befehls und Öffnen eines DataReaders zum Durchlesen der Daten
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            // Lese die Daten Zeile für Zeile
                            while (reader.Read())
                            {
                                int adjId = reader.GetInt32(0);  // AdjektivID aus der Datenbank
                                int status = reader.GetInt32(1);  // Auswahlstatus
                                string adjektiv = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);  // Adjektivname (falls vorhanden)

                                // Speichern der Ergebnisse in der Liste
                                results.Add((adjId, status, adjektiv));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Bei Fehlern wird eine aussagekräftige Fehlermeldung geworfen
                throw new Exception("Fehler beim Laden der Auswahl aus der Datenbank: " + ex.Message);
            }

            return results;  // Rückgabe der geladenen Auswahl als Liste
        }
    }
}
