USE [Artsofte]
GO

/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 7/17/2023 12:27:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[UpdateEmployee]
    @EmployeeID INT,
    @Name NVARCHAR(max),
    @Surname NVARCHAR(max),
    @Age INT,
	@DepartmentFloor INT,
	@LanguageName NVARCHAR(max)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Employees WHERE Id = @EmployeeID)
    BEGIN
        RAISERROR('Unable to find entity with such key', 16, 1);
        RETURN;
    END;
    UPDATE Employees
    SET Name = @Name, Surname = @Surname, Age = @Age, DepartmentFloor = @DepartmentFloor, LanguageName = @LanguageName
    WHERE Id = @EmployeeID
END
GO


