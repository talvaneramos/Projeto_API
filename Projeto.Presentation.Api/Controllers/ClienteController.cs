using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Projeto.Infra.Data.Entities;
using Projeto.Infra.Data.Repositories;
using Projeto.Presentation.Api.Model;
using Projeto.Presentation.Api.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ClienteCadastroModel model, [FromServices] ClienteRepository clienteRepository)
        {
            try
            {
                if (clienteRepository.GetByCpf(model.Cpf) != null)
                {
                    return StatusCode(403, "CPF já se encontra cadastrado na base. ");
                }

                if (clienteRepository.GetByEmail(model.Email) != null)
                {
                    return StatusCode(403, "Email já se encontra cadastrado na base. ");
                }

                var cliente = new Cliente();
                cliente.Nome = model.Nome;
                cliente.Cpf = model.Cpf;
                cliente.Email = model.Email;

                clienteRepository.Insert(cliente);

                return StatusCode(201, "Cliente cadastrado com sucesso. ");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro: " + ex.Message);
            }            
        }

        [HttpPut]
        public IActionResult Put(ClienteEdicaoModel model, [FromServices] ClienteRepository clienteRepository)
        {
            try
            {
                var cliente = clienteRepository.GetById(model.IdCliente);

                if(cliente != null)
                {
                    cliente.Nome = model.Nome;
                    cliente.Cpf = model.Cpf;
                    cliente.Email = model.Email;

                    clienteRepository.Update(cliente);
                    return Ok("Cliente atualizado com sucesso. ");

                }
                else
                {
                    return StatusCode(400, "Cliente inválido. Operação não pôde ser concluída. ");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro: " + ex.Message);
            }            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] ClienteRepository clienteRepository)
        {
            try
            {
                var cliente = clienteRepository.GetById(id);

                if (cliente != null)
                {
                    clienteRepository.Delete(cliente);
                    return Ok("Cliente excluído com sucesso. ");
                }
                else 
                {
                    return StatusCode(422, "Cliente inválido. Operação não pôde ser concluída. ");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro: " + ex.Message);               
            }            
        }

        [HttpGet]
        public IActionResult GetAll([FromServices] ClienteRepository clienteRepository)
        {
            try
            {
                return Ok(clienteRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro: " + ex.Message);
            }
            
        }
    }
}
