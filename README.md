# Full Text and Global Query Filters - Issue with Entity Framework Core 8
This project is related to the [issue 32708  from Entity Framework Core](https://github.com/dotnet/efcore/issues/32708).

## Context
When searching for a Product in the database, the EF Core, which uses Global Query Filters, can't apply Full-text features in a specific case (described in the issue).

## How To Run
- Clone the repository;
- Install Full-Text to your SQL Server;
- Change the connection strings in the "EFCore8FullTextIssueExample" class for your DB connection string;
- Run "update-database" in the Package Manager Console;
- Run the code, it should fail in the Program.cs line 49;
