#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["docker_compose/docker_compose.csproj", "docker_compose/"]
RUN dotnet restore "docker_compose/docker_compose.csproj"
COPY . .
WORKDIR "/src/docker_compose"
RUN dotnet build "docker_compose.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "docker_compose.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "docker_compose.dll"]