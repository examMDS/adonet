USE PRUEBAS


CREATE PROCEDURE SP_Docente_All
AS
BEGIN
	SELECT * FROM Docente  WITH (NOLOCK)
END

EXEC SP_Docente_All
GO;

CREATE PROCEDURE SP_Docente_ById
@id integer
AS
BEGIN  
   SELECT  * FROM Docente WITH (NOLOCK) WHERE IdDocente = @id
END

EXEC SP_Docente_ById 20
GO;

CREATE PROCEDURE SP_Docente_Insert
@name varchar(80)
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION 
               INSERT INTO Docente (Nombres,Apellidos)
			      VALUES (@name)
		        SELECT SCOPE_IDENTITY();
        COMMIT
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK
    END CATCH
END


EXEC SP_Docente_Insert 'nomnbre 2'
GO;

CREATE PROCEDURE SP_Docente_Update
@id int,
@name varchar(80)
AS
BEGIN
	

	BEGIN TRY
		BEGIN TRANSACTION 
			UPDATE Docente
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

EXEC SP_Docente_Update 21, 'Update'
GO;

CREATE PROCEDURE SP_Docente_Delete
@id int
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION 
				DELETE FROM Docente WHERE id = @id
		COMMIT
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK
	END CATCH
END

EXEC SP_Docente_Delete 31

EXEC SP_Docente_All

