# Deployment Guide

## Voraussetzungen
- Docker und Docker Compose
- .NET 8 SDK
- Node.js 18+

## Quick Start

### 1. Repository klonen
```bash
git clone https://github.com/[username]/digitales-schulverwaltungssystem.git
cd digitales-schulverwaltungssystem
```

### 2. Umgebungsvariablen konfigurieren
```bash
cp .env.example .env
# .env Datei mit eigenen Werten anpassen
```

### 3. Docker Container starten
```bash
docker-compose up -d
```

### 4. Datenbank initialisieren
```bash
dotnet ef database update -p src/Backend/Services/AuthService
```

### 5. Frontend builden
```bash
cd src/Frontend/Web
dotnet publish -c Release
```

## Produktions-Deployment

### Docker Swarm
Für Produktionsumgebungen empfehlen wir Docker Swarm oder Kubernetes.

### Monitoring
- Prometheus für Metriken
- Grafana für Dashboards
- ELK Stack für Logging
