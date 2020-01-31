CREATE TABLE [dbo].[Coaches]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[NAME] NVARCHAR (50) NOT NULL
	CONSTRAINT [PK_dbo.Coaches] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Teams]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[NAME] NVARCHAR (50) NOT NULL,
	[CoachID] INT,
	CONSTRAINT [PK_dbo.Teams] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Teams_dbo.Coaches_ID] FOREIGN KEY ([CoachID]) REFERENCES [dbo].[Coaches] ([ID])

);

CREATE TABLE [dbo].[Athletes]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[NAME] NVARCHAR (50) NOT NULL,
	[GENDER] NVARCHAR (20) NOT NULL,
	[TeamID] INT,
	CONSTRAINT [PK_dbo.Athletes] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Athletes_dbo.Teams_ID] FOREIGN KEY ([TeamID]) REFERENCES [dbo].[Teams] ([ID])
);

CREATE TABLE [dbo].[Meets]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[LOCATION] NVARCHAR (50) NOT NULL,
	[DATE] NVARCHAR (50) NOT NULL,
	CONSTRAINT [PK_dbo.Meets] PRIMARY KEY CLUSTERED ([ID] ASC),
);

CREATE TABLE [dbo].[RaceResults]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[NAME] NVARCHAR (50) NOT NULL,
	[TIME] REAL NOT NULL,
	[MeetID] INT,
	[AthleteID] INT,
	CONSTRAINT [PK_dbo.RaceResults] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.RaceRusults_dbo.Meets_ID] FOREIGN KEY ([MeetID]) REFERENCES [dbo].[Meets] ([ID]),
	CONSTRAINT [FK_dbo.RaceResults_dbo.Athletes_ID] FOREIGN KEY ([AthleteID]) REFERENCES [dbo].[Athletes] ([ID])
);

/******* SEED DATA *******/

INSERT INTO [dbo].[Coaches] (NAME) VALUES
	('Franklin'),
	('Joseph'),
	('Adolf');

INSERT INTO [dbo].[Teams] (NAME, CoachID) VALUES
	('Allies', '1'),
	('Commiterm', '2'),
	('Axis', '3');

INSERT INTO [dbo].[Athletes] (NAME, GENDER, TeamID) VALUES
	('Dwight Eisenhower', 'Boys', '1'),
	('Rosie Riveter', 'Girls', '1'),
	('Georgy Zhukov', 'Boys', '2'),
	('Konstantin Rokossovsky', 'Boys', '2'),
	('Erwin Rommel', 'Boys', '3'),
	('Eva Braun', 'Girls', '3');

INSERT INTO [dbo].[Meets] (LOCATION, DATE) VALUES

	('Tehran', '1943-11-28 00:00:00'),
	('Yalta', '1945-02-04 00:00:00'),
	('Potsdam', '1945-07-17 00:00:00');

INSERT INTO [dbo].[RaceResults] (NAME, TIME, MeetID, AthleteID) VALUES
	('100', 120, '1', '1'),
	('100', 125, '2', '3'), 
	('200', 250, '1', '2'),
	('200', 245, '3', '6'),
	('500', 650, '2', '4'),
	('500', 660, '3', '5'),
	/*duplicate to test distinct names*/
	('100', 100, '1', '1'),
	('100', 160, '2', '3'), 
	('200', 230, '1', '2'),
	('200', 246, '3', '6'),
	('500', 662, '2', '4'),
	('500', 672, '3', '5'),
	/*even more seed data*/
	('500', 635, '1', '1'),
	('500', 628, '2', '3'),
	('200', 262, '1', '2'),
	('200', 272, '3', '6'),
	('100', 145, '2', '4'),
	('200', 252, '2', '4'),
	('500', 665, '3', '6'),
	('200', 213, '1', '1'),
	('100', 126, '3', '5'); 

