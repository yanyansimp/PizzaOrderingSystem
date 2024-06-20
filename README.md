PizzaOrdering System

Overview
  The PizzaOrdering System is a demonstration project showcasing how to import data from CSV files into a structured database, 
  design a RESTful API following Clean Architecture and CQRS patterns, and utilize modern C#/.NET practices to build a scalable and maintainable backend application.

Features
  - Import data from CSV files into a database
  - RESTful API operations for Orders, and OrderDetails
  - Pagination support for efficient data retrieval
  - Clean Architecture and CQRS pattern implementation
  - Additional insights into sales data

Architecture
  The project follows Clean Architecture principles, ensuring separation of concerns and making
  the codebase maintainable and scalable. We also implement the CQRS (Command Query 
  Responsibility Segregation) pattern to separate read and write operations.

Layers
  Core: Contains the domain models and repository interfaces.
  Application: Contains the business logic, including MediatR handlers for commands and queries.
  Infrastructure: Contains the data access layer, including the DbContext and CSV import services.
  API: Contains the controllers and endpoints for the RESTful API.

Database Schema
  The database schema consists of four main tables: Pizzas, PizzaTypes, Orders, and OrderDetails. Each table is connected via foreign keys to ensure data integrity.
  
  Pizzas: Stores pizza information.
  PizzaTypes: Stores types and categories of pizzas.
  Orders: Stores order details.
  OrderDetails: Stores details of each order, including quantities and pizza IDs.

Getting Started
  Prerequisites
    .NET Core 3.1 SDK or later
    SQL Server or SQLite

Installation
  1. Clone the repository:
     https://github.com/yanyansimp/PizzaOrderingSystem.git

  2. Navigate to the project directory:
     cd PizzaOrderingSystem

  3. Restore dependencies:
     dotnet restore

  4. Update the database:
     dotnet ef database update

  5. Run the application:
     dotnet run

API Endpoints
  Orders
    `GET /api/orders`: Retrieve all orders (with pagination)
    `POST /api/orders`: Create a new order

  OrderDetails
    `GET /api/orderDetails/{orderId}`: Retrieve order details by ID

Demo Video
  Check out our demo video where we walk through the application, demonstrate all features, and discuss the design decisions and tradeoffs.




