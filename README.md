# EntityFrameworkDemo

This is a demo project that showcases the usage of Entity Framework Core in a .NET application. It consists of five main components: Business, Entity, Global, Tests, and WPF.

## Project Structure

### Entity
The `Entity` project contains the Entity Objects that represent tables in the database. 
- These entities are used to map the database tables to object-oriented entities in the program.
- When using Entity Framework Core's Code First approach, you define your entity objects as classes, and the framework automatically creates the corresponding database tables based on these classes. 
- Each entity object represents a single table in the database.

### Business
The `Business` project contains the business logic of the application. It includes the following components:

- **SubSystemDbContext:** The Business project includes a SubSystemDbContext class that represents the database context. This class is responsible for defining the database schema, configuring the entity mappings, and managing the interactions with the database. It sets up the DbSets for the entity types and provides the necessary configuration for Entity Framework Core.

- **Migrations:** Migrations are used to evolve the database schema over time as the application evolves. It allows you to easily apply changes to the database schema or roll back to previous versions. Using Entity Framework Core's migration tools, I can generate migration scripts based on the changes I have made to the DbContext and apply those migrations to the database.

- **Generic Data Repository:** A generic repository class that provides basic CRUD operations for interacting with the database using Entity Framework Core. This repository serves as a base class for specific repositories.

- **DeviceRepository:** A repository class that inherits from the Generic Data Repository and provides additional implementation specific to the Device entity. This repository has been generated using T4 templates.

- **SubSystemRepository:** Similar to the DeviceRepository, this repository inherits from the Generic Data Repository and provides specific implementation for the SubSystem entity. This repository has also been generated using T4 templates.

- **DeviceService:** A service class that uses the DeviceRepository injected through its constructor to interact with the database and perform operations related to devices. It does not handle the dependency injection itself but relies on the injection provided by the DI container. The DeviceService handles business logic, validation, and uses AutoMapper for mapping between entity objects and DTOs (Data Transfer Objects).

- **SubSystemService:** Similar to the DeviceService, this service class uses the SubSystemRepository injected through its constructor to interact with the database and handle operations related to SubSystem. It also relies on dependency injection for the repository and takes care of business logic, validation, and object mapping. The mapping profiles and validations are set up in the Business project.

- **Mapping Profiles:** The Business project contains mapping profiles that define how entity objects are mapped to DTOs and vice versa using AutoMapper. These profiles help streamline the mapping process and ensure consistent mappings between different object types.

- **Validations:** The Business project also includes validation classes that utilize the Fluent Validations library. These validation classes define the validation rules and logic for the DTO objects and ensure that the data meets the required business rules before being processed by the services.

### Tests
The `Tests` project contains unit tests for the services in the application. These tests ensure that the business logic is functioning correctly and provide a safety net for future changes and refactoring.

- **Test Base Class:** The Test Base class serves as a base class for the tests. This class is responsible for setting up common test infrastructure, such as registering services, configuring dependency injection, and creating an in-memory database for testing purposes.

- **Database Seeder:** Additionally, there is a Database Seeder class that is responsible for seeding and clearing the in-memory database before and after each test is run. This ensures a consistent and isolated testing environment for each test execution.

- **DeviceServiceTests** The DeviceServiceTests class is a set of unit tests for the DeviceService class in the EntityFrameworkDemo.Business namespace. It includes tests for methods such as GetAll, GetById, CreateNewDevice, DeleteDeviceById, etc. These tests verify the expected behavior of the DeviceService class under different scenarios.

- **SubSystemServiceTests** The SubSystemServiceTests class is a collection of unit tests for the SubSystemService class in the EntityFrameworkDemo.Business namespace. It contains tests for methods like GetAll, GetById, CreateNewSubsystem, DeleteSubsystemById, etc. These tests validate the functionality of the SubSystemService class in various situations.

### Global Project
The `Global` project serves as a central place for common files used across the application. It includes the following components:

- **Constants Class:** A Constants class that contains strings used across the application. This allows for centralized management and easy access to shared values.

### WPF Project
- **Services are Registered**: User Interface is in Progress. 

## Technologies Used

- **.NET 6:** The project is built using the .NET 6 framework, which provides the latest features and improvements for developing robust applications.
- **Entity Framework Core:** Entity Framework Core is used as the Object-Relational Mapping (ORM) framework to interact with the database. It simplifies data access and provides powerful querying capabilities.
- **MS Test:** The unit tests are written using the MS Test framework, which is a testing framework included with the .NET platform.
- **Fluent Validations:** Fluent Validations library is used for validating input data and enforcing business rules in a fluent and customizable way.
- **AutoMapper:** AutoMapper is employed for mapping between different object types, such as mapping entity objects to DTOs and vice versa. It simplifies the mapping process and reduces boilerplate code.
- **T4 Text Templates:** T4 (Text Template Transformation Toolkit) templates are used
- **Serilog** an open-source logging library for .NET applications. It provides a flexible and efficient logging framework with a focus on structured logging.
