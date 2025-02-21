# ECommerce - Backend
## .NET WebAPI
### WORK IN PROGRESS

### This is my implemetation of backend part for my E-Commerce solution. Using C# ASP.NET Core I implemented endpoints, responsible for manimulating and retriving data from Microsoft SQL Server Database. EntityFrameworkCore is responsible for seeding the database with example data and providing relationships between tables. Example of usage of Entity to create table with relationship with another one:
![Reference Image](/README_photos/entity.PNG)
### Below you can see whole database diagram:
![Reference Image](/README_photos/database_diagram.PNG)
### Each endpoint is responsible for diffrent action. For example endpoint, responsible for retrieving data from *Products* table:
![Reference Image](/README_photos/get_products.PNG)
### I am using Data Transfer Object (DTO) files in order to ensure that original object is not changed. After debugging the app what will appear is swagger page with list of all API endpoint.
![Reference Image](/README_photos/swagger.PNG)
test