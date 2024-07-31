# Use a imagem base do SDK do .NET para compilar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copie o arquivo de projeto e restaure as dependências
COPY *.csproj ./
RUN dotnet restore

# Copie o restante dos arquivos e compile o aplicativo
COPY . ./
RUN dotnet publish -c Release -o out

# Use a imagem base do runtime do .NET para executar o aplicativo
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Configure a globalização para não ser invariável
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "SeuApp.dll"]
