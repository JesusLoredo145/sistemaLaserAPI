FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["sistemaLaserAPI.csproj", "./"]
RUN dotnet restore "sistemaLaserAPI.csproj"
COPY . .
RUN dotnet publish "sistemaLaserAPI.csproj" -c Release -o /app/publish --no-restore
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000
ENTRYPOINT ["dotnet", "sistemaLaserAPI.dll"]