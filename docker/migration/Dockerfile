FROM mcr.microsoft.com/dotnet/sdk:7.0 AS migration-build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
RUN ls -al

COPY *.sln ./
COPY DentistryBusinessObjects/*.csproj ./DentistryBusinessObjects/
COPY DTOs/*.csproj ./DTOs/
COPY DentistryRepositories/*.csproj ./DentistryRepositories/
COPY DentistryServices/*.csproj ./DentistryServices/
COPY Search/*.csproj ./Search/
COPY Firebase/*.csproj ./Firebase/
COPY prn-dentistry/config/*.json ./prn-dentistry/config/
COPY prn-dentistry/*.csproj ./prn-dentistry/
RUN dotnet restore --use-current-runtime

# Copy everything else and build
COPY . ./

RUN apt-get update
RUN apt-get install -y make  

ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet tool install --version 7.0.19 --global dotnet-ef
RUN ls -al 
RUN echo "**********   $GOOGLE_APPLICATION_CREDENTIALS_JSON"
RUN dotnet ef migrations bundle --force --project prn-dentistry -r linux-x64 --verbose --self-contained --output efbundle

# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY --from=migration-build-env /app/efbundle .
COPY --from=migration-build-env /app/Makefile .

# Verify the presence of prn_project.dll
RUN ls -al /app

RUN apt-get update
RUN apt-get install -y make  
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet tool install --version 7.0.19 --global dotnet-ef

ENTRYPOINT [ "make" ]
CMD [ "update" ]

