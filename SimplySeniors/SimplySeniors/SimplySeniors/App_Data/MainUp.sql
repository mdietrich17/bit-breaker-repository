CREATE TABLE [dbo].[Profile]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[FIRSTNAME] NVARCHAR (50) NOT NULL,
	[LASTNAME] NVARCHAR (50) NOT NULL,
	[BIRTHDAY] DATE NOT NULL,
	[LOCATION] NVARCHAR (128) NOT NULL,
	[VETSTATUS] BIT,
	[OCCUPATION] NVARCHAR (128) NOT NULL,
	[FAMILY] NVARCHAR (128), /*Probably needs to make a new table if we want to add feature*/ 
	[BIO] NVARCHAR (2048)
	CONSTRAINT [PK_dbo.Profiles] PRIMARY KEY CLUSTERED ([ID] ASC)
	/**
	FOR FUTURE USE PROBABLY
	CONSTRAINT [FK_dbo.Profiles_dbo.Friends_FriendsID] FOREIGN KEY ([FriendsID]) REFERENCES dbo.Friends ([ID])
	CONSTRAINT [FK_dbo.Profiles_dbo.Groups_GroupID] FOREIGN KEY ([GroupID]) REFERENCES dbo.Groups ([ID])
	**/
);


/****** SEED DATA ******/

INSERT INTO [dbo].[Profile] (FIRSTNAME, LASTNAME, BIRTHDAY, LOCATION, VETSTATUS, OCCUPATION, FAMILY, BIO) VALUES
	('Chris', 'Columbus', '1451-09-01', 'Bahamas', 0, 'Explorer', 'Chris Jr.' ,'I discovered india guys i swear'),
	('Ferdinand', 'Magellan', '1480-02-03', 'Chile', 0, 'Explorer','Ferdinand Jr.', 'I will go around the world guys srsly'),
	('Juan', 'de Fuca', '1536-02-11', 'Vancouver Island', 0, 'Explorer', 'Juan Jr.', 'I found a really rainy place' ),
	('Leif', 'Eriksson', '0970-11-15', 'Vinland', 1, 'Viking turned Explorer','Leif Liefsson', 'I found Canada, pretty cool eh?' ),
	('Marco', 'Polo', '1254-01-08', 'Peking', 0, 'Explorer turned pool game', 'MARCO! POLO!', 'Mongolia rough yo'),
	('Sacagawea', 'Shoshone', '1788-05-01', 'Astoria', 0, 'Actual Explorer', 'Sacagawea but on a coin', 'I led dudes accross the United States')
