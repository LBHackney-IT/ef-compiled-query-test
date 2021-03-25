FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

ENV DynamoDb_LocalMode='true'

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./EfTestApi.sln ./
COPY ./EfTestApi/EfTestApi.csproj ./EfTestApi/
COPY ./EfTestApi.Tests/EfTestApi.Tests.csproj ./EfTestApi.Tests/

RUN dotnet restore ./EfTestApi/EfTestApi.csproj
RUN dotnet restore ./EfTestApi.Tests/EfTestApi.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out EfTestApi.Tests/EfTestApi.Tests.csproj

CMD dotnet test
