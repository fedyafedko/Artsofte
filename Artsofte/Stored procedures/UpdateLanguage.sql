USE [Artsofte]
GO

/****** Object:  StoredProcedure [dbo].[UpdateLanguage]    Script Date: 7/17/2023 3:30:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[UpdateLanguage] 
    @Id NVARCHAR(max),
    @Name NVARCHAR(max)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Languages WHERE Name = @Id)
    BEGIN
        RAISERROR('Unable to find entity with such key', 16, 1);
        RETURN;
    END;

    BEGIN TRANSACTION;

    BEGIN TRY

        UPDATE Employees
        SET LanguageName = @Name
        WHERE LanguageName = @Id;

        UPDATE Languages
        SET Name = @Name
        WHERE Name = @Id;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
    END CATCH;
END
GO


