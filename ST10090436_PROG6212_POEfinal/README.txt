

		*** How to run the application. ***

1.  Open the file containing the code, once opened in Visual Studio you will need to go to each back
	end of each page and change the connection string for the code to interact with you database.

2.  Once you have changed the conenction strings in the double quotes you are then able to press the 
	play button next to the file name, at the top of VS Code. Click that button to build and start the application.

3.  Once the application has opened, Click either Register or Login, If you have never used the application 
	before then you will have to Register but if you already have an account you may click on Login.
3.1 If you have chosen register create a username and password then click submit once submitted you will be 
	send to the login Page where you must re enter the credentials.
3.2  If you have chosen Login, if your infromation is correct you will be sent to the Modules Page where it 
	will only have your infromation and no one elses.

4.  If you would like to add modules to your list, Click on the Add modules button which will then take you 
	to a page where you are able to add all the information needed for your modules. Once you are done, 
	Click on submit and be redirected to the modules page, you may enter as many modules as you would like. 

5.  The new added feature would be the delete, if you click on delete the row  will be deleted on the Database
	side and no longer show on the website.

6.  If you would like to see how many hours of self study and remaining hours you can click on the Check hours
	button at the bottom left of Modules Page. 


	*** IF YOU ARE HAVING A PROBLEM WITH THE DATABASE ***

	*** How to Interact with the Sql Database Data. ***


1.  When opening the Visual Studio, you will want to click on view at the top left of the VS application then 
	click on SQL SERVER OBJECT EXPLORER, go to the local database and see that the database is ther called UserData.
	IF the database is not there you can create the database and add the following code this is just to ensure the 
	aplication works on your end. 

	*** This is for the Table Users ***
	CREATE TABLE [dbo].[tblUser] (
    [Username] VARCHAR (50) NOT NULL,
    [Password] VARCHAR (20) NOT NULL
);
	
	*** This is for the Table Modules ***
	CREATE TABLE [dbo].[tblModules] (
    [ModuleCode]   VARCHAR (8)   NOT NULL,
    [ModuleName]   VARCHAR (150) NOT NULL,
    [NumOfCredits] INT           NOT NULL,
    [HoursPerWeek] INT           NOT NULL,
    [StartDate]    DATE          NOT NULL,
    [NumOfWeeks]   INT           NOT NULL,
    [Username]     VARCHAR (50)  NOT NULL,
    CONSTRAINT [FK_UserModule] FOREIGN KEY ([Username]) REFERENCES [dbo].[tblUser] ([Username])
);

2. Once both of the tables have been created you may update the database and run the application. 