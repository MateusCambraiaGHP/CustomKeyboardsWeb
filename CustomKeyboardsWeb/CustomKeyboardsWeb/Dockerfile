# Use the SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the project files
COPY ["CustomKeyboardsWeb/CustomKeyboardsWeb.csproj", "../"]
COPY ["CustomKeyboardsWeb.Application/CustomKeyboardsWeb.Application.csproj", "CustomKeyboardsWeb.Application/"]
COPY ["CustomKeyboardsWeb.Core/CustomKeyboardsWeb.Core.csproj", "CustomKeyboardsWeb.Core/"]
COPY ["CustomKeyboardsWeb.Data/CustomKeyboardsWeb.Data.csproj", "CustomKeyboardsWeb.Data/"]
COPY ["CustomKeyboardsWeb.Domain/CustomKeyboardsWeb.Domain.csproj", "CustomKeyboardsWeb.Domain/"]
COPY ["CustomKeyboardsWeb.Infrastructure/CustomKeyboardsWeb.Infrastructure.csproj", "CustomKeyboardsWeb.Infrastructure/"]

# Copy the entire project into the container
COPY . .

# Build the project
WORKDIR "/src/CustomKeyboardsWeb"
RUN dotnet build "CustomKeyboardsWeb.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "CustomKeyboardsWeb.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the ASP.NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

# Install necessary tools for waiting
RUN apt-get update && apt-get install -y curl

# Copy the published application
COPY --from=publish /app/publish .

# Copy the script for waiting
COPY wait-for-mysql.sh /wait-for-mysql.sh
RUN chmod +x /wait-for-mysql.sh

# Entry point for the application
CMD /wait-for-mysql.sh && dotnet CustomKeyboardsWeb.dll
