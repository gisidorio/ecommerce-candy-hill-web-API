# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EcommerceCandyHill.API/EcommerceCandyHill.API.csproj", "EcommerceCandyHill.API/"]
COPY ["EcommerceCandyHill.Application/EcommerceCandyHill.Application.csproj", "EcommerceCandyHill.Application/"]
COPY ["EcommerceCandyHill.Domain/EcommerceCandyHill.Domain.csproj", "EcommerceCandyHill.Domain/"]
COPY ["EcommerceCandyHill.Infra.Data/EcommerceCandyHill.Infra.Data.csproj", "EcommerceCandyHill.Infra.Data/"]
RUN dotnet restore "./EcommerceCandyHill.API/EcommerceCandyHill.API.csproj"
COPY . .
WORKDIR "/src/EcommerceCandyHill.API"
RUN dotnet build "./EcommerceCandyHill.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EcommerceCandyHill.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EcommerceCandyHill.API.dll"]