README: Johari-Fenster Anwendung
1. Was ist das Johari-Fenster?

Das Johari-Fenster wurde 1955 von den Psychologen Joseph Luft und Harry Ingham entwickelt. Es wird in der Kommunikationspsychologie verwendet, um das Selbst- und Fremdbild einer Person zu analysieren, und ist besonders in der Teamentwicklung, im Coaching sowie in Führungskräfteentwicklungsprogrammen hilfreich. Es besteht aus vier Bereichen: öffentlicher Bereich, blinder Fleck, verborgenes Selbst und Unbewusstes. Ziel ist es, die zwischenmenschliche Kommunikation zu verbessern, indem die Wahrnehmungen der Person selbst und anderer verglichen werden.

Der Ablauf des Verfahrens besteht darin, dass beide Teilnehmer jeweils Adjektive auswählen, die sie als passend für die andere Person empfinden. Der Vergleich dieser Auswahl führt zu einer besseren Einsicht in die Selbst- und Fremdwahrnehmung.

2. Funktionsweise der Anwendung

Diese Anwendung ermöglicht es, das Johari-Fenster zwischen zwei Teilnehmern durchzuführen. Die Schritte sind wie folgt:

    Daten eingeben: Beide Teilnehmer geben ihre Namen und E-Mail-Adressen ein.
    Adjektive auswählen: Der erste Teilnehmer wählt sechs Adjektive aus, die ihn selbst am besten beschreiben, und der 				 zweite Teilnehmer wählt sechs Adjektive, die den ersten Teilnehmer beschreiben.
    Ergebnisse anzeigen: Nach der Auswahl können beide Teilnehmer die Ergebnisse einsehen.

Architektur

Die Anwendung folgt dem Model-View-Controller (MVC)-Pattern, das eine klare Trennung der Verantwortlichkeiten ermöglicht und die Wartbarkeit und Testbarkeit der Anwendung verbessert.

    Model: Verwalten der Geschäftslogik, der Datenbankabfragen und der Adjektivauswahl. Hier wird die Datenbank (Access-	   Datei Johari1.accdb) genutzt, um Sitzungsdaten zu speichern und zu verwalten.
    View: Besteht aus den Formularelementen (Forms), die die Benutzeroberfläche darstellen, einschließlich der 			  Dateneingabe und -anzeige. Diese Formulare folgen einer klar strukturierten Benutzerführung.
    Controller: Steuert die Logik und die Navigation zwischen den Formularen. Der FormController sorgt für das Verknüpfen 		der Formulare und das Auslösen entsprechender Aktionen (z. B. Speichern von Adjektivauswahl, Übergabe der 		Daten an die View).

Durchführung (Form1-3c)

Die Formulare 1 bis 3c sind für die Dateneingabe und die Auswahl der Adjektive verantwortlich. Sie implementieren die Logik des Johari-Fensters und leiten den Benutzer durch die einzelnen Schritte der Anwendung.
Daten anzeigen und löschen (Form4-5)

Form4 erfordert die Eingabe eines Passworts (Pass001@), um Zugriff auf Form5 zu erhalten. In Form5 können bestehende Sessions und deren Teilnehmer angezeigt sowie gelöscht werden. Diese Funktionen sind klar von der Durchführung des Verfahrens (Form1-3c) getrennt.
3. Besonderheiten

SQL-Injection-Schutz: Um SQL-Injections zu vermeiden, werden parametrisierte SQL-Abfragen verwendet. Dies geschieht durch den Einsatz von OleDbCommand und Parameters.AddWithValue, um Benutzereingaben sicher in Datenbankabfragen zu integrieren.

Dateispeicherung: Bei Auswahl des Menüpunktes „Information“ wird die Datei information.txt aus dem Verzeichnis C:\temp geöffnet. Beim Anzeigen der Ergebnisse in Form3c wird die Auswahl der Adjektive in AdjektiveAuswahl.txt gespeichert. Beide Dateien sowie die Datenbank Johari1.accdb befinden sich im gleichen Verzeichnis C:\temp.

4. Herausforderungen

Zu Beginn wurden alle 56 Adjektive, einschließlich der mit Auswahlstatus Null, in die Datenbank gespeichert. Dies führte zu einer unnötigen Belastung der Datenbank. Die Lösung: Der vierte Auswahlstatus wird nun direkt aus der CheckedListBox abgefragt, wodurch die Datenbankabfragen optimiert und entlastet wurden.

5. Ausblick

Zukünftig soll die Anwendung auf .NET MAUI portiert werden, um sie plattformübergreifend, insbesondere als mobile App auf Android, nutzen zu können. Weitere geplante Features:

    Einladungslinks per E-Mail für den zweiten Teilnehmer.
    Ergebnisse werden freigeschaltet, sobald beide Teilnehmer ihre Auswahl abgeschlossen haben.
    Umstellung auf eine Single-Page-Architektur ohne Rücknavigation, um die Benutzerführung zu vereinfachen.
    Anpassungen an der Datenbank: Die Session-Tabelle wird um ein Statusfeld (z. B. pending, completed) erweitert.
    Langfristig sollen auch mehrere Teilnehmer an einer Session teilnehmen können.