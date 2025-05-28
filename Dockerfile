# Build stage for Auth Service
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-auth
WORKDIR /src
COPY ["src/Backend/Services/AuthService/AuthService.csproj", "Services/AuthService/"]
COPY ["src/Backend/Shared/Shared.Models.csproj", "Shared/"]
RUN dotnet restore "Services/AuthService/AuthService.csproj"
COPY src/Backend/ .
WORKDIR "/src/Services/AuthService"
RUN dotnet build "AuthService.csproj" -c Release -o /app/build

FROM build-auth AS publish-auth
RUN dotnet publish "AuthService.csproj" -c Release -o /app/publish

# Build stage for Homework Service
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-homework
WORKDIR /src
COPY ["src/Backend/Services/HomeworkService/HomeworkService.csproj", "Services/HomeworkService/"]
COPY ["src/Backend/Shared/Shared.Models.csproj", "Shared/"]
RUN dotnet restore "Services/HomeworkService/HomeworkService.csproj"
COPY src/Backend/ .
WORKDIR "/src/Services/HomeworkService"
RUN dotnet build "HomeworkService.csproj" -c Release -o /app/build

FROM build-homework AS publish-homework
RUN dotnet publish "HomeworkService.csproj" -c Release -o /app/publish

# Build stage for Frontend
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-frontend
WORKDIR /src
COPY ["src/Frontend/Web/SchulverwaltungWeb.csproj", "Frontend/Web/"]
RUN dotnet restore "Frontend/Web/SchulverwaltungWeb.csproj"
COPY src/Frontend/ ./Frontend/
WORKDIR "/src/Frontend/Web"
RUN dotnet publish "SchulverwaltungWeb.csproj" -c Release -o /app/publish

# Runtime stage - Using Nginx for frontend
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build-frontend /app/publish/wwwroot .
COPY deploy/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
