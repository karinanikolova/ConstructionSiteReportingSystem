<img alt="Static Badge" src="https://img.shields.io/badge/C%23-%23512BD4?style=plastic&logo=dotnet"> <img alt="Static Badge" src="https://img.shields.io/badge/ASP.NET_Core_MVC-%23512BD4?style=plastic"> <img alt="Static Badge" src="https://img.shields.io/badge/EF_Core-%23512BD4?style=plastic"> <img alt="Static Badge" src="https://img.shields.io/badge/SQL_Server-%23ef901c?style=plastic">
<img alt="GitHub License" src="https://img.shields.io/github/license/mashape/apistatus?style=plastic">

# ![favicon-32x32](https://github.com/user-attachments/assets/bfff0608-ac9a-4e9f-b3a1-cadc69678e0c) Construction Site Reporting System

## 📃 Table of Contents
- [Description](#-description)
- [Prerequisites](#-prerequisites)
- [Installation](#-installation)
- [Usage](#-usage)
- [License](#-license)

## 📖 Description
### Overview
This is a web application for control and management of construction sites. It is purposefully created to be used amongst company management personnel only. The application is developed to provide data for each type of work conducted throughout construction stages and to ease tracking of construction work progress.

### Technologies used
This project is an ASP.NET Core MVC application written in C#, using Entity Framework Core as an object-relational mapper and MS SQL Server as a database provider. The application is primarily built to develop and exercise skills for back-end programming; therefore, the front-end is mainly created using Bootstrap, as well as using the default layout and styles provided by ASP.NET Core.

### Architecture
The application implements a generic repository design pattern, which aims to provide data operations in a single, generic repository rather than having separate repositories for each entity type. This approach adds an additional layer of abstraction over the application data layer. The application itself consists of three class library projects named, respectively, *ConstructionSiteReportingSystem*, *ConstructionSiteReportingSystem.Core*, *ConstructionSiteReportingSystem.Infrastructure* and *ConstructionSiteReportingSystem.Tests*. Each project represents a layer that can view resources from itself and each following layer. The first layer holds the application itself and stores the controllers, views, extension methods, custom model binders, areas, etc. The second layer holds the business logic of the application, which represents custom rules or algorithms that handle the exchange of information between the database and user interface. This current layer holds DTO models, services, constants, etc. The third layer is the data access layer, holding database classes and context, migrations, data for seeding the database, etc. The final layer is for application testing and holds unit tests for each service.

## 📦 Prerequisites
- IDE
- .NET 6
- MS SQL Server with a client tool for connecting to the Database Engine, such as SQL Server Management Studio, MSSQL extension for Visual Studio Code, etc.

## 🔧 Installation
1. Clone the repository: [ConstructionSiteReportingSystem](https://github.com/karinanikolova/ConstructionSiteReportingSystem.git)
2. After opening the solution file, place your localhost connection string in order to run the application.  

If you wish to run the app in development mode, you can either:
- Go to the *ServiceCollectionExtension.cs* file (path: *ConstructionSiteReportingSystem\Extensions\ServiceCollectionExtension.cs*). Find the following code in lines 47 and 48 and place the connection string instead of the *connectionString* local variable:

```
services.AddDbContext<ConstructionSiteDbContext>(options => options.UseSqlServer(connectionString));
```

- Open the *secrets.json* file by right-clicking on the *ConstructionSiteReportingSystem* project file, then selecting *Manage User Secrets*, and place your connection string there:

```
{
    "ConnectionStrings": {
        "DefaultConnection": "your_connection_string"
    }
}
```  
If you wish to run the application in production mode, you must place your connection string in the *ServiceCollectionExtension.cs* file as previously mentioned.

3. Start the application. The migrations will be applied automatically beforehand and you will be able to see the database created locally with the client tool of your choice.

## 💡 Usage
To use the [ConstructionSiteReportingSystem](https://github.com/karinanikolova/ConstructionSiteReportingSystem), you must first register. There are two types of roles in the application - user and administrator. When you first register, you become a user who can be turned into an admin by another administrator. Each role has a different access level and authorities. This was created in an effort to reduce user errors and repetitive information and allow for administrative input checking before submission of certain data.

### User
Users can view all construction site data by clicking on a particular site's *View Report* and view their own work tasks by clicking on *Tasks*. Users can create works and tasks, suggest new contractors, construction stages, measurement units, and work types. Each construction site report consists of construction and assembly work information created by different users. Only users who have created a work entry can edit, delete, or move it to a different construction site. When viewing their own user tasks, users can edit or delete them.

### Administrator
- Has all the rights of a user
- Can view, edit, or delete all users' tasks and work entries
- Can also access the Admin area:
    - Can review suggestions made by users and approve, edit, or remove
    - Can manage user roles (make users admins or vice versa)
    - Can create new construction site entries

## 🔓 License
This project is licensed under the MIT License - see the [LICENSE](https://github.com/karinanikolova/ConstructionSiteReportingSystem/blob/master/LICENSE.txt) file for details.
