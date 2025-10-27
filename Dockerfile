# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos csproj de todos os projetos
COPY EcommerceCandyHill.API/*.csproj EcommerceCandyHill.API/
COPY EcommerceCandyHill.Services/*.csproj EcommerceCandyHill.Services/
COPY EcommerceCandyHill.Infra.Data/*.csproj EcommerceCandyHill.Infra.Data/

# Restaura dependências apenas do projeto principal
RUN dotnet restore EcommerceCandyHill.API/EcommerceCandyHill.API.csproj

# Copia todo o código
COPY . .

# Publica a API
RUN dotnet publish EcommerceCandyHill.API/EcommerceCandyHill.API.csproj -c Debug -o /app/out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copia o resultado da build
COPY --from=build /app/out .

# Configura Kestrel para ouvir na porta 80
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
EXPOSE 80

# Executa a aplicação
ENTRYPOINT ["dotnet", "EcommerceCandyHill.API.dll"]
