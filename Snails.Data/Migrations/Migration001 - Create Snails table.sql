CREATE TABLE [dbo].[Snails](
	[Id] [nvarchar](50) PRIMARY KEY  NOT NULL,
	[ShellRadius] [decimal](18, 2) NULL,
	[Length] [decimal](18, 2) NOT NULL,
	[IsAlive] [bit] NOT NULL
)
