FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 9090
EXPOSE 9091

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["eCommerce.Api/eCommerce.Api.csproj", "eCommerce.Api/"]
RUN dotnet restore "eCommerce.Api/eCommerce.Api.csproj"
COPY . .
WORKDIR "/src/eCommerce.Api"
RUN dotnet build "./eCommerce.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./eCommerce.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
ENV POSTGRES_HOST=localhost
ENV POSTGRES_PASSWORD=Legion13$%
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eCommerce.Api.dll"]
