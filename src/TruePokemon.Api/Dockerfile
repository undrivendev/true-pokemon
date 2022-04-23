FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers for caching
COPY src/TruePokemon.Api/TruePokemon.Api.csproj TruePokemon.Api/TruePokemon.Api.csproj
COPY src/TruePokemon.Core/TruePokemon.Core.csproj TruePokemon.Core/TruePokemon.Core.csproj
COPY src/TruePokemon.Application/TruePokemon.Application.csproj TruePokemon.Application/TruePokemon.Application.csproj
COPY src/TruePokemon.Infrastructure/TruePokemon.Infrastructure.csproj TruePokemon.Infrastructure/TruePokemon.Infrastructure.csproj
RUN dotnet restore -r linux-x64 "TruePokemon.Api/TruePokemon.Api.csproj"

# copy and publish app and libraries
COPY src/TruePokemon.Api/ TruePokemon.Api/
COPY src/TruePokemon.Core/ TruePokemon.Core/
COPY src/TruePokemon.Application/ TruePokemon.Application/
COPY src/TruePokemon.Infrastructure/ TruePokemon.Infrastructure/
WORKDIR /src/TruePokemon.Api
RUN dotnet publish -c Release --no-self-contained -r linux-x64 -o /app "TruePokemon.Api.csproj"

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "TruePokemon.Api.dll"]