# 🐾 Animal Shelter REST API 

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0.0-%23512BD4)](https://learn.microsoft.com/en-us/aspnet/core/)
[![Swagger](https://img.shields.io/badge/Swagger-6.5.0-%2385EA2D)](https://swagger.io/)

A REST API implementation for managing animal zoo operations, built using .NET 9 Minimal APIs. This project was made according to the ready-made requirements of a developer from YouTube

## Requirements 📖
![image](https://github.com/user-attachments/assets/48539c81-8d53-404a-8de1-e34ef4226ca2)

## Screenshot from Swagger UI
![image](https://github.com/user-attachments/assets/f10c2b78-3fd3-4870-9e69-2d1f4345d80e)


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

## 📚 API Endpoints

| Method | Endpoint                  | Description                |
|--------|---------------------------|----------------------------|
| `GET`  | `/api/animals`            | get a dictionary of all animals            |
| `GET`  | `/api/animals/{id}`       | get information about a specific animal        |
| `POST` | `/api/animals/{id}`            | adding an animal to the dictionary by id             |
| `PUT`  | `/api/animals/{id}/feed`       | feeding of the animal selected by id      |
| `DELETE` | `/api/animals/{id}`     | removal of the animal              |

## 🛠️ Technical Stack

### Core Technologies
- **.NET 9** 
- **ASP.NET Core Minimal APIs** 
- **Swagger UI** (via `Swashbuckle.AspNetCore`)

### Key Packages
| Package                       | Version   | Purpose                          |
|-------------------------------|-----------|----------------------------------|
| `MinimalApis.Extensions`      | 0.11.0     | Enhanced validation & routing    |
| `Swashbuckle.AspNetCore`      | 8.1.1     | OpenAPI documentation            |

## 📖 Documentation

### Access Swagger UI
After running the project, navigate to:
```bash
http://localhost:5000/swagger
```
## 🚀 Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- IDE (VS 2022, Rider, or VS Code)

### Installation
```bash
git clone https://github.com/infinity-crime/Example-REST-API-PetProject.git
cd Example-REST-API-PetProject
dotnet restore
dotnet run
