# DDD structure project

[![Build status](https://ci.appveyor.com/api/projects/status/799cc3qwne3d6el0?svg=true)](https://ci.appveyor.com/project/rcdmk/testepraticoddd)

This project uses diverse development patterns as learning model:

* DDD - Domain oriented architecture
* SelfValidation - Entities have auto-validation and are responsible for their own business rules validity state.
* Repository - The data layer communication is done through repositories
* Application Services - Data access is done through application services that can be reused by different applications (eg. Web and gRPC Services)
* AutoMapper - Mapping from entities to and from view models and DTOs is handled by AutoMapper
* IoC - Dependency injection is handled by .Net Core DI framework
* ... (more to come)
