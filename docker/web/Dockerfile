FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY DentistryBusinessObjects/*.csproj ./DentistryBusinessObjects/
COPY DTOs/*.csproj ./DTOs/
COPY DentistryRepositories/*.csproj ./DentistryRepositories/
COPY DentistryServices/*.csproj ./DentistryServices/
COPY Search/*.csproj ./Search/
COPY Firebase/*.csproj ./Firebase/
COPY prn-dentistry/*.csproj ./prn-dentistry/
RUN dotnet restore --use-current-runtime

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY --from=build-env /app/out .

# Verify the presence of prn_project.dll
RUN ls -al /app

ENTRYPOINT ["dotnet", "prn-dentistry.dll"]
