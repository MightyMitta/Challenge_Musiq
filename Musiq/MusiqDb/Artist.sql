CREATE TABLE [dbo].[Artist]
(
	[Artist_Id] INT NOT NULL PRIMARY KEY, 
    [Firstname] VARCHAR(100) NOT NULL, 
    [Middlename] VARCHAR(100) NULL, 
    [Lastname] VARCHAR(100) NOT NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [Image] VARCHAR(100) NULL
)
