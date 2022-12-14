USE [PlacesDatabase]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 29.9.2022. 19:56:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](450) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Places]    Script Date: 29.9.2022. 19:56:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Places](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](450) NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Places] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name]) VALUES (1, N'CROATIA')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (2, N'SERBIA')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (6, N'GERMANY')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Places] ON 

INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (1, N'KNIN', N'343433', 1)
INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (3, N'TRILJ', N'5443344', 1)
INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (4, N'NOVI SAD', N'80101', 2)
INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (5, N'PANCEVO', N'85101', 2)
INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (7, N'MAINZ', N'23233', 6)
SET IDENTITY_INSERT [dbo].[Places] OFF
GO
ALTER TABLE [dbo].[Places]  WITH CHECK ADD  CONSTRAINT [FK_Places_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Places] CHECK CONSTRAINT [FK_Places_Countries_CountryId]
GO
