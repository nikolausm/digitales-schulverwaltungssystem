#!/bin/bash

# GitHub Upload Script
# Bitte ersetzen Sie [IhrUsername] mit Ihrem GitHub-Benutzernamen

echo "📦 Initialisiere Git Repository..."
cd /tmp/digitales-schulverwaltungssystem
git init

echo "📝 Füge alle Dateien hinzu..."
git add .

echo "💾 Erstelle initialen Commit..."
git commit -m "Initial project structure - Digitales Schulverwaltungssystem"

echo "🔗 Verknüpfe mit GitHub..."
echo "Bitte geben Sie Ihren GitHub-Benutzernamen ein:"
read github_username

git remote add origin "https://github.com/${github_username}/digitales-schulverwaltungssystem.git"

echo "🚀 Lade zum GitHub Repository hoch..."
git branch -M main
git push -u origin main

echo "✅ Fertig! Projekt wurde zu GitHub hochgeladen."
