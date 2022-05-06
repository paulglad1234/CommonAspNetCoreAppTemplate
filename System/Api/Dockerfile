#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["System/Api/Template.Api.csproj", "System/Api/"]
COPY ["Shared/Common/Template.Common.csproj", "Shared/Common/"]
COPY ["Data/Db.Entities/Template.Db.Entities.csproj", "Data/Db.Entities/"]
COPY ["Data/Db.Context/Template.Db.Context.csproj", "Data/Db.Context/"]
COPY ["Services/Settings/Template.Settings.csproj", "Services/Settings/"]
RUN dotnet restore "System/Api/Template.Api.csproj"
COPY . .
WORKDIR "/src/System/Api"
RUN dotnet build "Template.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Template.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Template.Api.dll"]