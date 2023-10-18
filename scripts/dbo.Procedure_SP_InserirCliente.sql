create procedure SP_InserirCliente
	@Nome       nvarchar(150),
	@Cpf        nvarchar(11),
	@Email      nvarchar(100)

as

begin 
	
	insert into Cliente(Nome, Cpf, Email, DataCriacao)
	values(@Nome, @Cpf, @Email, GetDate())

end