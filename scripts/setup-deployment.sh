#!/bin/bash

echo "🚀 Schulverwaltungssystem Deployment Setup"
echo "========================================="

# Farbcodes
GREEN='\033[0;32m'
BLUE='\033[0;34m'
YELLOW='\033[1;33m'
NC='\033[0m'

echo -e "\n${BLUE}Wählen Sie Ihre Deployment-Plattform:${NC}"
echo "1) Railway (Free Tier - $5 Credits/Monat)"
echo "2) Render.com (Komplett kostenlos)"
echo "3) Fly.io (Free Tier verfügbar)"
echo "4) Vercel (Nur Frontend - kostenlos)"
echo "5) Alle konfigurieren"

read -p "Ihre Wahl (1-5): " choice

case $choice in
    1)
        echo -e "\n${YELLOW}Railway Setup:${NC}"
        echo "1. Erstellen Sie einen Account auf https://railway.app"
        echo "2. Installieren Sie Railway CLI: npm install -g @railway/cli"
        echo "3. Login: railway login"
        echo "4. Projekt erstellen: railway init"
        echo "5. Deploy: railway up"
        echo -e "\n${GREEN}Railway bietet automatische Deploys bei jedem Push!${NC}"
        ;;
    2)
        echo -e "\n${YELLOW}Render.com Setup:${NC}"
        echo "1. Erstellen Sie einen Account auf https://render.com"
        echo "2. Klicken Sie auf 'New +' > 'Web Service'"
        echo "3. Verbinden Sie Ihr GitHub Repository"
        echo "4. Render erkennt automatisch render.yaml"
        echo -e "\n${GREEN}Render deployed automatisch bei jedem Push!${NC}"
        ;;
    3)
        echo -e "\n${YELLOW}Fly.io Setup:${NC}"
        echo "1. Installieren Sie flyctl: curl -L https://fly.io/install.sh | sh"
        echo "2. Signup: fly auth signup"
        echo "3. Deploy: fly launch"
        echo "4. Folgen Sie den Anweisungen"
        echo -e "\n${GREEN}Fly.io bietet 3 shared VMs kostenlos!${NC}"
        ;;
    4)
        echo -e "\n${YELLOW}Vercel Setup:${NC}"
        echo "1. Installieren Sie Vercel CLI: npm install -g vercel"
        echo "2. Im Projektverzeichnis: vercel"
        echo "3. Folgen Sie den Anweisungen"
        echo -e "\n${GREEN}Vercel ist perfekt für Blazor WebAssembly!${NC}"
        ;;
    5)
        echo -e "\n${GREEN}Alle Plattformen sind vorkonfiguriert!${NC}"
        echo "Folgen Sie den Anweisungen für jede Plattform oben."
        ;;
esac

echo -e "\n${BLUE}GitHub Secrets einrichten:${NC}"
echo "Gehen Sie zu: Settings > Secrets and variables > Actions"
echo "Fügen Sie folgende Secrets hinzu (je nach Plattform):"
echo "- RAILWAY_TOKEN"
echo "- RENDER_API_KEY"
echo "- RENDER_SERVICE_ID" 
echo "- FLY_API_TOKEN"

echo -e "\n${GREEN}✅ Setup abgeschlossen!${NC}"
