USE [GraphData]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetGraphData]    Script Date: 12/12/2020 13:03:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Anton Asnitsky
-- Create date: 12/12/2020 13:03:07
-- Description:	Procedure that returns data for graph
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetGraphData]
	@FromDate datetime,
	@ToDate datetime
AS
BEGIN
	SELECT d.RequestDate,COUNT(p.Id) AS PositionsCount
	FROM (
		SELECT convert(varchar, IndividualDate, 105) AS RequestDate, IndividualDate
		FROM [dbo].[DateRange]('d', @FromDate, @ToDate)
	) d, Positions p
	GROUP BY d.RequestDate

	SELECT d.RequestDate,COUNT(pw.Id) AS ViewsCount
	FROM (
		SELECT convert(varchar, IndividualDate, 105) AS RequestDate, IndividualDate
		FROM [dbo].[DateRange]('d', @FromDate, @ToDate)
	) d, PositionViews pw
	GROUP BY d.RequestDate
END
GO

