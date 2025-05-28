#!/bin/bash

# GitHub CLI Upload Script

echo "📦 Initialisiere Git Repository..."
cd /tmp/digitales-schulverwaltungssystem
git init

echo "📝 Füge alle Dateien hinzu..."
git add .

echo "💾 Erstelle initialen Commit..."
git commit -m "Initial project structure - Digitales Schulverwaltungssystem"

echo "🚀 Erstelle GitHub Repository und lade hoch..."
gh repo create digitales-schulverwaltungssystem \
  --public \
  --description "Webbasierte Plattform zur Schulverwaltung mit Hausaufgaben-Tracking, Lesepass und Terminverwaltung" \
  --source=. \
  --remote=origin \
  --push

echo "✅ Fertig! Projekt wurde zu GitHub hochgeladen."
echo "🔗 Repository URL: https://github.com/$(gh api user --jq .login)/digitales-schulverwaltungssystem"
