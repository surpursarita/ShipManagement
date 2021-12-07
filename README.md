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
* Chrome, Add extension - CORS Unblock(

You require to add following Nugets:
Autofac, Autofac.Extensions.DependencyInjection

### Build Task.ShipManagement Solution
* Restore Nuget Package
* Build Task.ShipManagement Solution
* Enable this in Chrome extensions:
![image](https://user-images.githubusercontent.com/4328579/145005221-4b237169-748d-44c3-8907-e90037e4d200.png)
* Click on Start or Press F5 - It will execute multiple startup projects one for HPC.Task.ShipManagement.API and another HPC.Task.ShipManagement.UI.

### Design and Development Details
Technologies:
* .Net Core 3.1 Web API.
* Autofac, Autofac.Extensions.DependencyInjection.
* For data store used memory, List of objects.
* LinQ - To perform CRUD operation.
* Unit test - Ms Test and Moq Framework

Design Patterns:
* Dependency Injection for Loose Coupling

UI:
* React Typescript.
* Bootstrap
* react-grid-system

### Unit Test Cases
* HPC.Task.ShipManagement.API.Test
* HPC.Task.ShipManagement.Service.Test
* HPC.Task.ShipManagement.DAL.Test
