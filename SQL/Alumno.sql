USE PRUEBAS
GO;


CREATE PROCEDURE SP_Alumno_All
AS
BEGIN
	SELECT * FROM Alumno  WITH (NOLOCK)
END

EXEC SP_Alumno_All
GO;

CREATE PROCEDURE SP_Alumno_ById
@id integer
AS
BEGIN  
   SELECT  * FROM Alumno WITH (NOLOCK) WHERE IdAlumno = @id
END

EXEC SP_Alumno_ById 3
GO;

CREATE PROCEDURE SP_Alumno_Insert
@Nombres varchar(50),
@Apellidos varchar(50)
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION 
               INSERT INTO Alumno (Nombres,Apellidos)
			      VALUES (@Nombres,@Apellidos)
		        SELECT SCOPE_IDENTITY();
        COMMIT
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK
    END CATCH
END


EXEC SP_Alumno_Insert 'Nombre 1','Apellido 2'
GO;

CREATE PROCEDURE SP_Alumno_Update
@id int,
@Nombres varchar(50),
@Apellidos varchar(50)
AS
BEGIN
	

	BEGIN TRY
		BEGIN TRANSACTION 
			UPDATE Alumno
			SET
				Nombres = @Nombres,
				Apellidos = @Apellidos  
			WHERE
				IdAlumno = @id
		COMMIT
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK
    END CATCH
END

EXEC SP_Alumno_Update 21, 'Update'
GO;

CREATE PROCEDURE SP_Alumno_Delete
@id int
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION 
				DELETE FROM Alumno WHERE id = @id
		COMMIT
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK
	END CATCH
END

EXEC SP_Alumno_Delete 31

EXEC SP_Alumno_All

