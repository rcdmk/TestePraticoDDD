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

## History

This was originally built on .Net Framework 4.5, for Windows only, in 2015 and now ported to .Net Core 6.0 in 2022.

The major changes from the original project, appart from the obvious upgrades related to .Net Core, are:

1. **Ninject was removed** in favor of the existing .Net Core DI framework, as the use case is simple enough to be handled with that
2. **Added some tests** with xUnit to cover main domain logic
3. **Services layer was changed to gRPC** services instead of the previous WPF services
4. **Added Makefile** to streameline most common project tasks
5. **Added docker-compose.yml** for running additional services, like the MySQL 8 database server

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

That also includes downloading MySQL 8 docker image to make sure docker is correctly setup and speedup other steps.

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

## Application settings

Application settings are stored in `appsettings.json` files, with environment specific settings on `appsettings.${environment}.json` (eg: `appsettings.Development.json`).

## Project structure

The project structure is inspired on DDD (Domain Driven Design) approach, with layered or onion architecture, having the outer-most layers depending on inner-most layers and never the other way around.

The layers, presented in order of inner-most to outer-most:

### TestePratico.Domain

The most central layer, where business logic should live, is the `Domain` layer. This layer houses business entities, main data interfaces and the domain services, which are responsible for business logic.

This project should't depend on any other layer to have pure domain specific logic.

### TestePratico.Data

The `Data` layer, where the storage related code lies, with the respository implementations, entity configuration and migrations for EntityFramework.

This layer depends on the `Domain` layer and possibly `Common`.

### TestePratico.Application

The `Application` layer contains the common application logic in application services that consume domain services to perform its operations. This layer is meant to be reused by any application that is built on top of the inner layers, like web applications, APIs, gRPC services or command-line interfaces.

This layer depends on the `Domain` layer and possibly `Common`. Although it works with repositories, it relies on interfaces and not the implementations from the `Data` layer.

### TestePratico.Services

The `Services` layer is an example of gRPC server application that makes use of the `Application` services to perform CRUD operations.

In development mode, this server offers server reflection to make it easier to test it with gRPC enalbed tools, like Postman.

It's protobuf definitions are stored in the `TestePratico.Services/Protos` folder and can be used to generate client applications for it.

This layer depends on `Domain`, `Application` and possibly `Common` layers.

### TestePratico.Web

The `Web` application layer is an example of UI application that is built on top of the `Application` services layer to perform CRUD operations on entities, using an MVC project structure for proper separation of concerns and easy maintainability.

This layer depends on `Domain`, `Application` and possibly `Common` layers.

### TestePratico.Common

The `Common` cross-cutting concerns layer, where all logic that is not domain-specific and can be used in multiple layers should reside. Things like custom libraries, IoC/DI mappings, loggers, wrappers for utility tools, etc., must be implemented in this project.

This layer shouldn't depend on other layers, but the `Domain` one, to avoid cyclic dependency issues.
