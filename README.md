# WebApi
Web API sample
Simple .NET Core Web API application handling Product requests.

### Prerequisities
* Visual Studio 2017
### How to run
* Clone this repository to Visual Studio
* Update Database using eg. Package Manager Console in VS 
  * For details see [Microsoft docs](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/#update-the-database)
  * This creates DB structure and inserts data from prepared seed
* Build and run in VS
  * You should get to /swagger page
  * Currently exists only version 1, so take care of that when using swagger
  * Provide description text in the quotation marks when updating description of the Product
  
* Unit Tests
  * Just use [Test Explorer](https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2017) in VS
