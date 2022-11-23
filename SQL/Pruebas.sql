CREATE DATABASE PRUEBAS;

USE PRUEBAS

DROP TABLE Client
CREATE TABLE Client
(
	id int identity not null,
	name varchar(80) not null,
	dni varchar(9) null
)


insert into Client(name)
values
('QRaro'),
('Smith'),
('Susan');

SELECT * FROM Client;
GO;

CREATE PROCEDURE SP_Client_All
AS
BEGIN
	SELECT * FROM Client  WITH (NOLOCK)
END

EXEC SP_Client_All
GO;

CREATE PROCEDURE SP_Client_ById
@id integer
AS
BEGIN  
   SELECT  * FROM Client WITH (NOLOCK) WHERE id = @id
END

EXEC SP_Client_ById 20
GO;

ALTER PROCEDURE SP_Client_Insert
@name varchar(80)
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION 
               INSERT INTO Client (name)
			   VALUES (@name)
		       SELECT SCOPE_IDENTITY();
        COMMIT
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK
    END CATCH
END


EXEC SP_Client_Insert 'MuyRaro 2'
GO;

ALTER PROCEDURE SP_Client_Update
@id int,
@name varchar(80)
AS
BEGIN
	

	BEGIN TRY
		BEGIN TRANSACTION 
			UPDATE Client
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

EXEC SP_Client_Update 21, 'Update'
GO;

ALTER PROCEDURE SP_Client_Delete
@id int
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION 
				DELETE FROM Client WHERE id = @id
		COMMIT
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK
	END CATCH
END

EXEC SP_Client_Delete 31
GO;

USE PRUEBAS;
EXEC SP_Client_All;

