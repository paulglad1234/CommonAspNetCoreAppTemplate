#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["System/Api/Api.csproj", "System/Api/"]
COPY ["Data/Db.Entities/Db.Entities.csproj", "Data/Db.Entities/"]
COPY ["Data/Db.Context/Db.Context.csproj", "Data/Db.Context/"]
COPY ["Services/Settings/Settings.csproj", "Services/Settings/"]
COPY ["Shared/Common/Common.csproj", "Shared/Common/"]
RUN dotnet restore "System/Api/Api.csproj"
COPY . .
WORKDIR "/src/System/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]