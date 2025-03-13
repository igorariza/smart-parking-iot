# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SmartParkingLotManagement.csproj", "./"]
RUN dotnet restore "./SmartParkingLotManagement.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SmartParkingLotManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartParkingLotManagement.csproj" -c Release -o /app/publish

# Use the runtime image to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD [ "donet", "run", "SmartParkingLotManagement.dll" ]