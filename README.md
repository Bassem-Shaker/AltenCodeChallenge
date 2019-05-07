# AltenCodeChallenge

## This challenge task include:
- [.Net Core](https://docs.microsoft.com/en-us/dotnet/core/) 
- [.Net Core Web API](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-2.2)
- Accessing data sources using [Entity Framework core](https://docs.microsoft.com/en-us/ef/core/get-started/netcore/) with SQL Server
- [Xunit](https://xunit.net/)
- Communication between microservices using [RABBIT MQ](https://www.rabbitmq.com/)
- [Swagger(OpenAPI Specification)](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-2.2) for API documentation.
- [Angular 6](https://angular.io/)
- HTML, CSS & [Bootstrap](https://getbootstrap.com/docs/4.3/getting-started/introduction/)

## Solution Architecture:
This task divide into the following main microservices & components
1. **Front End Portal**: angular Single Page Application (designed & implemented to support module Lazy loading) that provides users the ability to see An overview of all vehicles on one page (full-screen display), together with their status, the vehicles information as well the last ping time if the vehicle is down. It is real time overview page for the current vehicles status. Also the user able to filter, to only show vehicles for a specific customer or show vehicles that have a specific status.

2. **Customers Service**: It provides basic information about each customer such as name, address and it will include any customer contacts information, Zip codes, phones, customer companies. and designed to Add/update/delete any customer data and feed any other microservice with these data.   

3. **Vehicles Simulation MessageQueueing Service**: it simulate the real vehicles ping which as it runs on the background processing and scheduling with IHostedService which runs every one minute to raise event only if the vehicle is chosen randomly to be connected thus will send asynchronous event to the event bus (RabbitMQ) so other services can react and it will listen for acknowledgement receive.   

4. **Vehicles service** a sole purpose of this service is responsible for managing vehicle pings thus logging the vehicles data as well update each machine with its status on SQL DB. It subscribes to events related to vehicles Simulation MessageQueueing lifecycle and reacted with sending acknowledgement.
Also it's provide front end with the indeed vehicle information as well search capabilities by customer or machine status. There is an option to split this service to two microservice, one to handle vehicle API and another microservice to subscribe to events related to vehicles Simulation.

5. **RabbitMQ**: responsible for the communication between microservices.

You can find architectural diagram of the task below.

![Diagram ](https://user-images.githubusercontent.com/30432856/57286173-03ffd480-70b5-11e9-9ec7-6cdd454f5afb.png)


## Solution Structure
Solution (source code above) is using heavily Dependency Injection (DI) design pattern that reduces hard-coded dependencies between the classes by injecting these dependencies at run-time, instead of during design-time thus it used to control which data set is passed to the control logic (test data vs real database).

Below is a fragment of the solution presents on (visual studio 2017) solution.  There are four folders, Each folder contains the projects related to each microservices as well the Frontend project, I would split them into separate each service on a standalone solution but for POC, I created all of them on one solution however there is no direct dependency between them (all microservice using RabbitMQ to communicate).  


![image](https://user-images.githubusercontent.com/30432856/57258133-c753bf00-705b-11e9-8808-2161c40cdde3.png)



Each microservice "CustomersMicroservice,VehiclesCoreMicroservice" service has:  
- Its own model and interfaces that exposed to the external world throughout the WebAPI
- Data access layer through Entity framework are encapsulated on one layer
- Unit test each above service by using Xunit.
- listeners (for events delivered via queue) and REST Clients (for handling outgoing http requests).

The portal Front End is developed by using angular 6 Single page application also lazy loading module has been taken on this to enhance loading performance as shown below 

![image](https://user-images.githubusercontent.com/30432856/57258961-41854300-705e-11e9-9fd7-146862d5af7e.png)


## How to browse 
- Navigate to http://localhost:52845//swagger/index.html to browse Customers Web API
- Navigate To http://localhost:53373//swagger/index.html to browse Vehicles Web API
- Navigate to http://localhost:63341/api/values to see the random simulation status of vehicles status
- Naviagte to http://localhost:4200/ to see Fron End portal


Cutomers API

![image](https://user-images.githubusercontent.com/30432856/57304224-3b837680-70df-11e9-8254-368bfd2e90c1.png)

![image](https://user-images.githubusercontent.com/30432856/57304797-45f24000-70e0-11e9-930c-a14bd28fbc62.png)

Vehicles Web API

![image](https://user-images.githubusercontent.com/30432856/57304884-63270e80-70e0-11e9-8e53-8a34b6e7861e.png)

![image](https://user-images.githubusercontent.com/30432856/57304951-85b92780-70e0-11e9-8db2-281b968dcd0e.png)

Simulation status

![image](https://user-images.githubusercontent.com/30432856/57306033-5b686980-70e2-11e9-9161-bce1da0d860c.png)


Portal Front END (all Vehicles)

![image](https://user-images.githubusercontent.com/30432856/57305453-679ff700-70e1-11e9-9271-3c1aeeb2ed23.png)

Portal Front END (filter Vehicles by specific customer)

![image](https://user-images.githubusercontent.com/30432856/57305533-88684c80-70e1-11e9-8f08-3e4a92f2518c.png)


Customers tables data (SQL Server)

![image](https://user-images.githubusercontent.com/30432856/57306124-8eaaf880-70e2-11e9-8522-c7deb65a7d78.png)



Vehicles Data on SQL database

![image](https://user-images.githubusercontent.com/30432856/57306256-ce71e000-70e2-11e9-83c4-184427b9c348.png)

## Software installation prerequisites:
- SQL Server Management Studio 2014 or greater
- Visual Studio 2017 Professional or Community Edition
- .NET Core 2.1 
- RabbitMQ
- NodeJS 10.13.0 or greater
- Angular CLI

## Deployment Steps
1. Clone or download the projects from repo.
2. Run the 2 scripts on folder \[Repo path]\AltenCodeChallenge\DatabaseScripts on SQL Server.
3. Navigate to the folder AltenCodeChallenge\Support and double click 1-buildAll.bat file to build all projects 
4. Once you have everything built you can begin to run the applications.  First start up all the back-end Web API applications by executing the DOS batch file 2-StartDevelopmentWebServers.bat from the Support folder. This file executes a custom built .NET Core application called CodeChallenge.RunProjects that will start up all the back-end processes for the  application. 
5. Build the Angular 6 front-end application: using DOS command window and navigate to [solution physical path]\AltenCodeChallenge\CodeChallenge.PortalWeb\Portal folder and then execute: ng build
6. once finished execute the Angular CLI command: ng serve on the directory
7. to access the Microservices Portal application, navigate to http://localhost:4200 in your browser

## Out of scope
- User authentication and authorization
- Security layer in the Microservices Architecture
- Unit testing front end portal on old browsers.
- Automation test
- Scalable SQL server database architecture
- Dockerize the whole solution.
- Use any free tier on any cloud platform 

## Enhancement
- Using an API Gateway in Microservices Architecture
- Using SignalR to allow server code to send asynchronous notifications to client-side web applications.
- Use Automapper to map model to ViewModel
- Handle unexpected errors.

