CREATE TABLE [dbo].[Customers] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (255) NOT NULL,
    [LastName]    NVARCHAR (255) NOT NULL,
    [DateOfBirth] DATETIME       NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

