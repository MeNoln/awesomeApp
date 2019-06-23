FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["AspNetWebApiProj/AspNetWebApiProj.csproj", "AspNetWebApiProj/"]
COPY ["BisnessLogic/BisnessLogic.csproj", "BisnessLogic/"]
COPY ["DataAccessLayer/DataAccessLayer.csproj", "DataAccessLayer/"]
RUN dotnet restore "AspNetWebApiProj/AspNetWebApiProj.csproj"
COPY . .
WORKDIR "/src/AspNetWebApiProj"
RUN dotnet build "AspNetWebApiProj.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AspNetWebApiProj.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AspNetWebApiProj.dll"]
