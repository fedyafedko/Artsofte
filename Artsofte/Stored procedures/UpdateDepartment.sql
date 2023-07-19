SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE UpdateDepartment 
	 @Floor INT,
	 @Name NVARCHAR(max)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Departments WHERE Floor = @Floor)
    BEGIN
        RAISERROR('Unable to find entity with such key', 16, 1);
        RETURN;
    END;
    UPDATE Departments
    SET @Floor = @Floor, Name = @Name
    WHERE Floor = @Floor
END
GO
