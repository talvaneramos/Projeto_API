create procedure SP_ExcluirCliente
	@IdCliente      integer

as

begin 

	Delete from Cliente WHERE IdCliente = @IdCliente

end