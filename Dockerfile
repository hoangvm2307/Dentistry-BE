# Use the official .NET Core SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY DentistryBusinessObjects/*.csproj ./DentistryBusinessObjects/
COPY DTOs/*.csproj ./DTOs/
COPY DentistryRepositories/*.csproj ./DentistryRepositories/
COPY DentistryServices/*.csproj ./DentistryServices/
COPY prn-dentistry/*.csproj ./prn-dentistry/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

# Verify the presence of prn_project.dll
RUN ls -al /app

ENTRYPOINT ["dotnet", "prn_project.dll"]
