CREATE TABLE [dbo].[Audits] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Action] NVARCHAR (20)  NOT NULL,
    [User]   NVARCHAR (255) NULL,
    [Date]   DATETIME       CONSTRAINT [DF_Audits_Date] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Audits] PRIMARY KEY CLUSTERED ([Id] ASC)
);

