# 🚀 Render.com Deployment Guide

## Schritt-für-Schritt Anleitung

### 1️⃣ Account erstellen (1 Minute)
1. Gehen Sie zu **https://render.com**
2. Klicken Sie auf **"Get Started for Free"**
3. Wählen Sie **"Sign up with GitHub"**
4. Autorisieren Sie Render für GitHub

### 2️⃣ Neuen Service erstellen (2 Minuten)
1. Im Dashboard klicken Sie auf **"New +"**
2. Wählen Sie **"Blueprint"** (nicht Web Service!)
3. Verbinden Sie Ihr Repository:
   - Suchen Sie nach: **digitales-schulverwaltungssystem**
   - Klicken Sie **"Connect"**

### 3️⃣ Automatisches Deployment (3 Minuten)
1. Render erkennt automatisch die `render.yaml`
2. Sie sehen eine Vorschau mit:
   - **schulverwaltung-frontend** (Static Site)
   - **schulverwaltung-api** (Web Service)
   - **schulverwaltung-db** (PostgreSQL)
3. Klicken Sie **"Apply"**

### 4️⃣ Warten und Fertig! (5-10 Minuten)
- Render baut automatisch alle Services
- Sie können den Fortschritt live verfolgen
- Nach Abschluss sind Ihre URLs:
  - Frontend: `https://schulverwaltung-frontend.onrender.com`
  - API: `https://schulverwaltung-api.onrender.com`

## 🎉 Das war's!

Ihre App ist jetzt live und wird bei jedem Push zu GitHub automatisch aktualisiert!

## 📝 Wichtige Hinweise
- Der erste Build dauert 5-10 Minuten
- Die kostenlosen Services schlafen nach 15 Min Inaktivität
- Beim ersten Aufruf nach Schlaf dauert es ~30 Sekunden
- Perfekt für Entwicklung und Demo-Zwecke!

## 🆘 Troubleshooting
- **Build fehlgeschlagen?** → Logs im Render Dashboard prüfen
- **Seite lädt nicht?** → 30 Sekunden warten (Service startet)
- **Datenbankfehler?** → Environment Variables prüfen
