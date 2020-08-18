#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["InMemoryIdentityApp/InMemoryIdentityApp.csproj", "InMemoryIdentityApp/"]
COPY ["BlazorApp2/BlazorApp2.csproj", "BlazorApp2/"]
COPY ["BazorAuth.Shared/BazorAuth.Shared.csproj", "BazorAuth.Shared/"]
COPY ["ClientSideAuth/ClientSideAuth.csproj", "ClientSideAuth/"]
COPY ["StockTicker.Service/StockTicker.Service.csproj", "StockTicker.Service/"]
COPY ["Identity.Contrib.InMemoryStore/Identity.Contrib.InMemoryStore.csproj", "Identity.Contrib.InMemoryStore/"]
COPY ["BlazorAppRealTime/BlazorAppRealTime.csproj", "BlazorAppRealTime/"]
COPY ["Serilog.Enricher.CorrelationId/Serilog.Enrichers.csproj", "Serilog.Enricher.CorrelationId/"]
RUN dotnet restore "InMemoryIdentityApp/InMemoryIdentityApp.csproj"
COPY . .
WORKDIR "/src/InMemoryIdentityApp"
RUN dotnet build "InMemoryIdentityApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InMemoryIdentityApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InMemoryIdentityApp.dll"]