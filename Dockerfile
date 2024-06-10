FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY DentistryBusinessObjects/*.csproj ./DentistryBusinessObjects/
COPY DTOs/*.csproj ./DTOs/
COPY DentistryRepositories/*.csproj ./DentistryRepositories/
COPY DentistryServices/*.csproj ./DentistryServices/
COPY prn-dentistry/*.csproj ./prn-dentistry/
RUN dotnet restore --use-current-runtime

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

RUN apt-get update
RUN apt-get install -y make  

ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet tool install --version 7.0.19 --global dotnet-ef

RUN dotnet ef migrations bundle --force --project prn-dentistry -r linux-x64 --verbose --self-contained --output efbundle
# --target-runtime linux-x64

# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY --from=build-env /app/efbundle .
COPY --from=build-env /app/out .
COPY --from=build-env /app/Makefile .

# Verify the presence of prn_project.dll
RUN ls -al /app

RUN apt-get update
RUN apt-get install -y make  
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet tool install --version 7.0.19 --global dotnet-ef


# ENTRYPOINT [ "make" ]
# CMD [ "update" ]

ENTRYPOINT ["dotnet", "prn-dentistry.dll"]
# CMD dotnet ef database update --project prn-dentistry
