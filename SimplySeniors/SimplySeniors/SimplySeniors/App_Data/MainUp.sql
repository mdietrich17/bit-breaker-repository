CREATE TABLE [dbo].[Profile]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[FIRSTNAME] NVARCHAR (50) NOT NULL,
	[LASTNAME] NVARCHAR (50) NOT NULL,
	[BIRTHDAY] DATE NOT NULL,
	[LOCATION] NVARCHAR (128) NOT NULL,
	[VETSTATUS] BIT,
	[BIO] NVARCHAR (2048)
	CONSTRAINT [PK_dbo.Profiles] PRIMARY KEY CLUSTERED ([ID] ASC)
);


/****** SEED DATA ******/

INSERT INTO [dbo].[Profile] (FIRSTNAME, LASTNAME, BIRTHDAY, LOCATION, VETSTATUS, BIO) VALUES
	('Chris', 'Columbus', '1451-09-01', 'Bahamas', 0, 'I discovered india guys i swear'),
	('Ferdinand', 'Magellan', '1480-02-03', 'Chile', 0, 'I will go around the world guys srsly'),
	('Juan', 'de Fuca', '1536-02-11', 'Vancouver Island', 0, 'I found a really rainy place' ),
	('Leif', 'Eriksson', '0970-11-15', 'Vinland', 1, 'I found Canada, pretty cool eh?' ),
	('Marco', 'Polo', '1254-01-08', 'Peking', 0, 'Mongolia rough yo'),
	('Sacagawea', 'Shoshone', '1788-05-01', 'Astoria', 0, 'I led dudes accross the United States')
