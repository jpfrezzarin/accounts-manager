# Accounts Manager

A domestic accounts manager sample.

## 1 - Stack

- [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (to build/test locally and run the app)
- [SQLite 3](https://www.sqlite.org/download.html) (to store app data/database)
- [Docker](https://docs.docker.com/get-docker/) (optional way to run the app)

## 2 - Create database

To create the database, run the command bellow in repository directory:

```
sqllite3 database.db
```

After entering in the sqlite application, read the initial script in `script.sql` file, running the command:

```
sqlite> .read script.sql
```

## 3 - Run the application

> NOTE: The app will be exposed in port 8080. Access the API swagger by  link http://localhost:8080/swagger/index.html

### 3.1 - via docker

To run the application via docker, run the command bellow in repository directory:

```
docker compose up
```

The compose command will automatically build the image with `accounts-manager:latest` tag. The image also could be built running the command:

```
docker build -f Dockerfile -t accounts-manager:latest .
```

### 3.1 - via .NET sdk

To run the application via .NET, run the command bellow in repository directory:

```
dotnet run --project ./src/AccountsManager.Api 
```

## 4 - Run tests

To run unit tests, run the command bellow in repository directory:

```
dotnet test 
```