SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE DeleteLanguage
	@Name NVARCHAR(450)
AS
BEGIN
 SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Languages WHERE Name = @Name)
    BEGIN
        RAISERROR('Unable to find employee with such key.', 16, 1);
        RETURN;
    END;
    DELETE FROM Languages
    WHERE Name = @Name
END
GO
