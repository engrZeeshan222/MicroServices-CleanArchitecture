# Project Architecture

Our project architecture is structured into distinct layers, each serving a specific role in ensuring efficient functionality and maintainability:

## Domain Layer

- **Purpose:** Defines the business logic and entities.
- **Role:** Serves as the core of the project, encapsulating the fundamental business rules and data models.

## Infrastructure Layer

- **Purpose:** Handles persistence technologies such as Entity Framework for database interactions.
- **Role:** Manages data access and storage, providing a bridge between the application and the database.

## Application Layer

- **Purpose:** Encapsulates the business logic with clear separation of interfaces and implementations.
- **Role:** Facilitates ease of maintenance and development by abstracting the core business rules from specific implementations.

## API Layer

- **Purpose:** Acts as the primary interface for user interaction.
- **Role:** Leverages dependencies from both the Domain and Application Layers to facilitate seamless data management and user interactions.

## Shared Folder

- **Purpose:** Serves as a centralized repository for commonly used code snippets.
- **Role:** Promotes code reuse and maintainability across layers, reducing duplication and enhancing consistency.

Through this well-organized architecture, we establish a solid foundation for our project, enhancing reliability, scalability, and overall system performance.
