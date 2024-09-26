FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine as build
ARG PROJECT=src/AccountsManager.Api/
WORKDIR /app
COPY . .
RUN dotnet restore src/AccountsManager.Api
RUN dotnet build src/AccountsManager.Api -c Release --no-restore
RUN dotnet publish src/AccountsManager.Api -c Release -o /app/published-app --no-restore --no-build

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS run
WORKDIR /app
COPY --from=build /app/published-app /app
ENTRYPOINT [ "dotnet", "/app/AccountsManager.Api.dll" ]