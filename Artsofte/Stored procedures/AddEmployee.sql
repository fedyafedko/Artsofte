USE [Artsofte]
GO

/****** Object:  StoredProcedure [dbo].[AddEmployee]    Script Date: 7/17/2023 11:53:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[AddEmployee]
    @Name NVARCHAR(MAX),
    @Surname NVARCHAR(MAX),
    @Age INT,
    @Gender NVARCHAR(MAX),
    @DepartmentFloor INT,
    @LanguageName NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@Name IS NULL OR @Surname IS NULL OR @Age IS NULL OR @Gender IS NULL OR @DepartmentFloor IS NULL OR @LanguageName IS NULL)
    BEGIN
        RAISERROR('There is not enough data to add an employee.', 16, 1);
        RETURN;
    END;

    INSERT INTO Employees (Name, Surname, Age, Gender, DepartmentFloor, LanguageName)
    VALUES (@Name, @Surname, @Age, @Gender, @DepartmentFloor, @LanguageName);
END;
GO
