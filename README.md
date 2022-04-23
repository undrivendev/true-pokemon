NOTE: this project has a level of complexity that I wouldn't necessarily recommend for an API with simple requirements like this one: this is meant to showcase how I would approach building a solution for a reasonably-sized project.

The project is based on the template I'm building [on my other repo](https://github.com/undrivendev/template-webapi-aspnet).

## What is it?
This is showcase project exposing a single API that, given a pokemon name,  will return a description in 'Shakespearean' terms.

### Example

Request: 

`GET http://localhost:5000/pokemon/pikachu`

Response:
```
{
  "name": "pikachu",
  "translation": "At which hour several of these pokémon gather,  their electricity couldst buildeth and cause lightning storms."
}
```

## How to run this project
- Clone the repo
- Run it:
  - Run with an IDE:
    - Install Visual Studio or Rider.
    - Just open the `TruePokemon.sln` file and run the `TruePokemon.Api.csproj` project, it should start listening on the port `5000`
  - Run with Docker:
    - Install Docker
    - Via terminal, cd into the solution folder and Build the image via   `docker build -t true-pokemon -f src/TruePokemon.Api/Dockerfile .`
    - Run it with: `docker run -p 5000:5000 true-pokemon`
- Test it using the built-in Swagger documentation at `http://localhost:5000/swagger/index.html`
- You should clone [the frontend repo](https://github.com/undrivendev/true-pokemon-react-app) and use it together

## Features
- Project structure following [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) principles
- Based on .NET 6 for Long Term Support
- Simplified .NET 6 startup hosting model
- OpenAPI documentation generated automatically via `Swagger`
- [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) with full separation between Read and Write repositories
- Simple [Mediator](https://en.wikipedia.org/wiki/Mediator_pattern) abstraction for CQRS and no-magic, in-memory implementation relying on the standard `IServiceProvider` DI container abstraction (~50 lines of code)
- [SimpleInjector](https://github.com/simpleinjector/SimpleInjector) open-source DI container integration for advanced service registration scenarios
- [Aspect-oriented programming](https://en.wikipedia.org/wiki/Aspect-oriented_programming) using [Decorators](https://en.wikipedia.org/wiki/Decorator_pattern) on the above-mentioned mediator
  - [Logging](src/WebApiTemplate.Application/CommandHandlerLoggingDecorator.cs)
  - [Caching](src/WebApiTemplate.Application/QueryHandlerCachingDecorator.cs)
- Resilient `HttpClient` instances with exponential backoff + jitter retry policy using Polly
- Structured logging using the standard [MEL](https://github.com/dotnet/runtime/tree/main/src/libraries/Microsoft.Extensions.Logging.Abstractions) interface with the open-source [Serilog](https://github.com/serilog/serilog) logging library implementation
- Testing: separate projects for Unit and Integration tests (libraries used: xUnit, FluentAssertions)
- Docker support: [Dockerfile](src/TruePokemon.Api/Dockerfile)

## TODO
- Authentication?
- Automated build and release pipelines
- Prod release configuration adjustments
- Browser caching 
- Docker-compose