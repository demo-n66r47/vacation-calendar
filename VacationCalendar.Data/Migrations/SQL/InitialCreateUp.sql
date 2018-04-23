
CREATE TRIGGER [dbo].[tgVacation] 
   ON  [dbo].[Vacation]
   AFTER INSERT, UPDATE
AS 
BEGIN
	SET NOCOUNT ON

	IF EXISTS
	(
		SELECT 1
		FROM inserted i
			INNER JOIN [Vacation] t ON t.[EmployeeID] = i.[EmployeeID]
				AND t.[DateFrom] < i.[DateTo]
				AND t.[DateTo] > i.[DateFrom]
				AND t.[ID] <> i.[ID]
	)
	BEGIN
		RAISERROR ('Vacation period overlaps with existing.',16,1)
		RETURN
	END

END
GO

ALTER TABLE [dbo].[Vacation] ENABLE TRIGGER [tgVacation]
GO

ALTER TABLE [dbo].[Vacation] ADD CONSTRAINT [CK_DateFromTo] CHECK ( [DateTo] > [DateFrom] )
GO


CREATE PROCEDURE [dbo].[spGetCalendar]
(
	@year int,
	@month int
)
AS

	SELECT e.[ID], e.[FirstName], e.[LastName], d.[ID] [Day], v.[VacationType]
	FROM [dbo].[Employee] e
		CROSS JOIN [Helper].[Day] d
		LEFT OUTER JOIN [dbo].[Vacation] v ON e.[ID] = v.[EmployeeID] AND
			v.[DateFrom] <= dateadd( month, ((@year-1900)*12)+@month-1, d.[ID]-1 ) AND
			v.[DateTo] > dateadd( month, ((@year-1900)*12)+@month-1, d.[ID]-1 )
	ORDER BY e.[FirstName], e.[LastName], d.[ID]

GO


DECLARE @day int = 1
WHILE @day <= 31
BEGIN
	INSERT INTO [Helper].[Day] ( [ID] ) VALUES ( @day )
	SET @day += 1
END

GO
