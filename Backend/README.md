#
In order to setup the connection on your local database, you need to follow a few steps.
In SSMS, go to Security -> Right Click on login -> New Login
Make a username for your login, then select SQL Server Authentication
Create a password for your user
Click on User Mapping on the left
Map your user to the CSCE361 Database, and select the db_owner permission at the bottom
Then login on SSMS with your user and password
##
Next open Sql Server Configuration Manager
Click on Sql Server Network Configuration
Click Protocols for SQLEXPRESS
Right click on TCP/IP and then click enable, then click properties.
In properties click IP Address, scroll all the way to IPAII and type 1433 into the TCP Port
Then go back and right click your SQLEXPRESS server and restart it.
##
After creating your user, locate the server.js file in the Backend folder
Replace gmiel and my password with your username and password of your user you created.
