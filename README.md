# DDD structure project

[![Build status](https://ci.appveyor.com/api/projects/status/799cc3qwne3d6el0?svg=true)](https://ci.appveyor.com/project/rcdmk/testepraticoddd)

This project uses many development patterns as learning model:

* DDD - Domain Driven Design inspired structure
* SelfValidation - Entities have auto-validation and are responsible for their own business rules validity state.
* Repository - The data layer communication is done through repositories
* Application Services - Data access is done through application services that can be reused by different applications (eg. Web and gRPC Services)
* AutoMapper - Mapping from entities to and from view models and DTOs is handled by AutoMapper
* IoC - Dependency injection is handled by .Net Core DI framework
* Makefile - Easier to remember commands to execute common tasks
* ... (more to come)

## Prerequisites

* [dotnet 6.0+ command-line tool](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [Doker](https://www.docker.com/)

## Make a friend

The command-line tool `make` is your friend here. Make sure to explore the available targets.

The most common ones will be listed bellow.

> **Tip❗** All make commands need to be run from the project's root folder (where the Makefile file is located).

## Installing dependencies

Dependencies are managed through the `dotnet` command-line tool and all of them can be installed with:

```sh
make deps
```

That also includes downloading

## Preparing the database

This project uses EntityFramework code-first approach and code migrations to generate and update the database.

To run the project for the first time, it is necessary to have a MySQL server running to apply migrations before the application can be started:

```sh
# runs a MySQL 8 container in a non-interactive/non-blocking way
make start-database

# generate database schema, tables and seed data
make update-database
```

The easiest way to see the database contents via command-line is to run the `mysql` tool within the container:

```sh
$ docker-compose exec -it mysql mysql -uroot -proot

mysql> USE TestePraticoDB;
mysql> SHOW TABLES;
mysql> SELECT * FROM __EFMigrationsHistory;
```

> **Tip❗** The database server can be accessed through the localhost port `3306`. Depending on OS version and settings, it may be required to target the localhost IP address `127.0.0.1` or the unspecified address IP address `0.0.0.0` instad of using `localhost`.

## Running the code

There are two ways of running the two applications, Web and gRPC services, and both are available through Makefile targets:

**Local development with hot-reload:**

```sh
# start the web application in watch mode, with hot-reload enabled
make watch-web

# start the gRPC services application in watch mode, with hot-reload enabled
make watch-services
```

**Running them locally in development mode:**

```sh
# start web application in development mode
make start-web

# start gRPC services in development mode
make start-services
```

> **Tip❗** All previous commands are blocking, so you may want to start them in a separate terminal window.

## Running tests

```sh
make tests
```
