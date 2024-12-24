FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Develop
WORKDIR /src
COPY ["url-shortener.api/url-shortener.api.csproj", "url-shortener.api/"]
COPY ["url-shortener.core/url-shortener.application.csproj", "url-shortener.core/"]
COPY ["url-shortener.infrastructure/url-shortener.infrastructure.csproj", "url-shortener.infrastructure/"]
RUN dotnet restore "url-shortener.api/url-shortener.api.csproj"
COPY . .
WORKDIR "/src/url-shortener.api"
RUN dotnet build "url-shortener.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Develop
RUN dotnet publish "url-shortener.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "url-shortener.api.dll"]
