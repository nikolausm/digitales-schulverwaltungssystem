# Digitales Schulverwaltungssystem

[![Deploy to Render](https://render.com/images/deploy-to-render-button.svg)](https://render.com/deploy?repo=https://github.com/nikolausm/digitales-schulverwaltungssystem)
[![Deploy on Railway](https://railway.app/button.svg)](https://railway.app/new/template?template=https://github.com/nikolausm/digitales-schulverwaltungssystem)

## 📚 Übersicht
Webbasierte Plattform zur Schulverwaltung mit Fokus auf Hausaufgaben-Tracking, Lesepass und Terminverwaltung. Das System ersetzt WhatsApp-Gruppen für Hausaufgaben-Fragen und bietet eine zentrale, verlässliche Informationsquelle.

## 🚀 One-Click Deployment

### Sofort deployen:
- **[Deploy to Render](https://render.com/deploy?repo=https://github.com/nikolausm/digitales-schulverwaltungssystem)** - Kostenlos mit Auto-Sleep
- **[Deploy to Railway](https://railway.app/new/template?template=https://github.com/nikolausm/digitales-schulverwaltungssystem)** - $5 Credits/Monat
- **[Deploy to Vercel](https://vercel.com/new/clone?repository-url=https://github.com/nikolausm/digitales-schulverwaltungssystem)** - Frontend Only

### Oder besuchen Sie unser [🎯 Deployment Center](https://nikolausm.github.io/digitales-schulverwaltungssystem/)

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
git clone https://github.com/nikolausm/digitales-schulverwaltungssystem.git

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
