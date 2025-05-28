# 🚀 Kostenloses Deployment Guide

## Übersicht der kostenlosen Optionen

| Platform | Kostenlos | Limits | Best für |
|----------|-----------|--------|----------|
| **Railway** | $5 Credits/Monat | 500 MB RAM, 1 GB Disk | Full-Stack Apps |
| **Render** | ✅ Komplett | 512 MB RAM, Spin-down nach 15 Min | APIs & Static Sites |
| **Fly.io** | 3 VMs kostenlos | 256 MB RAM pro VM | Microservices |
| **Vercel** | ✅ Unbegrenzt | Nur Static/JAMstack | Blazor Frontend |
| **GitHub Pages** | ✅ Unbegrenzt | Nur Static | Dokumentation |

## Quick Start

### Option 1: Railway (Empfohlen für Vollständige App)
```bash
# Railway CLI installieren
npm install -g @railway/cli

# Login und Deploy
railway login
railway init
railway up
```

### Option 2: Render.com (Einfachste Option)
1. Push zu GitHub
2. Verbinde Repository auf render.com
3. Automatisches Deployment!

### Option 3: Kombinierte Lösung (Beste Performance)
- **Frontend**: Vercel (Blazor WebAssembly)
- **Backend API**: Render.com
- **Datenbank**: Supabase (Postgres kostenlos)

## Automatisches Deployment

Alle Pushes zu `main` Branch triggern automatisch:
1. Tests laufen durch
2. Docker Images werden gebaut
3. Deployment zu gewählter Platform
4. Neue Version ist live!

## Environment Variablen

Setzen Sie folgende Secrets in GitHub:
- `RAILWAY_TOKEN` (für Railway)
- `RENDER_API_KEY` (für Render)
- `FLY_API_TOKEN` (für Fly.io)

## Monitoring

- **GitHub Actions**: Build Status
- **Plattform Dashboards**: Logs & Metriken
- **Uptime Robot**: Kostenlose Überwachung
