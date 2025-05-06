# 🐾 Animal Shelter REST API 

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0.0-%23512BD4)](https://learn.microsoft.com/en-us/aspnet/core/)
[![Swagger](https://img.shields.io/badge/Swagger-6.5.0-%2385EA2D)](https://swagger.io/)

REST API implementation for managing animal shelter operations, built with .NET 9 Minimal APIs. Part of a C# developer learning roadmap project.


![image](https://github.com/user-attachments/assets/c6a752df-b398-4c36-bdea-5ed8a9f1a864)

## Pet-Project
![image](https://github.com/user-attachments/assets/48539c81-8d53-404a-8de1-e34ef4226ca2)


## 🌟 Features

- **Full CRUD Operations** for animal management
- In-memory data storage with thread-safe dictionary
- **Modern API Practices**:
  - Proper HTTP status codes
  - Problem Details for error responses (RFC 7807)
  - Endpoint filters for validation
- **Validation**:
  - Data annotations with MinimalApis.Extensions
  - Custom validation logic
- **Dependency Injection** implementation
- **OpenAPI Documentation** with Swagger UI
- Health check endpoint
- Structured logging
- Rate limiting (basic implementation)

## 📚 API Endpoints

| Method | Endpoint                  | Description                |
|--------|---------------------------|----------------------------|
| `GET`  | `/api/animals`            | Get all animals            |
| `GET`  | `/api/animals/{id}`       | Get specific animal        |
| `POST` | `/api/animals`            | Add new animal             |
| `PUT`  | `/api/animals/{id}`       | Update animal details      |
| `DELETE` | `/api/animals/{id}`     | Remove animal              |
| `POST` | `/api/animals/{id}/feed`  | Feed an animal             |

## 🛠️ Technical Stack

### Core Technologies
- **.NET 9** 
- **ASP.NET Core Minimal APIs** 
- **Swagger UI** (via `Swashbuckle.AspNetCore`)

### Key Packages
| Package                       | Version   | Purpose                          |
|-------------------------------|-----------|----------------------------------|
| `MinimalApis.Extensions`      | 1.0.0     | Enhanced validation & routing    |
| `Swashbuckle.AspNetCore`      | 6.5.0     | OpenAPI documentation            |
| `Hellang.Middleware.ProblemDetails` | 6.0.0 | Standardized error responses     |

## 📖 Documentation

### Access Swagger UI
After running the project, navigate to:
```bash
http://localhost:5000/swagger
```
## 🚀 Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Your favorite IDE (VS 2022, Rider, or VS Code)

### Installation
```bash
git clone https://github.com/infinity-crime/Example-REST-API-PetProject.git
cd Example-REST-API-PetProject
dotnet restore
dotnet run
