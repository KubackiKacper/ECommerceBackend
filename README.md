# ECommerce - Backend
## .NET WebAPI
### WORK IN PROGRESS

### This is my implementation of the backend for my E-Commerce solution. Using C# and ASP.NET Core, I have developed endpoints responsible for manipulating and retrieving data from a Microsoft SQL Server database. Entity Framework Core is used for seeding the database with example data and managing relationships between tables.
### Here’s an example of using an entity to create a table with a relationship to another table:
![Reference Image](/README_photos/entity.PNG)
### Below is the complete database diagram:
![Reference Image](/README_photos/database_diagram.PNG)
### Each endpoint serves a specific purpose. For example, the following endpoint is responsible for retrieving data from the *Products* table:
![Reference Image](/README_photos/get_products.PNG)
### To ensure that the original objects remain unchanged, I use Data Transfer Objects (DTOs). After running the application, the Swagger page displays a list of all API endpoints:
![Reference Image](/README_photos/swagger.PNG)
# This project is currently under development. Any changes or improvements will be updated accordingly.
