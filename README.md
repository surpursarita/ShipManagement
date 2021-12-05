# ShipManagement
Welcome to the ShipManagement Git Repository. This Repository contains Task.ShipManagement Solution.

## About
This application will allow the user to perform CRUD (Create, Read, Update & Delete) operations on a ship.  Each ship must have a name (string), length (in metres), width (in metres) and code (a string with a format of AAAA-1111-A1 where A is any character from the Latin alphabet and 1 is a number from 0 to 9).

### How to setup
To setup the ShipManagement Solution in local machine, you need to install Visual Studio 2022(With .Net Core 3.1).
#### Prerequisites
* Visual Studio 2022
* npm (https://www.npmjs.com/)
* npx (https://www.npmjs.com/package/npx)

You require to add following Nugets:
Autofac, Autofac.Extensions.DependencyInjection

### Build Task.ShipManagement Solution
* Restore Nuget Package
* Build Task.ShipManagement Solution
* Click on Start or Press F5 - It will execute multiple startup projects one for HPC.Task.ShipManagement.API and another HPC.Task.ShipManagement.UI.

### Design and Development Details
Technologies:
.Net Core 3.1 Web API.
Autofac, Autofac.Extensions.DependencyInjection.
Typescript React.
For data store used memory, List of objects.
LinQ - To perform CRUD operation.

Design Patterns:
Dependency Injection for Loose Coupling
