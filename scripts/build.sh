#!/bin/bash

# Build-Skript für das Digitale Schulverwaltungssystem

echo "🏗️  Building Digitales Schulverwaltungssystem..."

# Build Backend Services
echo "📦 Building Backend Services..."
dotnet build src/Backend/Services/AuthService/AuthService.csproj -c Release
dotnet build src/Backend/Services/HomeworkService/HomeworkService.csproj -c Release

# Build Frontend
echo "🎨 Building Frontend..."
dotnet build src/Frontend/Web/SchulverwaltungWeb.csproj -c Release

# Build Docker Images
echo "🐳 Building Docker Images..."
docker-compose build

echo "✅ Build completed successfully!"
