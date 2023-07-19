USE [Artsofte]
GO

/****** Object:  StoredProcedure [dbo].[AddLanguage]    Script Date: 7/17/2023 1:29:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[AddLanguage] 
    @Name NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@Name IS NULL)
    BEGIN
        RAISERROR('Not enough data is shown to add a language.', 16, 1);
        RETURN;
    END;

    INSERT INTO Languages(Name)
    VALUES (@Name);
END;
GO


