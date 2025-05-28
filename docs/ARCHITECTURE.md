# Architektur-Übersicht

## System-Architektur

Das Digitale Schulverwaltungssystem basiert auf einer modernen Microservices-Architektur mit folgenden Komponenten:

### Backend Services
- **AuthService**: Authentifizierung und Autorisierung
- **HomeworkService**: Verwaltung von Hausaufgaben
- **NotificationService**: Push-Benachrichtigungen
- **ScheduleService**: Terminverwaltung
- **ReadingPassService**: Lesepass-Tracking

### Frontend
- **Blazor WebAssembly**: Progressive Web App
- **MudBlazor**: Material Design Komponenten
- **Service Worker**: Offline-Funktionalität

### Infrastruktur
- **PostgreSQL**: Relationale Datenbank
- **Redis**: Caching und Session-Management
- **MinIO**: Dateispeicherung
- **RabbitMQ**: Message Queue für Events

## Datenfluss

```
User → Blazor PWA → API Gateway → Microservices → Database
                                 ↓
                         Message Queue → Notification Service
```

## Sicherheit
- JWT-Token basierte Authentifizierung
- Rollenbasierte Zugriffskontrolle (RBAC)
- HTTPS/TLS Verschlüsselung
- DSGVO-konforme Datenverarbeitung
