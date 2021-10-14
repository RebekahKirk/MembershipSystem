To run this project you will need to install the following:
	Azure function tools - https://www.npmjs.com/package/azure-functions-core-tools
	SQL Server Express - https://www.microsoft.com/en-gb/sql-server/sql-server-downloads
	Postman - https://www.postman.com/downloads/

Git Repository URL - https://github.com/RebekahKirk/MembershipSystem.git


How to run the solution:
1. Open a local server through SQL Management studio.
2. Create a new SQL database on the local server named "contract-bfohpc" .
3. Use the migration scripts which can be found in the Github repository to create the table and stored procedure in SQL.
4. Use command window to clone the git repository and download a local copy of the solution. 
5. In the command window, change directory (CD) into the project folder and use FUNC start --csharp to run the solution. 

Tests are to be carried out using Postman. A new collection can be opened for this solution and a new request for each of the tests detailed on the test plan can be
completed manually or the .json file provided can be imported directly into Postman. 