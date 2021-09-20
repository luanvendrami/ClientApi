using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Produces("application/json")]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }


        //Return list Clients
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ClientEntcs>> GetClientList()
        {
            try
            {
                var retorno = _clientService.RetornoLista();
                return Ok(retorno);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter aluno");
            }
        }

        [HttpPost]
        public ActionResult Salvar(ClientDto clientDto)
        {
            try
            {
                _clientService.SalvarCliente(clientDto);
                return Ok();
            }
            catch 
            {
                return BadRequest("Dados inválidos, tenta novamente.");
            }

        }

        [HttpGet("ClienteNome")]
        public ActionResult<IEnumerable<ClientEntcs>> RetornaListaPorNome(string nome)
        {
            try
            {
                var retorno = _clientService.RetornaListaNomes(nome);
                if (retorno == null)
                    return NotFound($"Não existem alunos com o critério {nome}");
                return Ok(retorno);
            }
            catch
            {
                return BadRequest("Resquest inválido");
            }
        }

        [HttpGet("{id:int}", Name = "RetornoClienteId")]
        public ActionResult<ClientEntcs> ClientePorId(int id)
        {
            try
            {
                var retorno = _clientService.RetornaIdCliente(id);
                if (retorno == null)
                    return NotFound($"Não existem alunos com o critério {id}");
                return Ok(retorno);
            }
            catch
            {
                return BadRequest("Resquest inválido");
            }
        }


        [HttpPut("AtualizarCliente")]
        public ActionResult Atualizar([FromBody] ClientDto client)
        {
            try
            {
                if (client != null)
                    _clientService.SalvarCliente(client);
                return Ok($"Client foi atualizado com sucesso");
            }
            catch
            {
                return BadRequest("Dados inconsistentes");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var retorno = _clientService.DeletarCliente(id);
                if(retorno != false)
                    return Ok($"Client com id: {id} foi excluido com sucesso");
            }
            catch
            {
                return NotFound($"Client com id: {id} não encontrado");
            }
            return NotFound($"Client com id: {id} não encontrado");
        }
    }
}
