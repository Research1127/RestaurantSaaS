# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only project files first (to cache dependencies)
COPY Rider/Restaurants.Api/Restaurants.Api/*.csproj Restaurants.Api/
COPY Rider/Restaurants.Api/Restaurants.Application/*.csproj Restaurants.Application/
COPY Rider/Restaurants.Api/Restaurants.Domain/*.csproj Restaurants.Domain/
COPY Rider/Restaurants.Api/Restaurants.Infrastructure/*.csproj Restaurants.Infrastructure/

RUN dotnet restore Restaurants.Api/Restaurants.Api.csproj

# Copy all other files
COPY . .

# Publish app
RUN dotnet publish Rider/Restaurants.Api/Restaurants.Api/Restaurants.Api.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Restaurants.Api.dll"]