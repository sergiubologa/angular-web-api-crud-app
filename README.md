# angular-web-api-crud-app
Basic SPA project which implements simple CRUD operations using the following technologies:

1. AngularJS 
2. ASP.NET MVC Web API
3. MS SQL Server 2008
4. Entity Framework
5. Dependency Injection

# Setup
The application has 2 projects: AngularJsTest and AngularJsTest.Data.

The project AngularJsTest includes a database called TestDatabase.mdf which is located in the App_Data folder.

Data manipulation is made using Entity Framework, therefore the project AngularJsTest.Data contains the EDMX model. 

In order to link the EDMX model with the database located in the App_Data folder, the connection string from App.config file must be updated with the full local path to the database file.
