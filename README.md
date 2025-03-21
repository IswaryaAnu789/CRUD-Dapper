📌 Project Description

The Dapper Employee Management System is a .NET 6 Web API that provides CRUD operations for managing employee details using Dapper for efficient database interactions.

🚀 Features

Create Employee: Add a new employee with validation.

Read Employee(s): Fetch all employees or a specific employee by ID.

Update Employee: Modify employee details.

Delete Employee: Soft delete an employee by updating isActive status.

Logging: Logs requests and errors using Serilog.

🛠️ Technology Stack

Backend: ASP.NET Core Web API (.NET 6)

Database: SQL Server (via Dapper ORM)

Logging: Serilog

Dependency Injection: .NET Core Services

API Documentation: Swagger

📥 Installation Prerequisites

.NET 6 SDK

SQL Server (Local or Remote)

Visual Studio or VS Code

📌 API Endpoints

POST  - /api/Employee/CreateNewEmployee  - Add a new employee

GET   -  /api/Employee/GetAllEmployees  - Retrieve all employees

GET  -  /api/Employee/GetEmployeeByID?id={id}  - Retrieve employee by ID

PUT  - /api/Employee/UpdateEmployee  - Update employee details

DELETE - /api/Employee/DeleteByEmployeeID?id={id}  - Soft delete an employee

📂 Project Structure

📁 DapperEmployeeManagement
│── 📄 Program.cs         # Main entry point
│── 📄 EmployeeController.cs # API Controller
│── 📄 Employee.cs        # Employee model
│── 📄 IEmployeeRepository.cs # Interface for repository
│── 📄 EmployeeRepository.cs # Dapper database operations
│── 📄 Baseresponse.cs    # API response model
│── 📄 Dapperempdetails.csproj # .NET project file
│── 📄 .gitignore         # Git ignore file
│── 📄 .gitattributes     # Git attributes
