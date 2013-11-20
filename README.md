WpfWaschmaschine
================
Ziel: Simulation einer Waschmaschine mit dem IOWarrior.

Die Waschmaschine hat viele Funktionen einer echten Waschmaschine, z.B. Fein und Normalwäsche, Temperaturregelung.

Klassen:
cls_Kontroller: Zugriff auf alle Funktionen des IOWarriors. Auslesen der eingehenden Signale des IOWarriors.
cls_Motor: Klasse des Motors, der die Waschtrommel bewegt und anhält.
cls_MySqlDB: Zugriff auf die Datenbank zum Speichern der Eventlogeinträge.
cls_Waschmaschine: Klasse für die komplette Waschmaschine, die Klasse Motor ist ein Bestandteil von ihr.

Formulare:
MainWindow: Hauptformular mit Image der Waschmaschine. Hierdrüber kann mit dem IOWarrior, über Buttons und Checkboxen interagiert werden.
