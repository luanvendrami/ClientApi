using Domain.Entidades;
using Domain.Interfaces.ClienteInterface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace RegisterClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Produces("application/json")]
    public class ClientController : ControllerBase
    {

        private readonly IClienteService _clientService;

        public ClientController(IClienteService clientService)
        {
            _clientService = clientService;
        }


        //Return list Clients
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ClienteDto>> GetClientList()
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
        public ActionResult Salvar(ClienteDto clientDto)
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
        public ActionResult<IEnumerable<ClienteDto>> RetornaListaPorNome(string nome)
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
        public ActionResult<ClienteDto> ClientePorId(int id)
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
        public ActionResult Atualizar([FromBody] ClienteDto client)
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
