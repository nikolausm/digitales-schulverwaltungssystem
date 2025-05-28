#!/usr/bin/env python3
"""
Render.com Automated Deployment Script
Automatisiert das Deployment des Schulverwaltungssystems
"""

import os
import sys
import json
import time
import requests
from typing import Dict, Optional

class RenderDeployer:
    def __init__(self, api_key: str):
        self.api_key = api_key
        self.base_url = "https://api.render.com/v1"
        self.headers = {
            "Authorization": f"Bearer {api_key}",
            "Content-Type": "application/json"
        }
        
    def get_user_info(self) -> Dict:
        """Hole Benutzerinformationen"""
        response = requests.get(f"{self.base_url}/owners", headers=self.headers)
        if response.status_code == 200:
            owners = response.json()
            if owners:
                return owners[0]['owner']
        return None
        
    def create_web_service(self, name: str, dockerfile: str, env_vars: Dict = None) -> Optional[str]:
        """Erstelle einen Web Service"""
        user = self.get_user_info()
        if not user:
            print("❌ Konnte Benutzerinformationen nicht abrufen")
            return None
            
        payload = {
            "type": "web_service",
            "name": name,
            "ownerId": user['id'],
            "repo": "https://github.com/nikolausm/digitales-schulverwaltungssystem",
            "autoDeploy": "yes",
            "branch": "main",
            "serviceDetails": {
                "env": "docker",
                "dockerfilePath": f"./{dockerfile}",
                "dockerContext": ".",
                "region": "frankfurt",
                "plan": "free",
                "envVars": []
            }
        }
        
        # Füge Umgebungsvariablen hinzu
        if env_vars:
            for key, value in env_vars.items():
                payload["serviceDetails"]["envVars"].append({
                    "key": key,
                    "value": str(value)
                })
                
        response = requests.post(
            f"{self.base_url}/services", 
            headers=self.headers, 
            json=payload
        )
        
        if response.status_code == 201:
            service = response.json()
            return service['service']['id']
        else:
            print(f"❌ Fehler: {response.status_code} - {response.text}")
            return None

    def create_postgres_db(self, name: str) -> Optional[str]:
        """Erstelle eine PostgreSQL Datenbank"""
        user = self.get_user_info()
        if not user:
            return None
            
        payload = {
            "type": "private_service",
            "name": name,
            "ownerId": user['id'],
            "repo": "https://github.com/render-examples/postgresql",
            "autoDeploy": "yes",
            "branch": "main",
            "serviceDetails": {
                "env": "docker",
                "envVars": [
                    {"key": "POSTGRES_DB", "value": "schulverwaltung"},
                    {"key": "POSTGRES_USER", "value": "schuladmin"},
                    {"key": "POSTGRES_PASSWORD", "generateValue": True}
                ],
                "disk": {
                    "name": f"{name}-data",
                    "mountPath": "/var/lib/postgresql/data"
                }
            }
        }
        
        response = requests.post(
            f"{self.base_url}/services", 
            headers=self.headers, 
            json=payload
        )
        
        if response.status_code == 201:
            return response.json()['service']['id']
        return None

def main():
    print("🚀 Render.com Automatisches Deployment")
    print("=====================================")
    
    # API Key prüfen
    api_key = os.environ.get('RENDER_API_KEY')
    if not api_key:
        print("\n❌ RENDER_API_KEY nicht gefunden!")
        print("\nSo erhalten Sie Ihren API Key:")
        print("1. Gehen Sie zu: https://dashboard.render.com/account/api-keys")
        print("2. Klicken Sie 'Create API Key'")
        print("3. Setzen Sie: export RENDER_API_KEY='Ihr-Key-Hier'")
        sys.exit(1)
        
    deployer = RenderDeployer(api_key)
    
    print("\n🔍 Prüfe API-Verbindung...")
    user = deployer.get_user_info()
    if user:
        print(f"✅ Verbunden als: {user.get('email', 'Unbekannt')}")
    else:
        print("❌ Verbindung fehlgeschlagen")
        sys.exit(1)
        
    # Services erstellen
    print("\n📦 Erstelle Services...")
    
    # Frontend
    print("\n1️⃣ Frontend Service...")
    frontend_id = deployer.create_web_service(
        "schulverwaltung-frontend",
        "Dockerfile.frontend",
        {"PORT": "10000"}
    )
    if frontend_id:
        print(f"✅ Frontend erstellt: https://schulverwaltung-frontend.onrender.com")
        
    # API
    print("\n2️⃣ API Service...")
    api_id = deployer.create_web_service(
        "schulverwaltung-api",
        "Dockerfile.api",
        {
            "PORT": "10000",
            "ASPNETCORE_ENVIRONMENT": "Production"
        }
    )
    if api_id:
        print(f"✅ API erstellt: https://schulverwaltung-api.onrender.com")
        
    print("\n🎉 Deployment gestartet!")
    print("\n📊 Verfolgen Sie den Fortschritt:")
    print("   https://dashboard.render.com")
    print("\n⏱️  Services sind in 5-10 Minuten verfügbar")

if __name__ == "__main__":
    main()
