-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerUsuario]
	-- Add the parameters for the stored procedure here
@NombreUsuario VARCHAR(MAX),
@CorreoElectronico VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT        Id, NombreUsuario, PasswordHash, CorreoElectronico, FechaCreacion, FechaModificacion, UsuarioCrea, UsuarioModifica
FROM            Usuarios
WHERE        (NombreUsuario = @NombreUsuario) OR
                         (CorreoElectronico = @CorreoElectronico)
END