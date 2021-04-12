#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ArchShop.WebFrontend/ArchShop.WebFrontend.csproj", "ArchShop.WebFrontend/"]
RUN dotnet restore "ArchShop.WebFrontend/ArchShop.WebFrontend.csproj"
COPY . .
WORKDIR "/src/ArchShop.WebFrontend"
RUN dotnet build "ArchShop.WebFrontend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArchShop.WebFrontend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArchShop.WebFrontend.dll"]