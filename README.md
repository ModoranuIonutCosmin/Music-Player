# WebAMP music player SaaS


## Summary
A web software solution that allows users to:
* Listen to music, just like on an app like Soundcloud / Spotify.
* Upload .mp3 music albums and share those with other people.
* Manage their playlist and add songs to favorites.
* Upgrade their subscription for getting bonus upload minutes.

## Demo
A *short* summary of all features is presented in the video below.
If you want to try the app yourself you can access [this](https://bit.ly/3itTdgA) deployed version which
may be slow at first operation due to it being hosted on a free development deployment slot,
app having to cold-start.

See the video below:

[![Demo](http://i.imgur.com/3XNG8t5.png)](https://bit.ly/3JBkJVu "WebAMP")

Alt: [click](https://bit.ly/3JBkJVu)

## Technologies

### Back end
- Web API using ASP .NET Core 6
- SQL Server and Entity Framework 5 for Persistence Layer
- AWS Toolkit for managing S3 cloud storage

### Front end
- Angular 13
- PWA for Angular
- Angular Nebular UI

## Architecture
* WebAPI hosted on Azure App service
* Azure SQL \w MS SQL SERVER
* Angular app on Azure Static Web app service.

### Back end
Backend is structured according to Onion (Clean architecture) and mediator pattern using MediatR:
* Domain project 
  - entities.
  - DTOs.
  - exceptions.
  - helpers - extension methods, general functionality used in every layer.

* Application layer:
  - a features folder where logic resides, for each functionality there exists a command and a command handler 
  - exposes infrastracture contracts (persistance layer repositories interfaces).
  - AutoMapper for swapping contracts between DB / models - mapping profiles folder

* Persistence layer:
  - Repository pattern.
  - Persistance provider versioning
  - registering a new ORM / SQL driver other than EF & SQL Server requires just creating a new implementation for some basic CRUD operations.
  - Utilizes repository pattern for accesing resources grouped by the DB Relation it queries/modifies.
  - Holds migrations folder

* API Presentation layer:
  - Uses IMediator from MediatR for passing work to command handlers
  - API Versioning.
  - ProblemDetails exceptions middleware for adding.

### Front end
Using a highly scalable standard folder structure.
* Core consists of Services, Interceptors, Directives, Pipes.
* Shared module for models and common components.
* All specific components are organized in modules.
  - lazy loading modules for reducing bundle size.
* Interceptors for exceptions handling (like API not responding for announcing user of the service unavailability),
retry interceptor for retrying failed status code 0 http calls, auth interceptor / unauthorized interceptor to rewrite requests to include user jwt token / redirect to login on token expiration or 401 reponse from any API call
