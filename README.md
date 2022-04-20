NOTE: this is not necessarily what I would recommend for a simple API like the one required for the test, this is meant to showcase how I would approach building a solution for a reasonably-sized project.

## Features

- TODO: resilient HttpClient instance with exponential backoff + jitter retry policy using Polly
- Based on .NET 6 for Long Term Support
- Simplified .NET 6 startup hosting model
- [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) with full separation between Read and Write repositories
- Simple [Mediator](https://en.wikipedia.org/wiki/Mediator_pattern) abstraction for CQRS and no-magic, in-memory implementation relying on the standard `IServiceProvider` DI container abstraction (~50 lines of code)
- Project structure following [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) principles
- [SimpleInjector](https://github.com/simpleinjector/SimpleInjector) open-source DI container integration for advanced service registration scenarios
- [Aspect-oriented programming](https://en.wikipedia.org/wiki/Aspect-oriented_programming) using [Decorators](https://en.wikipedia.org/wiki/Decorator_pattern) on the above-mentioned mediator
  - [Logging](src/WebApiTemplate.Application/CommandHandlerLoggingDecorator.cs)
  - [Caching](src/WebApiTemplate.Application/QueryHandlerCachingDecorator.cs)
- Structured logging using the standard [MEL](https://github.com/dotnet/runtime/tree/main/src/libraries/Microsoft.Extensions.Logging.Abstractions) interface with the open-source [Serilog](https://github.com/serilog/serilog) logging library implementation
- Testing
- TODO: Dockerfile

## Next steps
TODO