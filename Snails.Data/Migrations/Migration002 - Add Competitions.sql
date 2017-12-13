CREATE TABLE Competitions (
	[Id] int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(100) NOT NULL,
	[DateCompleted] datetime2 NULL,
	[WinnerId] nvarchar(50) NULL
);

ALTER TABLE Competitions WITH CHECK ADD  CONSTRAINT [FK_Competitions_Snails] FOREIGN KEY([WinnerId])
REFERENCES [dbo].[Snails] ([Id]);

CREATE TABLE SnailsCompetitions (
	[CompetitionId] int NOT NULL,
	[SnailId] nvarchar(50) NOT NULL,
	PRIMARY KEY CLUSTERED (
		[CompetitionId] ASC,
		[SnailId] ASC
	)
);

ALTER TABLE SnailsCompetitions WITH CHECK ADD  CONSTRAINT [FK_SnailsCompetitions_Snails] FOREIGN KEY([SnailId])
REFERENCES [dbo].[Snails] ([Id]);


ALTER TABLE SnailsCompetitions  WITH CHECK ADD  CONSTRAINT [FK_SnailsCompetitions_Competitions] FOREIGN KEY([CompetitionId])
REFERENCES [dbo].[Competitions] ([Id]);
