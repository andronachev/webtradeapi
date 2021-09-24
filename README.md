# webtradeapi

Projects description: 

WebTrade.Core 
	- holds the business domain entities and interfaces to be implemented in either infrastructure layer or business layer 

WebTrade.Infrastructure 
	- holds the implementations that are infrastructure related i.e. repositories using SQL or in-memory, email service, caching service etc 
	- should only reference the core
WebTrade.Services
	- holds implementations of services defining the business logic
	- also holds the validation logic of the system. The scope was to not leave the validation on the "UI" (in this case the API project), in order 
	to have it reusable 
	- the business layer references the Core and Infrastructure

WebTrade.Tests
	- TODO: add it 

WebTrade.Api 
	- is the ASP.NET Core API project, can be run in IISExpress out of the box or in IIS 
	- the latest .NET Core 5 project template seems that it scafolded the API with Swagger UI out of the box, but I was going to install it myself. Swagger
	- it references the Core, Infrastructure and Services layer and configures the services tree for dependency injection 
	provides an interactive generated UI for the API, but also has the capability of generating metadata that later can automatically generate a .NET SDK 

# validation system 

The validation is conceptually placed in the Services layer in order to have it reusable. The 'clients', be it API, Dektop or Web MVC can handle 
the validation system and display errors to the errors to the user appropriately. In this case the API project has an ErrorHandlerMiddleware which
intercepts the 'ValidationException' types of exception and returns error code 400 along with the error message. 

Improvements for a "real life scenario": I would still keep the validation in the Services layer but not implement it bluntly with Exceptions throwing, but the purpose of this project
was to illustrate the concept. 

#infrastructure layer 

In a real life scenario I would propose to use something like Automapper to map between storage types and the types defined in the Core project. For example the 
Security entity in the Infrastructure layer would probably be defined by an Entity Framework model class (assume we would use SQL and EF Code First) so then we would
need to map the results to the Security entity from Core, as to not use infrastructure types in the system 

#services layer 

Related to the PortofolioService, my main concern in real life would be the performance and queryability of the GetAllPortofolios().. i.e. it would 
need to support filtering, pagination and ordering, hence the current implementation would not suit that. Also of course from performance 
point of view this implementation is naive. In real life I would try to think of a queryable storage where the portofolios may be maintained as 
new trades come in

#Tests project 

Unit Tests implemented using MS Test framework and MOQ for mocking  