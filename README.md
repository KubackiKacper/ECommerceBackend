# ECommerce - Backend
## .NET WebAPI

### This is my implementation of the backend for my E-Commerce solution. Using C# and .NET Core, I have developed endpoints responsible for manipulating and retrieving data from a Microsoft SQL Server database. Entity Framework Core is used for seeding the database with example data and managing relationships between tables:
![Reference Image](/README_photos/entity.PNG)
### Below is the complete database diagram:
![Reference Image](/README_photos/database_diagram.PNG)
### My implementation revolves around the service *ShopService*, which handles all business logic:
![Reference Image](/README_photos/service.PNG)
### Then, I configure the API endpoint in the application's controller, which calls the necessary methods from the service: 
![Reference Image](/README_photos/get_products.PNG)
### To ensure that the original objects remain unchanged, I use Data Transfer Objects (DTOs). After running the application, the Swagger page displays a list of all API endpoints:
![Reference Image](/README_photos/swagger_endpoints.PNG)
![Reference Image](/README_photos/swagger.PNG)
