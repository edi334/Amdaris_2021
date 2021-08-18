CREATE TABLE [dbo].[Country]
(
	[Code] VARCHAR(3) NOT NULL,
	[Name] VARCHAR(255) NOT NULL,
	[Population] BIGINT NOT NULL,
	[Surface_Area] BIGINT NOT NULL,
	CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED ([Code]) 
);

ALTER TABLE [dbo].[Country]
	ADD CONSTRAINT Chk_Population CHECK (Population > 0);

CREATE TABLE [dbo].[Capital]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[CountryCode] VARCHAR(3) NOT NULL,
	[Name] VARCHAR(255) NOT NULL,
	[FoundationDate] DATE DEFAULT GETDATE() 
);

ALTER TABLE [dbo].[Capital] ADD CONSTRAINT [Capital_Country] FOREIGN KEY ([CountryCode]) REFERENCES [dbo].[Country] ([Code]) ON DELETE CASCADE ON UPDATE NO ACTION;

INSERT INTO dbo.Country (Code, Name, Population, Surface_Area)
VALUES ('RO', 'Romania', 19410000, 238397);

INSERT INTO dbo.Country (Code, Name, Population, Surface_Area)
VALUES ('HUN', 'Hungary', 9773000, 93030);

INSERT INTO dbo.Capital (CountryCode, Name, FoundationDate)
VALUES ('RO', 'Bucharest', DATEADD(year, -100, GETDATE()));

INSERT INTO dbo.Capital (CountryCode, Name, FoundationDate)
VALUES ('HUN', 'Budapest', DATEADD(year, -200, GETDATE()));