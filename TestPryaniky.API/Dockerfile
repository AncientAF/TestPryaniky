FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TestPryaniky.API/TestPryaniky.API.csproj", "TestPryaniky.API/"]
COPY ["TestPryaniky.Application/TestPryaniky.Application.csproj", "TestPryaniky.Application/"]
COPY ["TestPryaniky.Core/TestPryaniky.Core.csproj", "TestPryaniky.Core/"]
COPY ["TestPryaniky.Infrastructure/TestPryaniky.Infrastructure.csproj", "TestPryaniky.Infrastructure/"]
RUN dotnet restore "TestPryaniky.API/TestPryaniky.API.csproj"
COPY . .
WORKDIR "/src/TestPryaniky.API"
RUN dotnet build "TestPryaniky.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TestPryaniky.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestPryaniky.API.dll"]
