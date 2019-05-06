# AltenCodeChallenge

## These tasks include:
- [.Net Core](https://docs.microsoft.com/en-us/dotnet/core/) 
- [.Net core web API](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-2.2)
- Accessing data sources using [Entity Framework core](https://docs.microsoft.com/en-us/ef/core/get-started/netcore/) with SQL Server
- [Xunit](https://xunit.net/)
- Communication between microservices using [RABBIT MQ](https://www.rabbitmq.com/)
- [Swagger(OpenAPI Specification)](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-2.2) for API documentation.
- [Angular 6](https://angular.io/)

## Solution Architecture:
This task divide into 3 main microservices
1. **Front End Portal**: angular Single Page Application (designed & implemented to support module Lazy loading) that provides users the ability to see An overview of all vehicles on one page (full-screen display), together with their status, the vehicles information as well the last ping datetime if the vehicle is down. It is real real time overview page for the current vehicles status. Also the use able to filter, to only show vehicles for a specific customer or filter to only show vehicles that have a specific status.

2. **Customers Service**: It provides basic information about each customer such as name,address and it will include any customer contacts information, Zip codes, phones, customer companies. and designed to Add/update/delete any customer data and feed any other microservice with these data.   

3. **Vehicles Simulation MessageQueueing Service**: it simulate the real vehicles ping which as it runs on the background processing and scheduling with IHostedService which runs every one minute to raise event only if the vehicle is chosen randomly to be connected thus will send asynchronous event to the event bus (RabbitMQ) so other services can react.   

4. **Vehicles service** a sole purpose of this service is responsible for managing vechicle pings thus logging the vechicles data as well update each machine with it's status on SQL DB. It subscribes to events related to vehicles Simulation MessageQueueing lifecycle.
Also it's provide front end with the indeed vechicle information as well search capabilities by customer or machine status.

5. **RabbitMQ**: responsible for the communication between microservices
You can find architectural diagram of the task below.

![Untitled Diagram (1)](https://user-images.githubusercontent.com/30432856/57252593-c9625180-704c-11e9-8ae0-c1ac3cc7a605.png)

## Solution Structure
Solution (source code above) is using heavily Dependency Injection (DI) design pattern that reduces hard-coded dependencies between the classes by injecting these dependencies at run-time, instead of during design-time thus it used to control which data set is passed to the control logic (test data vs real database).

Below is a fragment of the solution presents on (visual studio 2017). solution  There are four folders, Each folder contains the projects related to each microservices as well the FrontEnd project, I would split them into seperate each service on a seperate solution but for POC, i created all of them on one solution however there is no direct dependency between them (all microservice useing RabbitMQ).  


![image](https://user-images.githubusercontent.com/30432856/57258133-c753bf00-705b-11e9-8808-2161c40cdde3.png)



Each microservice "CustomersMicroservice,VehiclesCoreMicroservice" service" has:  
- It's own models and interfaces that exposed to the external world througout the web api
- Data access layer through Entity framework are encapsulated on one layer
- Unit test each above service by using Xunit.
- listeners (for events delivered via queue) and REST Clients (for handling outgoing http requests).

The portal Front End is developed by using angular 6 Single page application also lazy loading module has been taken on this to enhance loading performance as shown below 

![image](https://user-images.githubusercontent.com/30432856/57258961-41854300-705e-11e9-9fd7-146862d5af7e.png)


## Out of scope
- User authentication and authorization
- Security layer in the Microservices Architecture
- Unit testing front end portal on old browsers.
- Automation test
- Scalable sql server database architecture
- Dockerize the whole solution.
- Use any free tier on any cloud platform 

## Enhancement
- Use Automapper to map model to ViewModel
- Handle unexpected errors
