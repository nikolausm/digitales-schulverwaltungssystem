# Digitales Schulverwaltungssystem

## 📚 Übersicht
Webbasierte Plattform zur Schulverwaltung mit Fokus auf Hausaufgaben-Tracking, Lesepass und Terminverwaltung. Das System ersetzt WhatsApp-Gruppen für Hausaufgaben-Fragen und bietet eine zentrale, verlässliche Informationsquelle.

## 🎯 Hauptfunktionen
- **Hausaufgabenübersicht**: Zentrale Informationsquelle für alle Hausaufgaben
- **Lesepass**: Dokumentation und Tracking der Lesefortschritte
- **Terminverwaltung**: Übersicht aller schulrelevanten Termine
- **Push-Benachrichtigungen**: Automatische Updates bei neuen Einträgen

## 🏗️ Architektur
- **Backend**: .NET 8 mit Microservices-Architektur
- **Frontend**: Blazor WebAssembly (PWA)
- **Datenbank**: PostgreSQL
- **Cache**: Redis
- **Container**: Docker & Docker Compose

## 📁 Projektstruktur
```
digitales-schulverwaltungssystem/
├── src/
│   ├── Backend/
│   │   ├── Services/
│   │   ├── Shared/
│   │   └── Gateway/
│   ├── Frontend/
│   │   ├── Web/
│   │   └── Components/
│   └── Mobile/
├── tests/
├── docs/
├── deploy/
└── scripts/
```

## 🚀 Quick Start
```bash
# Repository klonen
git clone https://github.com/[username]/digitales-schulverwaltungssystem.git

# Docker Container starten
docker-compose up -d

# Frontend starten
cd src/Frontend/Web
dotnet run
```

## 📄 Dokumentation
Weitere Informationen finden Sie im [docs/](./docs) Verzeichnis.

## 📝 Lizenz
Dieses Projekt ist unter der MIT Lizenz lizenziert.
