/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


INSERT INTO [dbo].[Customers]([FirstName],[LastName])VALUES('Hendrik','Bulens')
INSERT INTO [dbo].[Customers]([FirstName],[LastName])VALUES('Donald','Trump')
INSERT INTO [dbo].[Customers]([FirstName],[LastName])VALUES('James','Hetfield')
INSERT INTO [dbo].[Customers]([FirstName],[LastName])VALUES('Kurt','Cobain')
INSERT INTO [dbo].[Customers]([FirstName],[LastName])VALUES('Homer','Simpson')
INSERT INTO [dbo].[Customers]([FirstName],[LastName])VALUES('Harvey','Specter')
INSERT INTO [dbo].[Customers]([FirstName],[LastName])VALUES('Walter','White')

GO
