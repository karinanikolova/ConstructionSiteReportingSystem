<img alt="Static Badge" src="https://img.shields.io/badge/C%23-%23512BD4?style=plastic&logo=dotnet"> <img alt="Static Badge" src="https://img.shields.io/badge/ASP.NET_Core_MVC-%23512BD4?style=plastic"> <img alt="Static Badge" src="https://img.shields.io/badge/EF_Core-%23512BD4?style=plastic"> <img alt="Static Badge" src="https://img.shields.io/badge/SQL_Server-%23ef901c?style=plastic">
<img alt="GitHub License" src="https://img.shields.io/github/license/mashape/apistatus?style=plastic">

# ![favicon-32x32](https://github.com/user-attachments/assets/bfff0608-ac9a-4e9f-b3a1-cadc69678e0c) Construction Site Reporting System

## 📖 Description
### Overview
This is a web application for control and management of construction sites. It is purposefully created to be used amongst company management personnel only. The application is developed to provide data for each type of work conducted throughout construction stages and to ease tracking of construction work progress.

### Technologies used
This project is an ASP.NET Core MVC application, written in C#, using Entity Framework Core as an object-relational mapper and MS SQL Server as a database provider. The application is primarily built to develop and exercise skills for back-end programming, therefore, the front-end is mainly created using Bootstrap, as well as using the default layout and styles provided by ASP.NET Core.

### Architecture
The application implements a Generic Repository Design pattern, which aims to provide data operations in a single, generic repository rather than having separate repositories for each entity type. This approach adds an additional layer of abstraction over the application data layer. The application itself consists of three class library projects named respectively 'ConstructionSiteReportingSystem', 'ConstructionSiteReportingSystem.Core', 'ConstructionSiteReportingSystem.Infrastructure' and 'ConstructionSiteReportingSystem.Tests'. Each project represents a layer that can view resources from itself and each following layer. The first layer holds the application itself and stores the controllers, views, extension methods, custom model binders, areas, etc. The second layer holds the business logic of the application, which represents custom rules or algorithms that handle the exchange of information between the database and user interface. This current layer holds DTO models, services, constants, etc. The third layer is the data access layer, holding database classes and context, migrations, data for seeding the database, etc. The final layer is for application testing and holds unit tests for each service.
