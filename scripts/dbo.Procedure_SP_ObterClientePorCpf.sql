create procedure SP_ObterClientePorCpf
	@Cpf      nvarchar(11)


as

begin 

	Select * from Cliente WHERE Cpf = @Cpf

end


