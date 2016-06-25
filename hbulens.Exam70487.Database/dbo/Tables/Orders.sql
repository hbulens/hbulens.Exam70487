CREATE TABLE [dbo].[Orders]
(
	   [Id]          INT            IDENTITY (1, 1) NOT NULL,
	   [CustomerId] INT NOT NULL, 
	   CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC), 
	   CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id])
)
