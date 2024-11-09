README: Johari-Fenster Anwendung
1. Was ist das Johari-Fenster?

Das Johari-Fenster wurde 1955 von den Psychologen Joseph Luft und Harry Ingham entwickelt. 
Es wird häufig in der Kommunikationspsychologie verwendet, um das Selbst- und Fremdbild 
einer Person zu analysieren. Besonders in der Teamentwicklung, beim Coaching und in 
Führungskräfteentwicklungsprogrammen ist es ein beliebtes Werkzeug. Es besteht aus vier 
Bereichen (öffentliche Person, blinder Fleck, verborgenes Selbst und Unbewusstes) und 
zielt darauf ab, zwischenmenschliche Kommunikation zu verbessern.

Der Ablauf erfolgt durch die Auswahl von Adjektiven, die sowohl von der Person selbst 
als auch von anderen beurteilt werden. Durch den Vergleich dieser Adjektive entsteht 
ein differenziertes Bild über das Selbst- und Fremdwahrnehmung.

2. Funktionsweise der Anwendung

Diese Anwendung ermöglicht die Durchführung des Johari-Fensters zwischen zwei Teilnehmern. Der erste Teilnehmer 
gibt seinen Namen, seine E-Mail-Adresse ein. Der zweite Teilnehmer gibt ebenfalls seine Daten ein.
Anschließend wählt der erste Teilnehmer sechs Adjektive aus einer Liste aus, von denen er meint, dass sie ihn besonders
gut beschreiben. Danach wählt der zweite Teilnehmer ebenfalls sechs Adjektive, von denen er meint, dass sie den ersten 
Teilnehmer besonders gut beschreiben. Nach der Auswahl können beide Teilnehmer die Ergebnisse einsehen.

    Durchführung (Form1-3c): Die Formulare zur Dateneingabe und Adjektivauswahl sind so gestaltet, 
	dass sie dem MVC-Pattern (Model-View-Controller) folgen. Dabei wird das Model zur Verwaltung
	der Datenbankabfragen und Adjektivauswahl verwendet, die Views stellen die grafische Benutzeroberfläche
	bereit und der Controller kümmert sich um die Logik und Steuerung der Formularnavigation.

    Daten anzeigen und löschen (Form4-5): In Form4 muss das Passwort Pass001@ eingeben werden, um Zugriff auf Form5 zu 	bekommen Form5. In Form5 können bestehende Sessions und deren Teilnehmer
	angezeigt und gelöscht werden. Diese Formulare sind von der eigentlichen Durchführung des Verfahrens getrennt.

3. Besonderheiten

    SQL-Injection Schutz: Die Anwendung verwendet parametrisierte SQL-Abfragen, um SQL-Injections zu vermeiden.
	Dies wird durch die Verwendung von OleDbCommand und Parameters.AddWithValue erreicht, wodurch Benutzereingaben
	sicher in die Datenbankabfragen eingebunden werden.

    Speicherung von Dateien: Wenn der Menüpunkt „Information“ in der Anwendung ausgewählt wird, wird die Datei 
	information.txt aus dem Verzeichnis C:\temp aufgerufen. Darüber hinaus wird beim Anzeigen der Ergebnisse 
	in Form3c das Ergebnis des Verfahrens in der Datei AdjektiveAuswahl.txt gespeichert, die ebenfalls im 
	Verzeichnis C:\temp liegt. Die Datenbank selbst (Johari1.accdb) ist ebenfalls unter diesem Pfad gespeichert 
	und verwaltet alle Sessions sowie Teilnehmer.

4. Herausforderungen

Eine der größten Herausforderungen war die Handhabung der Formulare und das Sicherstellen, dass die Daten korrekt 
in die Datenbank geschrieben und ausgelesen werden. Zu Beginn wurden alle 56 Adjektive, einschließlich der mit 
Auswahlstatus Null, in die Datenbank gespeichert. Da der vierte Status aus den anderen ableitbar ist, wird er 
nun direkt aus der CheckedListBox abgefragt. Dadurch wird die Datenbank deutlich entlastet.

5. Ausblick

In Zukunft soll die Anwendung auf .NET MAUI portiert werden, um eine plattformübergreifende Nutzung zu ermöglichen,
insbesondere als mobile App auf Android. Der zweite Teilnehmer soll per Email einen Einladungslink zum Verfahren 
erhalten. Die Ergebnisse werden über die App freigeschaltet, sobald beide Teilnehmer ihre Auswahl abgeschlossen 
haben. Formulare sollen in einer Single-Page-Architektur ohne Rücknavigation gestaltet werden, um die 
Benutzerführung zu vereinfachen. Außerdem müssen kleine Änderungen an der Datenbank vorgenommen werden. Die
Session-Tabelle wird ein Statusfeld erhalten (pending, completed). Irgendwann soll die App so erweitert werden,
dass mehr als zwei Teilnehmer an einer Session teilnehmen können.

Wir freuen uns auf das Feedback und auf die Weiterentwicklung der Anwendung in die mobile Welt mit .NET MAUI!