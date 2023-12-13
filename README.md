# CRUD-Project

Description

This project is a .NET Core application developed using CQRS (Command Query Responsibility Segregation) pattern and MediatR library for implementing commands and queries. It is designed to showcase the separation of concerns between command and query functionalities to improve scalability and maintainability.

The application utilizes SQL Server for data storage, managed via SQL Server Management Studio (SSMS), and employs Dapper, a micro ORM, for database operations.

Usage

The application structure is organized around the CQRS pattern with commands and queries separated for better maintainability. It uses the Bootstrapper class for dependency injection, which is called in the Startup.cs file to configure services.

Commands: Responsible for handling write operations.
Queries: Responsible for handling read operations.
Models: Contains the data models used across the application.
Services: Contains the logic for handling commands and queries.
Controllers: Expose endpoints to interact with the application.
The MediatR library is employed to mediate between commands, queries, and their respective handlers.

Technologies Used

.NET Core
CQRS (Command Query Responsibility Segregation) pattern
MediatR
SQL Server with SQL Server Management Studio (SSMS)
Dapper
xUnit with Mock

Contributions

Contributions are welcome! If you find any issues or have suggestions for improvements, feel free to open an issue or create a pull request.
