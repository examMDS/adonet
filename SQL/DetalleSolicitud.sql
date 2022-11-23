USE PRUEBAS


CREATE PROCEDURE SP_DetalleSolicitud_All
AS
BEGIN
	SELECT * FROM DetalleSolicitud  WITH (NOLOCK)
END

EXEC SP_DetalleSolicitud_All
GO;

CREATE PROCEDURE SP_DetalleSolicitud_ById
@id integer
AS
BEGIN  
   SELECT  * FROM DetalleSolicitud WITH (NOLOCK) WHERE IdDetalleSolicitud = @id
END

EXEC SP_DetalleSolicitud_ById 20
GO;

CREATE PROCEDURE SP_DetalleSolicitud_Insert
@name varchar(80)
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION 
               INSERT INTO DetalleSolicitud (Nombres,Apellidos)
			      VALUES (@name)
		        SELECT SCOPE_IDENTITY();
        COMMIT
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK
    END CATCH
END


EXEC SP_DetalleSolicitud_Insert 'nomnbre 2'
GO;

CREATE PROCEDURE SP_DetalleSolicitud_Update
@id int,
@name varchar(80)
AS
BEGIN
	

	BEGIN TRY
		BEGIN TRANSACTION 
			UPDATE DetalleSolicitud
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

EXEC SP_DetalleSolicitud_Update 21, 'Update'
GO;

CREATE PROCEDURE SP_DetalleSolicitud_Delete
@id int
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION 
				DELETE FROM DetalleSolicitud WHERE id = @id
		COMMIT
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK
	END CATCH
END

EXEC SP_DetalleSolicitud_Delete 31

EXEC SP_DetalleSolicitud_All

