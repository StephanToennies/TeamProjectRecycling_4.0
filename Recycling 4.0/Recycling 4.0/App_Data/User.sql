CREATE TABLE [dbo].[Table]
(
	[Username] VARCHAR(MAX) NOT NULL PRIMARY KEY, 
    [Password] VARCHAR(MAX) NOT NULL, 
    [Credits] INT NOT NULL DEFAULT 0
)
