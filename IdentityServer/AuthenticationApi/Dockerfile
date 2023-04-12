FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AuthenticationApi/AuthenticationApi.csproj", "AuthenticationApi/"]
RUN dotnet restore "AuthenticationApi/AuthenticationApi.csproj"
COPY . .
WORKDIR "/src/AuthenticationApi"
RUN dotnet build "AuthenticationApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthenticationApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthenticationApi.dll"]
