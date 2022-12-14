USE [PlacesDatabase]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 30.9.2022. 23:03:08 ******/
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
/****** Object:  Table [dbo].[Places]    Script Date: 30.9.2022. 23:03:08 ******/
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
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (7, N'AUSTRIA')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (8, N'LUXEMBURG')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (9, N'ITALY')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (10, N'GREECE')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (11, N'CYPRUS')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (12, N'SLOVENIA')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (13, N'MONTENEGRO')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (14, N'SWEEDEN')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (15, N'NORWAY')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (16, N'FINLAND')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Places] ON 

INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (1, N'KNIN', N'343433', 1)
INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (3, N'TRILJ', N'5443344', 1)
INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (4, N'NOVI SAD', N'80101', 2)
INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (5, N'PANCEVO', N'85101', 2)
INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (7, N'MAINZ', N'23233', 6)
INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (8, N'PODGORICA', N'2324423', 13)
INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (9, N'ROME', N'23654423', 9)
INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (10, N'MILANO', N'23658773', 9)
INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (11, N'LJUBLJANA', N'23608773', 12)
INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (12, N'KRAPINA', N'2322222', 1)
INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (13, N'KRIZEVCI', N'23234332', 1)
INSERT [dbo].[Places] ([Id], [Name], [ZipCode], [CountryId]) VALUES (14, N'MARIBOR', N'234345389', 12)
SET IDENTITY_INSERT [dbo].[Places] OFF
GO
ALTER TABLE [dbo].[Places]  WITH CHECK ADD  CONSTRAINT [FK_Places_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Places] CHECK CONSTRAINT [FK_Places_Countries_CountryId]
GO
