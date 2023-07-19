USE [Artsofte]
GO

/****** Object:  StoredProcedure [dbo].[AddDepartment]    Script Date: 7/17/2023 1:21:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER   PROCEDURE [dbo].[AddDepartment]
	@Floor INT,
    @Name NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@Name IS NULL OR @Floor IS NULL)
    BEGIN
        RAISERROR('Not enough data is shown to add a department.', 16, 1);
        RETURN;
    END;

    SET IDENTITY_INSERT Departments ON;

    INSERT INTO Departments(Floor, Name)
    VALUES (@Floor, @Name);

    SET IDENTITY_INSERT Departments OFF;
END;

GO


