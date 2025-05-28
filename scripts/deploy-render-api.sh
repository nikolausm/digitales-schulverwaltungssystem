#!/bin/bash

# Render.com API Deployment Script
echo "🚀 Automatisches Render.com Deployment"
echo "====================================="

# Variablen
GITHUB_REPO="https://github.com/nikolausm/digitales-schulverwaltungssystem"
SERVICE_NAME="schulverwaltung-frontend"
API_SERVICE_NAME="schulverwaltung-api"

# Render API Key (muss als Umgebungsvariable gesetzt werden)
if [ -z "$RENDER_API_KEY" ]; then
    echo "❌ Fehler: RENDER_API_KEY nicht gesetzt!"
    echo ""
    echo "So erhalten Sie Ihren API Key:"
    echo "1. Gehen Sie zu https://dashboard.render.com/account/api-keys"
    echo "2. Klicken Sie 'Create API Key'"
    echo "3. Kopieren Sie den Key"
    echo "4. Führen Sie aus: export RENDER_API_KEY='Ihr-Key-Hier'"
    echo ""
    exit 1
fi

echo "✅ API Key gefunden"
echo ""

# Funktion zum Erstellen eines Services
create_service() {
    local service_type=$1
    local service_name=$2
    local dockerfile=$3
    
    echo "📦 Erstelle $service_type Service: $service_name"
    
    response=$(curl -s -X POST https://api.render.com/v1/services \
        -H "Authorization: Bearer $RENDER_API_KEY" \
        -H "Content-Type: application/json" \
        -d @- <<EOF
{
    "type": "web_service",
    "name": "$service_name",
    "ownerId": "user",
    "repo": "$GITHUB_REPO",
    "autoDeploy": "yes",
    "branch": "main",
    "envVars": [
        {
            "key": "PORT",
            "value": "10000"
        }
    ],
    "serviceDetails": {
        "env": "docker",
        "dockerfilePath": "./$dockerfile",
        "dockerContext": ".",
        "region": "frankfurt"
    }
}
EOF
)
    
    service_id=$(echo $response | grep -o '"id":"[^"]*' | sed 's/"id":"//')
    
    if [ -n "$service_id" ]; then
        echo "✅ Service erstellt: $service_id"
        echo "🔗 URL: https://$service_name.onrender.com"
    else
        echo "❌ Fehler beim Erstellen des Services"
        echo "Response: $response"
    fi
    
    echo ""
}

# Services erstellen
create_service "Frontend" "$SERVICE_NAME" "Dockerfile.frontend"
create_service "API" "$API_SERVICE_NAME" "Dockerfile.api"

echo "🎉 Deployment gestartet!"
echo ""
echo "📊 Verfolgen Sie den Fortschritt im Dashboard:"
echo "   https://dashboard.render.com"
echo ""
echo "⏱️  Die Services werden in 5-10 Minuten verfügbar sein unter:"
echo "   Frontend: https://$SERVICE_NAME.onrender.com"
echo "   API: https://$API_SERVICE_NAME.onrender.com"
