FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /out ./


EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000


ENTRYPOINT ["dotnet", "SmartParkingLotManagement.dll"]
