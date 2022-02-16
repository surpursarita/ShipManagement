#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Task.ShipManagement.API/Task.ShipManagement.API.csproj", "Task.ShipManagement.API/"]
RUN dotnet restore "Task.ShipManagement.API/Task.ShipManagement.API.csproj"
COPY . .
WORKDIR "/src/Task.ShipManagement.API"
RUN dotnet build "Task.ShipManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Task.ShipManagement.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Task.ShipManagement.API.dll"]