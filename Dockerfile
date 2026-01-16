# 1. Base Image (Run)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 9090
EXPOSE 9091

# Force the app to listen on port 9090
ENV ASPNETCORE_URLS=http://+:9090

# 2. Build Image (Compile)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy CSPROJ files first (for caching)
COPY ["eCommerce.Api/eCommerce.Api.csproj", "eCommerce.Api/"]
COPY ["eCommerce.Application/eCommerce.Application.csproj", "eCommerce.Application/"]
COPY ["eCommerce.Domain/eCommerce.Domain.csproj", "eCommerce.Domain/"]
COPY ["eCommerce.infrastructure/eCommerce.infrastructure.csproj", "eCommerce.infrastructure/"]

# Restore dependencies
RUN dotnet restore "eCommerce.Api/eCommerce.Api.csproj"

# Copy the rest of the source code (BUT ignores bin/obj because of .dockerignore)
COPY . .

# Build
WORKDIR "/src/eCommerce.Api"
RUN dotnet build "eCommerce.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "eCommerce.Api.csproj" -c $BUILD_CONFIdocGURATION -o /app/publish /p:UseAppHost=false

# 3. Final Image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eCommerce.Api.dll"]