# Stage 1: Build the .NET 6 Web API
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the .csproj file to restore dependencies
COPY MyDotNetApp.csproj ./

# Restore the dependencies
RUN dotnet restore

# Copy the remaining application code
COPY . .

# Build the application
RUN dotnet build -c Release --no-restore

# Publish the application
RUN dotnet publish -c Release -o /app --no-restore

# Stage 2: Create a runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# Expose the port your Web API listens on (change 80 to your specific port if needed)
EXPOSE 80

# Set the entry point for your Web API
ENTRYPOINT ["dotnet", "MyDotNetApp.dll"]
