USE [GraphData]
GO

/****** Seed new positions ******/
INSERT INTO [dbo].[Positions]
           ([Id]
           ,[Title]
           ,[StartDate]
           ,[EndDate]
           ,[IsActive])
     VALUES
           ('3f10e336-1df8-4eb2-9016-a5cfc7edb283'
           ,N'Track Driver #1'
           ,'2020-11-01 00:00:00'
           ,'2020-12-31 23:59:59'
           ,1)
GO

INSERT INTO [dbo].[Positions]
           ([Id]
           ,[Title]
           ,[StartDate]
           ,[EndDate]
           ,[IsActive])
     VALUES
           ('acce17b8-7a07-481c-835f-d8398e6f9411'
           ,N'Track Driver #2'
           ,'2020-11-01 00:00:00'
           ,'2020-12-31 23:59:59'
           ,1)
GO


INSERT INTO [dbo].[Positions]
           ([Id]
           ,[Title]
           ,[StartDate]
           ,[EndDate]
           ,[IsActive])
     VALUES
           ('9974305e-73d8-4256-ae05-6e8d00464d2d'
           ,N'Track Driver #3'
           ,'2020-11-01 00:00:00'
           ,'2020-12-31 23:59:59'
           ,1)
GO


INSERT INTO [dbo].[Positions]
           ([Id]
           ,[Title]
           ,[StartDate]
           ,[EndDate]
           ,[IsActive])
     VALUES
           ('b3647ddc-37c6-44e1-ba7a-f25621459e12'
           ,N'Track Driver #4'
           ,'2020-11-01 00:00:00'
           ,'2020-12-31 23:59:59'
           ,1)
GO


INSERT INTO [dbo].[Positions]
           ([Id]
           ,[Title]
           ,[StartDate]
           ,[EndDate]
           ,[IsActive])
     VALUES
           ('5b9f9d0e-c1c6-4d7f-bbb7-f9cedf7a0f73'
           ,N'Track Driver #5'
           ,'2020-11-01 00:00:00'
           ,'2020-12-31 23:59:59'
           ,1)
GO

/****** Seed views ******/

/****** Track Driver #1 ******/
USE [GraphData]
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'3f10e336-1df8-4eb2-9016-a5cfc7edb283'
           ,'2020-11-05 11:12:12'
           ,'156.12.13.255')
GO
INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'3f10e336-1df8-4eb2-9016-a5cfc7edb283'
           ,'2020-12-05 03:12:12'
           ,'156.12.13.255')
GO
INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'3f10e336-1df8-4eb2-9016-a5cfc7edb283'
           ,'2020-11-22 17:12:12'
           ,'156.12.13.255')
GO
INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'3f10e336-1df8-4eb2-9016-a5cfc7edb283'
           ,'2020-11-04 11:22:12'
           ,'156.12.13.255')
GO

/****** Track Driver #2 ******/
INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'acce17b8-7a07-481c-835f-d8398e6f9411'
           ,'2020-11-07 13:12:12'
           ,'11.123.13.255')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'acce17b8-7a07-481c-835f-d8398e6f9411'
           ,'2020-12-07 13:12:12'
           ,'11.123.13.255')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'acce17b8-7a07-481c-835f-d8398e6f9411'
           ,'2020-11-08 13:56:12'
           ,'11.123.13.255')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'acce17b8-7a07-481c-835f-d8398e6f9411'
           ,'2020-12-09 13:12:12'
           ,'11.123.13.255')
GO


/****** Track Driver #3 ******/
INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'9974305e-73d8-4256-ae05-6e8d00464d2d'
           ,'2020-11-09 16:12:12'
           ,'11.12.127.255')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'9974305e-73d8-4256-ae05-6e8d00464d2d'
           ,'2020-11-09 17:12:12'
           ,'11.12.127.255')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'9974305e-73d8-4256-ae05-6e8d00464d2d'
           ,'2020-11-05 16:12:23'
           ,'11.12.127.255')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'9974305e-73d8-4256-ae05-6e8d00464d2d'
           ,'2020-11-09 22:12:12'
           ,'11.12.127.255')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'9974305e-73d8-4256-ae05-6e8d00464d2d'
           ,'2020-12-09 16:12:12'
           ,'11.12.127.255')
GO

/****** Track Driver #4 ******/
INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'b3647ddc-37c6-44e1-ba7a-f25621459e12'
           ,'2020-11-20 02:12:12'
           ,'11.12.13.123')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'b3647ddc-37c6-44e1-ba7a-f25621459e12'
           ,'2020-11-06 22:12:12'
           ,'11.12.13.123')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'b3647ddc-37c6-44e1-ba7a-f25621459e12'
           ,'2020-11-07 02:12:12'
           ,'11.12.13.123')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'b3647ddc-37c6-44e1-ba7a-f25621459e12'
           ,'2020-11-20 13:12:12'
           ,'11.12.13.123')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'b3647ddc-37c6-44e1-ba7a-f25621459e12'
           ,'2020-11-05 02:12:12'
           ,'11.12.13.123')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'b3647ddc-37c6-44e1-ba7a-f25621459e12'
           ,'2020-11-03 02:12:12'
           ,'11.12.13.123')
GO
/****** Track Driver #5 ******/
INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'5b9f9d0e-c1c6-4d7f-bbb7-f9cedf7a0f73'
           ,'2020-11-03 15:12:12'
           ,'11.12.13.255')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'5b9f9d0e-c1c6-4d7f-bbb7-f9cedf7a0f73'
           ,'2020-11-07 16:12:12'
           ,'11.12.13.255')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'5b9f9d0e-c1c6-4d7f-bbb7-f9cedf7a0f73'
           ,'2020-11-03 22:12:12'
           ,'11.12.13.255')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'5b9f9d0e-c1c6-4d7f-bbb7-f9cedf7a0f73'
           ,'2020-11-20 15:12:12'
           ,'11.12.13.255')
GO

INSERT INTO [dbo].[PositionViews]
           ([Id]
           ,[PositionId]
           ,[VisitDateTime]
           ,[SourceIpAddress])
     VALUES
           (NEWID()
           ,'5b9f9d0e-c1c6-4d7f-bbb7-f9cedf7a0f73'
           ,'2020-11-22 15:12:12'
           ,'11.12.13.255')
GO