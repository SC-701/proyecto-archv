-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarUsuario]
	-- Add the parameters for the stored procedure here
@NombreUsuario VARCHAR(MAX),
@PasswordHash VARCHAR(MAX),
@CorreoElectronico VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @Id AS UniqueIdentifier =NEWID();
	BEGIN TRAN
		INSERT INTO [dbo].[Usuarios]
			   ([Id]
			   ,[NombreUsuario]
			   ,[PasswordHash]
			   ,[CorreoElectronico])
		 VALUES
			   (@Id
			   ,@NombreUsuario
			   ,@PasswordHash
			   ,@CorreoElectronico)		

		INSERT INTO [dbo].[PerfilesxUsuario]
           ([IdUsuario]
           ,[IdPerfil])
		VALUES
           (@Id
           ,1)
	SELECT @Id
	COMMIT TRAN
END