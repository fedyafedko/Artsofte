SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetAllLanguages
AS
BEGIN
    SELECT * FROM Languages
END
GO
