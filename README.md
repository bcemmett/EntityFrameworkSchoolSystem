# Entity Framework School System

## About
This application illustrates a series of performance problems which are commonly encountered when using Entity Framework. It is designed to accompany the article at https://www.simple-talk.com/dotnet/.net-tools/entity-framework-performance-and-what-you-can-do-about-it/.

It's built around a SQL Server database with two tables, storing details of Schools and the Pupils who attend them. A WinForms application has an Entity Framework code first model of this database, and some code to access information from it. In all cases, it does this data access inefficiently.

## Setup
1. Clone this repository.
2. Create a new SQL Server database called `EFSchoolSystem` using collation `SQL_Latin1_General_CP1_CI_AS`. I'd recommend using the Simple Recovery Model to save on disk space, as backup considerations aren't important. If possible I'd recommend using a real instance of SQL Server rather than LocalDB, SQL Express, or Azure SQL Database.
3. Create the schema. If you have Redgate's [SQL Compare](http://www.red-gate.com/products/sql-development/sql-compare/), you can select to compare from Source Control (Scripts folder – choose the `/Database/Schema` folder) to your blank database. Alternatively you can run `/Database/Schema/Tables/dbo.Schools.sql` followed by `/Database/Schema/Tables/dbo.Pupils.sql`.
4. Populate some sample data. If you have Redgate's [SQL Data Generator](http://www.red-gate.com/products/sql-development/sql-data-generator/), you can open the `/Database/SampleData.sqlgen` project file and click Generate Data, which will create some realistic sample data (this may take several minutes). You may need to first edit the file to change the `ServerName` / `DatabaseName` / `Username` / `Password` fields. You may also want to tune the amount of sample data generated depending on the specs of your machine. If you don’t have Sql Data Generator you can download a free trial, or write your own scripts to generate a few million rows.
5. Open the` EntityFrameworkSchoolSystem.sln` solution in Visual Studio. In `App.config`, modify the connection string to point to your database. Build the application (ideally as debug) and run it. Check everything's working by ensuring you get some data back when  clicking Button 1.

## Performance problems
Eight common issues are demonstrated - there's a detailed explanation of each at https://www.simple-talk.com/dotnet/.net-tools/entity-framework-performance-and-what-you-can-do-about-it/. You can see all of these in action by profiling the application using [ANTS Performance Profiler](http://www.red-gate.com/products/dotnet-development/ants-performance-profiler/). Having installed ANTS, click `New profiling session`, select `.NET executable`, and browse to the built application.

1. Retrieving more data than needed
2. N+1 select issues
3. Retrieving more columns than needed
4. Mismatched data types
5. Missing indexes
6. Generic queries
7. Generating unparameterised queries
8. Change detection and unbatched insert statements
