USE [Artsofte]
GO

/****** Object:  StoredProcedure [dbo].[DeleteEmployee]    Script Date: 7/17/2023 12:08:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[DeleteEmployee]
    @Id INT
AS
BEGIN
 SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Employees WHERE Id = @Id)
    BEGIN
        RAISERROR('Unable to find employee with such key.', 16, 1);
        RETURN;
    END;
    DELETE FROM Employees
    WHERE Id = @Id
END
GO


