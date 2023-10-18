create procedure SP_ObterClientePorEmail
	@Email         nvarchar(100)

as

begin 

	Select * from Cliente WHERE Email = @Email

end