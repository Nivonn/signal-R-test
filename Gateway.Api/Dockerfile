FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app 
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src 

COPY ["./Gateway.Api/Gateway.Api/Gateway.Api.csproj", "TelemetryStudy/Gateway.Api/Gateway.Api/"]


RUN dotnet restore "TelemetryStudy/Gateway.Api/Gateway.Api/Gateway.Api.csproj"
COPY . ./TelemetryStudy
WORKDIR "/src/TelemetryStudy"
RUN dotnet build "./Gateway.Api/Gateway.Api/Gateway.Api.csproj" -c Release -o /app/build/

FROM build AS publish
WORKDIR "/src/TelemetryStudy/Gateway.Api/Gateway.Api"
RUN dotnet publish "Gateway.Api.csproj" -c Release -o /app/publish/

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gateway.Api.dll"]