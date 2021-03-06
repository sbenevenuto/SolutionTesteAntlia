USE [WCITesteAntlia]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 19/01/2019 21:03:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ManualMovements]    Script Date: 19/01/2019 21:03:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManualMovements](
	[CreateDate] [datetime2](7) NOT NULL,
	[ModifieldDate] [datetime2](7) NOT NULL,
	[ManualMovementId] [int] IDENTITY(1,1) NOT NULL,
	[Month] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductCosifId] [int] NOT NULL,
	[Value] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_ManualMovements] PRIMARY KEY CLUSTERED 
(
	[ManualMovementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductCosif]    Script Date: 19/01/2019 21:03:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCosif](
	[CreateDate] [datetime2](7) NOT NULL,
	[ModifieldDate] [datetime2](7) NOT NULL,
	[ProductCosifId] [int] IDENTITY(1,1) NOT NULL,
	[CodProductCosif] [int] NOT NULL,
 CONSTRAINT [PK_ProductCosif] PRIMARY KEY CLUSTERED 
(
	[ProductCosifId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 19/01/2019 21:03:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[CreateDate] [datetime2](7) NOT NULL,
	[ModifieldDate] [datetime2](7) NOT NULL,
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190119213211_Initial', N'2.1.1-rtm-30846')
ALTER TABLE [dbo].[ManualMovements]  WITH CHECK ADD  CONSTRAINT [FK_ManualMovements_ProductCosif_ProductCosifId] FOREIGN KEY([ProductCosifId])
REFERENCES [dbo].[ProductCosif] ([ProductCosifId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManualMovements] CHECK CONSTRAINT [FK_ManualMovements_ProductCosif_ProductCosifId]
GO
ALTER TABLE [dbo].[ManualMovements]  WITH CHECK ADD  CONSTRAINT [FK_ManualMovements_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManualMovements] CHECK CONSTRAINT [FK_ManualMovements_Products_ProductId]
GO
