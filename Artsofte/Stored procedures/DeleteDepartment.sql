SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE DeleteDepartment
	 @Floor INT
AS
BEGIN
 SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Departments WHERE Floor = @Floor)
    BEGIN
        RAISERROR('Unable to find employee with such key.', 16, 1);
        RETURN;
    END;
    DELETE FROM Departments
    WHERE Floor = @Floor
END
GO
