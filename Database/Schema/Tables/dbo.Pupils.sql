CREATE TABLE [dbo].[Pupils]
(
[PupilId] [int] NOT NULL IDENTITY(1, 1),
[FirstName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LastName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Address1] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Adderss2] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PostalZipCode] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[City] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[PhoneNumber] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SchoolId] [int] NOT NULL,
[Picture] [varbinary] (max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pupils] ADD CONSTRAINT [PK_PupilId] PRIMARY KEY CLUSTERED  ([PupilId]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex_ZipCode] ON [dbo].[Pupils] ([PostalZipCode]) INCLUDE ([FirstName], [LastName], [PupilId]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex_SchoolId] ON [dbo].[Pupils] ([SchoolId]) INCLUDE ([Adderss2], [Address1], [City], [FirstName], [LastName], [PhoneNumber], [PostalZipCode], [PupilId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pupils] ADD CONSTRAINT [FK_SchoolId] FOREIGN KEY ([SchoolId]) REFERENCES [dbo].[Schools] ([SchoolId])
GO
