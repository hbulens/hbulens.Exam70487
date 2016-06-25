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

INSERT [dbo].[Customers] ([FirstName], [LastName], [DateOfBirth]) VALUES (1, N'Hercules', N'Rockefeller', NULL)
INSERT [dbo].[Customers] ([FirstName], [LastName], [DateOfBirth]) VALUES (2, N'Handsome B.', N'Wonderful', NULL)
INSERT [dbo].[Customers] ([FirstName], [LastName], [DateOfBirth]) VALUES (3, N'Rembrandt Q.', N'Einstein', NULL)
INSERT [dbo].[Customers] ([FirstName], [LastName], [DateOfBirth]) VALUES (4, N'Max', N'Power', NULL)

INSERT [dbo].[Orders] ([CustomerId]) VALUES (1)
INSERT [dbo].[Orders] ([CustomerId]) VALUES (2)
INSERT [dbo].[Orders] ([CustomerId]) VALUES (3)
INSERT [dbo].[Orders] ([CustomerId]) VALUES (4)


GO
