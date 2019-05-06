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


