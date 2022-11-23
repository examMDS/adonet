USE PRUEBAS


CREATE PROCEDURE SP_Curso_All
AS
BEGIN
	SELECT * FROM Curso  WITH (NOLOCK)
END

EXEC SP_Curso_All
GO;

CREATE PROCEDURE SP_Curso_ById
@id integer
AS
BEGIN  
   SELECT  * FROM Curso WITH (NOLOCK) WHERE IdCurso = @id
END

EXEC SP_Curso_ById 20
GO;

CREATE PROCEDURE SP_Curso_Insert
@name varchar(80)
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION 
               INSERT INTO Curso (Nombres,Apellidos)
			      VALUES (@name)
		        SELECT SCOPE_IDENTITY();
        COMMIT
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK
    END CATCH
END


EXEC SP_Curso_Insert 'nomnbre 2'
GO;

CREATE PROCEDURE SP_Curso_Update
@id int,
@name varchar(80)
AS
BEGIN
	

	BEGIN TRY
		BEGIN TRANSACTION 
			UPDATE Curso
			SET
				name = @name
			WHERE
				id = @id
		COMMIT
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK
    END CATCH
END

EXEC SP_Curso_Update 21, 'Update'
GO;

CREATE PROCEDURE SP_Curso_Delete
@id int
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION 
				DELETE FROM Curso WHERE id = @id
		COMMIT
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK
	END CATCH
END

EXEC SP_Curso_Delete 31

EXEC SP_Curso_All

