# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5200
EXPOSE 5201


# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Ventas/Ventas.Api/Ventas.Api.csproj", "Services/Ventas/Ventas.Api/"]
COPY ["Services/Ventas/Ventas.Application/Ventas.Application.csproj", "Services/Ventas/Ventas.Application/"]
COPY ["Services/Ventas/Ventas.Domain/Ventas.Domain.csproj", "Services/Ventas/Ventas.Domain/"]
COPY ["Services/Ventas/Ventas.Infraestructure/Ventas.Infraestructure.csproj", "Services/Ventas/Ventas.Infraestructure/"]
COPY ["Services/Ventas/Ventas.Presentation/Ventas.Presentation.csproj", "Services/Ventas/Ventas.Presentation/"]
RUN dotnet restore "./Services/Ventas/Ventas.Api/Ventas.Api.csproj"
COPY . .
WORKDIR "/src/Services/Ventas/Ventas.Api"
RUN dotnet build "./Ventas.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ventas.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ventas.Api.dll"]