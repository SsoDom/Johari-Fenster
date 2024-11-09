using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace JohariFenster
{
    public partial class Form5 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private FormController controller;

        public Form5(FormController controller)
        {
            InitializeComponent();
            this.controller = controller;

            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void cmdAnzeigen_Click(object sender, EventArgs e)
        {
            //Ohne Deaktivieren des Events und die Hilfsmethode InitializeDataGridView(), wurden die
            // Daten nur angezeigt, wenn vorher einmal Form1-3c durchlaufen wurden. Gab es keinen 
            //vorherigen Durchlauf, ist die Anwendung abgestürzt. 
            dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;  // Event deaktivieren

            InitializeDataGridView();  // Sicherstellen, dass das DataGridView initialisiert ist

            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    con.Open();
                    string cmdText = "SELECT SessionID, SelbstUserID, FremdUserID, Datum FROM Sessions";
                    using (OleDbCommand cmd = new OleDbCommand(cmdText, con))
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        // Füge die Daten zur DataGridView hinzu
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(
                                reader["SessionID"].ToString(),
                                reader["SelbstUserID"].ToString(),
                                reader["FremdUserID"].ToString(),
                                Convert.ToDateTime(reader["Datum"]).ToString("dd.MM.yyyy"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler: " + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;  // Event wieder aktivieren
            }
        }


        private void InitializeDataGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Spalten zu DataGridView hinzufügen
            dataGridView1.Columns.Add("SessionID", "SessionID");
            dataGridView1.Columns.Add("SelbstUserID", "SelbstUserID");
            dataGridView1.Columns.Add("FremdUserID", "FremdUserID");
            dataGridView1.Columns.Add("Datum", "Datum");

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.Font = new Font("Consolas", 10);
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridView1.RowsDefaultCellStyle.BackColor = Color.Orange;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Yellow;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void cmdSchliessen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdLoeschenRow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string sessionId = dataGridView1.SelectedRows[0].Cells["SessionID"].Value.ToString();

                try
                {
                    using (OleDbConnection con = new OleDbConnection(connectionString))
                    {
                        con.Open();
                        string cmdText = "DELETE FROM Sessions WHERE SessionID = ?";
                        using (OleDbCommand cmd = new OleDbCommand(cmdText, con))
                        {
                            cmd.Parameters.AddWithValue("?", sessionId);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Zeile erfolgreich gelöscht!");
                            cmdAnzeigen_Click(null, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler beim Löschen der Zeile: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Zeile zum Löschen aus.");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string sessionID = dataGridView1.CurrentRow.Cells["SessionID"].Value?.ToString();

                if (string.IsNullOrEmpty(sessionID))
                {
                    MessageBox.Show("SessionID ist leer.");
                    return;
                }

                try
                {
                    using (OleDbConnection con = new OleDbConnection(connectionString))
                    {
                        con.Open();

                        // Daten des Selbst-Teilnehmers abrufen
                        string querySelbst = @"
                            SELECT 
                                s.SelbstUserID,
                                selbstTeilnehmer.TeilnehmerName AS SelbstTeilnehmerName, 
                                selbstTeilnehmer.Email AS SelbstEmail
                            FROM 
                                Sessions s
                                INNER JOIN Teilnehmer AS selbstTeilnehmer ON s.SelbstUserID = selbstTeilnehmer.TeilnehmerID
                            WHERE 
                                s.SessionID = ?";

                        using (OleDbCommand cmd = new OleDbCommand(querySelbst, con))
                        {
                            cmd.Parameters.AddWithValue("@sessionID", sessionID);

                            using (OleDbDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    txtName1.Text = reader["SelbstTeilnehmerName"].ToString();
                                    txtEmail1.Text = reader["SelbstEmail"].ToString();
                                }
                            }
                        }

                        // Daten des Fremd-Teilnehmers abrufen
                        string queryFremd = @"
                            SELECT 
                                s.FremdUserID,
                                fremdTeilnehmer.TeilnehmerName AS FremdTeilnehmerName, 
                                fremdTeilnehmer.Email AS FremdEmail
                            FROM 
                                Sessions s
                                INNER JOIN Teilnehmer AS fremdTeilnehmer ON s.FremdUserID = fremdTeilnehmer.TeilnehmerID
                            WHERE 
                                s.SessionID = ?";

                        using (OleDbCommand commandFremd = new OleDbCommand(queryFremd, con))
                        {
                            commandFremd.Parameters.AddWithValue("@sessionID", sessionID);

                            using (OleDbDataReader readerFremd = commandFremd.ExecuteReader())
                            {
                                if (readerFremd.Read())
                                {
                                    txtName2.Text = readerFremd["FremdTeilnehmerName"].ToString();
                                    txtEmail2.Text = readerFremd["FremdEmail"].ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler beim Abrufen der Teilnehmerdaten: " + ex.Message);
                }
            }
        }
    }
}
