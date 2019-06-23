FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

ENV TZ=Europe/Moscow
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["MvcWebApp/MvcWebApp.csproj", "MvcWebApp/"]
COPY ["BisnessLogic/BisnessLogic.csproj", "BisnessLogic/"]
COPY ["DataAccessLayer/DataAccessLayer.csproj", "DataAccessLayer/"]
RUN dotnet restore "MvcWebApp/MvcWebApp.csproj"
COPY . .
WORKDIR "/src/MvcWebApp"
RUN dotnet build "MvcWebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MvcWebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MvcWebApp.dll"]
