# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

## Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER app
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081


# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["Services/Productos/Productos.Api/Productos.Api.csproj", "Services/Productos/Productos.Api/"]
#RUN dotnet restore "./Services/Productos/Productos.Api/Productos.Api.csproj"
#COPY . .
#WORKDIR "/src/Services/Productos/Productos.Api"
#RUN dotnet build "./Productos.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
## Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./Productos.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Productos.Api.dll"]

WORKDIR /src
COPY ["Services/Productos/Productos.DB/Productos.DB.sqlproj", "Services/Productos/Productos.DB/"]
RUN dotnet restore "./Services/Productos/Productos.DB/Productos.DB.sqlproj"
COPY . .
WORKDIR "/src/Services/Productos/Productos.DB"
RUN dotnet build "./Productos.DB.sqlproj" -c $BUILD_CONFIGURATION -o /app/build 


FROM mcr.microsoft.com/mssql/server:2022-latest AS final

### Install Unzip
RUN apt-get update \
    && apt-get install unzip -y

### Install SQLPackage for Linux and make it executable
RUN wget -progress=bar:force -q -O sqlpackage.zip https://go.microsoft.com/fwlink/?linkid=873926 \
    && unzip -qq sqlpackage.zip -d /opt/sqlpackage \
    && chmod +x /opt/sqlpackage/sqlpackage

### Add the DACPAC to the image
COPY --from=build /app/build/Productos.DB.dacpac /tmp/db.dacpac

### Configure external build arguments to allow configurability.
###ARG DBNAME
##ARG SAPASSWORD
RUN echo "hello10"
### Configure the required environmental variables
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=$SAPASSWORD

RUN /opt/mssql-tools/bin/sqlcmd -S sqlserverdocker,8006 -U sa -P MyPassword*1234 -Q "CREATE DATABASE Productos.DB"

# Launch SQL Server, confirm startup is complete, deploy the DACPAC, then terminate SQL Server.
# See https://stackoverflow.com/a/51589787/488695
RUN ( /opt/mssql/bin/sqlservr & ) | grep -q "Service Broker manager has started" \
    && /opt/sqlpackage/sqlpackage /a:Publish /tsn:sqlserverdocker /tdn:Productos.DB /tu:sa /tp:MyPassword*1234 /sf:/tmp/db/db.dacpac \
    && rm -r /tmp/db \
    && pkill sqlservr \
    && rm -r /opt/sqlpackage

    RUN echo "hello"
