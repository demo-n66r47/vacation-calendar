
ALTER TABLE [dbo].[Vacation] DROP CONSTRAINT [CK_DateFromTo]
GO

ALTER TABLE [dbo].[Vacation] DISABLE TRIGGER [tgVacation]
GO

DROP TRIGGER [dbo].[tgVacation]
GO

DROP PROCEDURE [dbo].[spGetCalendar]
GO
