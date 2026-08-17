# 🐦 Full-Stack Twitter Clone API

![.NET Version](https://img.shields.io/badge/.NET-8.0-purple.svg)
![Architecture](https://img.shields.io/badge/Architecture-Clean%20%2F%20Layered-blue)
![License](https://img.shields.io/badge/License-MIT-green.svg)

A robust, enterprise-grade full-stack Twitter clone built with **ASP.NET Core Web API** using C#. This project demonstrates industry-level backend application design—focusing on scalable REST APIs, decoupled architecture, JWT authentication, data persistence via Entity Framework Core, and real-time social interactions.

---

## 🏗️ Architecture & Key Technical Highlights

* **Decoupled Web API Backend**: Built strictly as a RESTful Web API service (No MVC Razor views) providing clean JSON endpoints for modern frontend clients (React/Vue/Angular).
* **Clean / Layered Architecture**: Separation of concerns across **API Layer**, **Business/Core Logic Layer**, **Data Access Layer (DAL)**, and **Domain Entities**.
* **Database & ORM**: Entity Framework Core (EF Core) with MS SQL Server / PostgreSQL using Migration workflows and Repository/Unit of Work patterns.
* **Authentication & Security**: ASP.NET Core Identity integration with JWT (JSON Web Token) authentication, refresh token strategies, and role-based policy authorization.
* **Real-time Engine**: **SignalR WebSockets** integration for live notifications (Likes, Mentions, Direct Messages, and real-time Feed updates).
* **DTO Mapping & Validation**: FluentValidation for request payload validation and AutoMapper for domain-to-DTO data projection.

---

## 🔥 Key Features

### 🔐 Auth & Account Management
* User Registration, Login, and Secure Password Hashing.
* JWT Token Generation & Refresh Token Handling.
* Profile Customization (Avatar uploading, bio, location, header image).

### 📝 Tweet & Feed Management
* **Tweet Lifecycle**: Post, edit, delete tweets, and attach media/links.
* **Engagement**: Like/Unlike tweets, Retweet, Quote Tweets, and threaded Replies.
* **Smart Feed**: Aggregated home timeline pulling paginated tweets from followed accounts.

### 👥 Social Graph & Search
* Follow / Unfollow system with mutual relationship checks.
* User Search & Hashtag/Trend extraction.
* Real-time notification updates when followed users tweet or interact.

---

## 🛠️ Tech Stack

### **Backend**
* **Language & Framework**: C# | .NET 8.0 ASP.NET Core Web API
* **Database & Data Access**: EF Core 8.0, MS SQL Server / PostgreSQL
* **Authentication**: ASP.NET Core Identity + System.IdentityModel.Tokens.Jwt
* **Real-time Communication**: ASP.NET Core SignalR
* **API Documentation**: OpenAPI / Swagger UI

### **Frontend**
* *(Insert your client framework here, e.g., React.js / Next.js / Angular / Vue)*
* **HTTP Client**: Axios / Fetch API with Interceptors for JWT authorization headers
* **State Management**: Zustand / Redux / TanStack Query

---

## 📁 Repository Structure

```text
├── src/
│   ├── Core/
│   │   ├── TwitterClone.Domain/       # Domain Entities, Interfaces & Enums
│   │   └── TwitterClone.Application/  # DTOs, Business Services, CQRS/Interfaces
│   ├── Infrastructure/
│   │   └── TwitterClone.Persistence/  # EF Core DbContext, Migrations, Repositories
│   └── Presentation/
│       └── TwitterClone.API/          # Web API Controllers, SignalR Hubs, Middlewares
└── tests/
    └── TwitterClone.Tests/            # Unit & Integration Tests
