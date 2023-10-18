create procedure SP_AlterarCliente
	@IdCliente       integer,
	@Nome            nvarchar(150),
	@Cpf             nvarchar(11),
	@Email           nvarchar(100)

as

begin

	Update Cliente set Nome = @Nome, Cpf = @Cpf, Email = @Email WHERE IdCliente = @IdCliente

end