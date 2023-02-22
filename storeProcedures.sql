/*store procedures*/
Instructors
--------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Delete_Instructor](
    @InstructorId UNIQUEIDENTIFIER
)
AS
BEGIN

    delete from CursosInstructor where InstructorId = @InstructorId
    delete from Instructores where InstructorId = @InstructorId
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Get_Instructors]
AS
BEGIN
    SELECT 
        i.InstructorId,
        i.nombre as 'Name',
        i.apellido as LastName,
        i.grado as Grade
    FROM Instructores i
END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Instructor_ById](
    @InstructorId UNIQUEIDENTIFIER
)
AS
BEGIN

   SELECT 
        i.InstructorId,
        i.nombre as 'Name',
        i.apellido as LastName,
        i.grado as Grade
    FROM Instructores i
    where InstructorId =  @InstructorId
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_New_Instructor](
    @InstructorId UNIQUEIDENTIFIER,
    @name nvarchar(500),
    @lastName NVARCHAR(500),
    @grade NVARCHAR(100)
)
AS
BEGIN
    INSERT INTO Instructores(InstructorId,nombre,apellido,grado,foto_perfil)
        VALUES(@InstructorId,@name, @lastName , @grade,1)
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Update_Instructor](
    @InstructorId UNIQUEIDENTIFIER,
    @name nvarchar(500),
    @lastName NVARCHAR(500),
    @grade NVARCHAR(100)
)
AS
BEGIN
    update Instructores set nombre=@name, apellido = @lastName, grado = @grade where InstructorId = @InstructorId
END
GO



----------

/*Pagination*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Get_Pagination](
    @CourseName NVARCHAR(500),
    @Order NVARCHAR(500),
    @NumberPages int,
    @CountElement int,
    @TotalRecords int OUTPUT,
    @TotalPages int OUTPUT
)
AS
BEGIN

    SET NOCOUNT ON
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
    
    DECLARE @INICIO INT
    DECLARE @FIN INT

    IF @NumberPages = 1
        BEGIN
            SET @INICIO = (@NumberPages*@CountElement) - @CountElement
            SET @FIN = @NumberPages*@CountElement
        END
    ELSE    
        BEGIN
             SET @INICIO = ((@NumberPages*@CountElement) - @CountElement) +1
             SET @FIN = @NumberPages*@CountElement
        END

    CREATE TABLE #TMP (
        rowNumber int IDENTITY(1,1),
        ID UNIQUEIDENTIFIER
    )

    DECLARE @SQL NVARCHAR(MAX)
    SET @SQL = 'SELECT CURSOID FROM CURSOS'

    IF @CourseName IS NOT NULL
        BEGIN
            SET @SQL = @SQL + ' WHERE TITULO LIKE ''%'+@CourseName+'%'' '
        END
    IF @Order IS NOT NULL
        BEGIN 
            SET @SQL = @SQL + ' ORDER BY ' + @Order
        END
    INSERT INTO #TMP(ID)
    EXEC sp_executesql @SQL

    SELECT @TotalRecords = COUNT(*) FROM #TMP

    IF @TotalRecords  > @CountElement
        BEGIN
            SET @TotalPages = @TotalRecords /@CountElement
            IF (@TotalRecords % @CountElement) > 0
                BEGIN
                    SET @TotalPages = @TotalPages + 1
                END
        END
    ELSE 
        BEGIN
            SET @TotalPages = 1
        END

    SELECT 
    C.CursoId,
    C.titulo,
    C.descripcion,
    C.fecha_publicacion,
    C.foto_portada
    FROM #TMP T 
    INNER JOIN Cursos C ON C.CursoId = T.ID
    LEFT JOIN  Precios P ON P.CursoId= C.CursoId 
    WHERE T.rowNumber >= @INICIO AND T.rowNumber <= @FIN

END
GO

