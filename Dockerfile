FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["OmgShoes/OmgShoes.csproj", "OmgShoes/"]
RUN dotnet restore "OmgShoes/OmgShoes.csproj"
COPY . .
WORKDIR "/src/OmgShoes"
RUN dotnet build "OmgShoes.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OmgShoes.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OmgShoes.dll"]
