# API Dokumentation

## Übersicht
Die API des Digitalen Schulverwaltungssystems folgt REST-Prinzipien und verwendet JSON für Datenübertragung.

## Basis-URL
```
https://api.schulverwaltung.de/v1
```

## Authentifizierung
Alle API-Anfragen (außer Login) erfordern einen gültigen JWT-Token im Authorization Header:
```
Authorization: Bearer <token>
```

## Endpoints

### Auth Service

#### POST /auth/login
Login mit Benutzername und Passwort oder QR-Code.

#### POST /auth/refresh
Token erneuern.

#### POST /auth/logout
Benutzer abmelden.

### Homework Service

#### GET /homework
Liste aller Hausaufgaben für den aktuellen Benutzer.

#### POST /homework
Neue Hausaufgabe erstellen (nur Lehrer).

#### PUT /homework/{id}
Hausaufgabe aktualisieren.

#### DELETE /homework/{id}
Hausaufgabe löschen.

### Weitere Services...
