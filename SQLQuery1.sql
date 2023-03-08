DROP TABLE [dbo].[Users]
go
CREATE TABLE [dbo].[Users] (
    [Id]       INT PRIMARY KEY IDENTITY (1,1)           NOT NULL,
    [Username] NVARCHAR (50)  NOT NULL,
    [UserPassword] NVARCHAR (100) NULL,
    [Salt]     NVARCHAR (50)  NULL,
);