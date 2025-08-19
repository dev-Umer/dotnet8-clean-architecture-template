# .NET 8 Clean Architecture Web API Template

[![.NET 8](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/) 

A production-ready **Clean Architecture** template built with **.NET 8 Web API**.  
This starter kit gives you a solid foundation for building scalable, maintainable, and testable applications.

## ✨ Features

- Clean Architecture layers (Core, Application, Infrastructure, WebAPI)  
- CQRS with **MediatR** (Commands & Queries separation)  
- **FluentValidation** for request validation  
- **Entity Framework Core (SQL Server)** with repository pattern  
- **Global Exception Handling Middleware**  
- **Serilog** for structured logging  
- **Swagger/OpenAPI** for interactive API documentation  
- **xUnit + Moq + FluentAssertions** for testing  

## 📂 Project Structure

- src/
- Core/ # Domain models & exceptions
- Application/ # CQRS, validators, pipeline behaviors
- Infrastructure/ # EF Core, repositories, DI setup
- WebAPI/ # Controllers, middleware, API layer
- tests/
- UnitTests/ # Sample unit tests

## 🚀 Getting Started

1. Clone the repo:
   ```bash
   git clone https://github.com/dev-Umer/dotnet8-clean-architecture-template.git
   cd dotnet8-clean-arch-template

2. Update the connection string in:
   src/WebAPI/appsettings.json

3. Apply EF Core migrations:
  dotnet tool install --global dotnet-ef
  dotnet ef migrations add InitialCreate -p src/Infrastructure -s src/WebAPI
  dotnet ef database update -p src/Infrastructure -s src/WebAPI

4. dotnet run --project src/WebAPI

## 🛠 Use Cases

- Kickstart new .NET 8 Web API projects quickly
- Learn and practice Clean Architecture + CQRS
- Adopt as a team starter template for consistent architecture
