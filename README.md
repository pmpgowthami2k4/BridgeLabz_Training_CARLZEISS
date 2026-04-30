
# 📌 Fundoo Notes – Microservices Architecture using .NET & Dapr

## 🚀 Overview

**Fundoo Notes Microservices** is a scalable, distributed backend system built using **ASP.NET Core**, **Dapr**, and **Docker**.

The application is designed using **Microservices Architecture + Clean Architecture**, where each service is independently deployable and responsible for a specific domain.

This project demonstrates real-world backend engineering concepts such as:

* Service-to-service communication
* Event-driven architecture
* API Gateway pattern
* Containerization
* Distributed system design

---

## 🧱 Architecture

The system is structured into multiple independent services:

* **API Gateway** → Single entry point
* **User Service** → Authentication & user management
* **Notes Service** → Notes CRUD operations
* **Label Service** → Label management
* **Collaborator Service** → Sharing & Pub/Sub communication

---

## 🧩 Microservices Description

### 👤 User Service

* User Registration & Login
* JWT Authentication
* Forgot / Reset Password

---

### 📝 Notes Service

* Create, Update, Delete Notes
* Archive / Trash Notes
* Pin / Unpin Notes

---

### 🏷️ Label Service

* Create Labels
* Assign Labels to Notes
* Manage User Labels

---

### 🤝 Collaborator Service

* Add/Remove Collaborators
* Share Notes Between Users
* Uses **Dapr Pub/Sub** for messaging

---

## 🔗 Communication Pattern

### ✔️ Synchronous

* Dapr Service Invocation

### ✔️ Asynchronous

* Dapr Pub/Sub
* Event-driven communication between services

---

## ⚙️ Tech Stack

* **ASP.NET Core Web API**
* **Dapr**
* **Docker & Docker Compose**
* **MongoDB / SQL**
* **RabbitMQ (via Dapr Pub/Sub)**
* **JWT Authentication**
* **MediatR (CQRS Pattern)**

---

## 📂 Project Structure

```
MicroService_Fundoo/
│
├── API Gateway
├── UserService
├── NotesService
├── LabelService
├── CollaboratorService
│
├── docker-compose.yml
├── components/ (Dapr configs)
└── Multiple Dockerfiles
```

Each service follows Clean Architecture:

```
Service/
├── API
├── Application
├── Domain
├── Infrastructure
```

---

# ▶️ How to Run the Project

## ⚠️ IMPORTANT RULES

* ❌ Do NOT run the same service twice
* ❌ Do NOT click “Run” in Visual Studio
* ✅ Use terminal only
* ✅ Run each service in a **separate terminal**
* ✅ Keep all terminals **OPEN**

---

## 🐳 Step 1: Start Infrastructure (Docker + Dapr)

Make sure Docker Desktop is running.

```bash
dapr init
```

(Optional if your setup uses containers)

```bash
docker-compose up --build
```

---

## 🟣 Step 2: Start Collaborator Service (Pub/Sub)

```bash
cd CollaboratorService.API

dapr run \
  --app-id collaboratorservice \
  --app-port 5291 \
  --dapr-http-port 3510 \
  --resources-path ../components \
  -- dotnet run
```

---

## 🔴 Step 3: Start API Gateway

```bash
cd Gateway.API

dotnet run
```

---

## 🟢 Step 4: Start Label Service

```bash
cd LabelService.API

dotnet run
```

---

## 🔵 Step 5: Start Notes Service

```bash
cd NotesService.API

dapr run \
  --app-id notesservice \
  --app-port 5066 \
  --dapr-http-port 3502 \
  --resources-path ../components \
  -- dotnet run
```

---

## 🟡 Step 6: Start User Service

```bash
cd UserService.API

dotnet run
```

---

## 🌐 Step 7: Quick Health Check (Swagger)

After all services are running, verify:

* Notes Service
  👉 [http://localhost:5066/swagger](http://localhost:5066/swagger)

* Label Service
  👉 [http://localhost:5003/swagger](http://localhost:5003/swagger) *(or configured port)*

* Collaborator Service
  👉 [http://localhost:5291/swagger](http://localhost:5291/swagger)

---

## ✅ Expected Outcome

* All Swagger endpoints should load successfully
* Services should communicate via Dapr
* Pub/Sub events should work correctly
* API Gateway should route requests properly

---

## 🔐 Authentication

* JWT-based authentication
* Secure endpoints with authorization
* Claims-based identity handling

---

## 📦 Containerization

Each service includes its own Dockerfile:

* User Service
* Notes Service
* Label Service
* Collaborator Service
* API Gateway

Run all containers using:

```bash
docker-compose up --build
```

---

## 🔄 Key Features

✔️ Microservices Architecture
✔️ Dapr Integration
✔️ Event-driven Pub/Sub
✔️ API Gateway Routing
✔️ Clean Architecture Implementation
✔️ Dockerized Deployment
✔️ Scalable System Design

---

## 🧠 What I Learned

* Designing distributed systems
* Implementing microservices using .NET
* Using Dapr for abstraction
* Managing inter-service communication
* Applying Clean Architecture in real-world projects
* Containerizing applications with Docker

