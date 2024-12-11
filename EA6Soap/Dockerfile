# Utiliza una imagen base oficial de .NET 7 SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Establece el directorio de trabajo
WORKDIR /app

# Copia el archivo de proyecto y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia el resto de los archivos del proyecto
COPY . ./

# Publica la aplicación para producción
RUN dotnet publish -c Release -o /app/publish

# Usa una imagen base de .NET 7 Runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base

# Establece el directorio de trabajo
WORKDIR /app

# Copia la aplicación publicada desde la etapa anterior
COPY --from=build /app/publish .

# Expone el puerto en el que se ejecutará la aplicación
EXPOSE 80

# Define el comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "EA6Soap.dll"]