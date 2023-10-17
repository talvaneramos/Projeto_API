using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Infra.Data.Contracts
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Cliente GetByCpf(String cpf);
        Cliente GetByEmail(String email);
    }
}
