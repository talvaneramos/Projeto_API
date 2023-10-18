create procedure  SP_ObterClientePorId
	@IdCliente      integer
as

begin

	Select * from Cliente WHERE IdCliente = @IdCliente

end