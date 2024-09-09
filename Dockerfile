# Stage 1: Build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj file and restore dependencies
COPY ["TemporalTables/TemporalTables.csproj", "./TemporalTables/"]
WORKDIR /src/TemporalTables
RUN dotnet restore

# Now copy the rest of the application and build
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5095
ENV ASPNETCORE_URLS=http://+:5095
ENTRYPOINT ["dotnet", "TemporalTables.dll"]