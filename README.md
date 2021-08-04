# Remarks

- Application is refactored to implement **CQRS** pattern based on **Domain Driven Design** approach and keep **onion architecture**.
    - To achieve that, in application is installed `MediatR` package with manually added wrappers to separate `Queries`, `Commands`, `QueryHandlers` and `CommandHandlers`
    - There is only one bounded context
      - `Company` has annual bonus pool and list of `Employees` working in the company
      - Each `Employee` could be assigned to only one `Company` and also be in `Department`
      - `Department` has it's own identity within the context
    
## Key advantages of that refactor

- Solution is appropriate to the problem - reading and writing needs was different in that case
- Supports Single Responsibility Principle (SRP) - one handler does one thing
- Supports Interface Segregation Principle (ISP) - each handler implements interface with exactly one method
- Supports Parameter Object pattern - Commands and Queries are objects which are easy to serialize/deserialize
- Supports Loose Coupling by use of the Mediator pattern - separates invoker of request from handler of request
- Immutability of `Requests`, `Queries`, `Commands`, `Responses`
- Applied decorator patern using `PipelineBehaviors` from `MediatR` to:
    - Save changes on database after updating
    - Validation on query / commands using `FluentValidation` library
- Every dependency is registered using Dependency Injection automatically, based on implemented interfaces. To do that, I used library called `Scrutor`.
- I added repository layer, which encapsulates all operations instead of getting DbContext in the Service as it was before.
- Every business logic is encapsulated in Domain layer

## Solution structure

- Application - the application logic project which is responsible for requests processing 
- Domain - Domain Model in Domain-Driven Design terms implements the applicable Bounded Context and keeps business logic
- Persistence - contains data access layer
- Api - presentation layer of the solution, which contains no application logic, only receives data and sends it to proper query or command handlers
- Tests.Unit - unit tests

## Request processing

- Commands are processed on database using Entity Framework and by doing operations on aggregate after persisting it from database
- Queryies are also processed on database using Entity Framework but using projection, which is querying on database only data which we need, not whole aggregates and also while doing that, the `ChangeTracker` is turned off by `AsNoTracking` on database set. 
    - Queries could be also processed without using ORM, for example simple `Dapper` package
    - ProjectTo is working better on the SQL Server, on InMemoryDatabase probably it's not working as expected
    
## REST

Solution is now RESTful. It has a proper endpoint convention and is returning a results which we are expected looking on the endpoint path.
    
## Swagger

I also extended a swagger. Right now it shows a summary which are good description for endpoints and also a request body when updating a company bonus pool.

## The task itself

Application is refactored and it adheres SOLID principles.

API returns a `Bad Request` when `EmployeeId` is not specified (or specified 0) **but** I disagree that it should returns `Bad Request` when `Employee` is not found in database. To handle that, the API returns a proper status code - `404 Not Found` with a short description.

The calculations of employee bonus are unit tested, and also solution is prevented of `DivideByZeroException`.

It works.

## How to test that?

Run the API and Swagger will open. Data is already seed with only one company which has `Id` equals `1` and `BonusPool` equals `50000`. You can change the bonus pool for the company, list all employees in the company or get specified employee from company which will has calculated bonus based on the annual bonus pool of company.

---

# Synetec Basic .Net API assessement

This is Synetec's basic API developer assessment.

If you are reading this, you most probably have been asked to complete this assessment as part of Synetec's interview process.

In this repository, you will find the base project and instructions on what to do with them. 

## How to complete this test

Please follow the instructions in the Instructions.pdf, found in this repository

## How to submit your completed test

To sumbit your test, please 
1. Fork this repository
2. Complete the test as per the instructions PDF 
3. Commit your changes to your (forked) repo 
4. Send us an http link to your repo that contains the completed test 

**This repo is Read-Only!!** So please don't try to open a pull request
