USE PRUEBAS
GO;

CREATE PROCEDURE SP_Solicitud_All
AS
BEGIN
	SELECT * FROM Solicitud  WITH (NOLOCK)
END

EXEC SP_Solicitud_All
GO;

CREATE PROCEDURE SP_Solicitud_ById
@id integer
AS
BEGIN  
   SELECT  * FROM Solicitud WITH (NOLOCK) WHERE IdSolicitud = @id
END

EXEC SP_Solicitud_ById 20
GO;

ALTER PROCEDURE SP_Solicitud_Insert
@IdAlumno integer,
@FechaSolicitud datetime,
@CodRegistrante varchar(8),
@Carrera varchar(30),
@Periodo varchar(6)
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION 
               INSERT INTO Solicitud (IdAlumno,FechaSolicitud,CodRegistrante,Carrera,Periodo)
			      VALUES (@IdAlumno,@FechaSolicitud,@CodRegistrante,@Carrera,@Periodo)
		        SELECT SCOPE_IDENTITY();
        COMMIT
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK
    END CATCH
END


EXEC SP_Solicitud_Insert 10,'2022-11-22T22:45:37','20220077','Ingenieria','2022-2'
GO;

CREATE PROCEDURE SP_Solicitud_Update
@id int,
@IdAlumno integer,
@FechaSolicitud datetime,
@CodRegistrante varchar(8),
@Carrera varchar(30),
@Periodo varchar(6)
AS
BEGIN
	

	BEGIN TRY
		BEGIN TRANSACTION 
			UPDATE Solicitud
			SET
				 IdAlumno = @IdAlumno,
				FechaSolicitud = @FechaSolicitud,
				CodRegistrante = @CodRegistrante,
				Carrera = @Carrera ,
				Periodo = @Periodo
			WHERE
				IdSolicitud = @id
		COMMIT
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK
    END CATCH
END

EXEC SP_Solicitud_Update 4, 10,'2022-11-22T22:45:37','20220077','Ingenieria','2022-2'
GO;

CREATE PROCEDURE SP_Solicitud_Delete
@id int
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION 
				DELETE FROM Solicitud WHERE id = @id
		COMMIT
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK
	END CATCH
END

EXEC SP_Solicitud_Delete 31

EXEC SP_Solicitud_All

