USE [GraphData]
GO

/****** Object:  Table [dbo].[PositionViews]    Script Date: 12/11/2020 18:50:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PositionViews](
	[Id] [uniqueidentifier] NOT NULL,
	[PositionId] [uniqueidentifier] NOT NULL,
	[VisitDateTime] [datetime] NOT NULL,
	[SourceIpAddress] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_PositionViews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PositionViews]  WITH CHECK ADD  CONSTRAINT [FK_PositionViews_Positions] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([Id])
GO

ALTER TABLE [dbo].[PositionViews] CHECK CONSTRAINT [FK_PositionViews_Positions]
GO


