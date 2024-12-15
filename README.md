# GroceryApp
Grocery Store App for CSCE 361

# SQL setup instructions
This creates a database called CSCE361 and its tables.
It also populates the tables with some dummy data.
Feel free to add your own.

*This script will drop all the tables and re-create them whenever it is run*

1. Open SQL Server Management Studio.
1. Don't change any settings, just click connect at the bottom left of the pop-up.
1. Copy "361 script.sql" from the GroceryApp Folder containing the solution.
1. Run the script in SQL Server Management Studio.

This should set up your local instance of the database.
You will need to keep SQL Server Management Studio running in the background whenever you are accessing the database.

---
You may need to install Microsoft.Data.SqlClient on your own machine.
To do so
1. Open the project in Visual Studio 2022.
2. Select project from drop down menu.
3. Select Manage NuGet Packages...
4. Search for and install Microsoft.Data.SqlClient

# Backend - Frontend Instructions
Make sure your SQL database is running
Navigate to the GroceryAppAPI folder in visual studio terminal
Run these commands
"dotnet restore"
"dotnet run"
Should say something such as "Now Listening on: http://localhost:5156"
Open a seperate terminal like cmd and navigate to the JSX_Pages folder
Run "npm start"
Should open a browser running "http://localhost:3000" where our frontend is hosted

## Finding API Endpoint information
Go to http://localhost:5156/api/* to find the JSON format for the data.
Change the "*" in the link to products or cart or whatever endpoint you want to see
Example: "http://localhost:5156/api/product"



