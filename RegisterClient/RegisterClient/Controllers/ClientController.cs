using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        public async Task<ActionResult<IAsyncEnumerable<ClientDto>>> GetClientList()
        {
            try
            {
                var clients = await _clientService.GetClients();
                return Ok(clients);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter aluno");
            }
        }

        //Return Name Clients
        [HttpGet("ClientName")]
        public async Task<ActionResult<IAsyncEnumerable<ClientDto>>> GetClientByName([FromQuery] string nome)
        {
            try
            {
                var clients = await _clientService.GetClientByNome(nome);

                if (clients == null)
                    return NotFound($"Não existem alunos com o critério {nome}");

                return Ok(clients);
            }
            catch
            {
                return BadRequest("Resquest inválido");
            }
        }

        //Return Id Clients
        [HttpGet("{id:int}", Name = "GetClientId")]
        public async Task<ActionResult<ClientDto>> GetClientId(int id)
        {
            try
            {
                var clientId = await _clientService.GetClient(id);
                if (clientId == null)
                    return NotFound($"Não existem aluno com id: {id}");
                return Ok(clientId);
            }
            catch
            {
                return BadRequest("Resquest inválido");
            }
        }

        //Value created return of the last ClientId
        [HttpPost]
        public async Task<ActionResult> Create(ClientDto client)
        {
            try
            {
                await _clientService.CreateClient(client);
                return CreatedAtRoute(nameof(GetClientId), new { id = client.Id }, client);
            }
            catch
            {
                return BadRequest("Resquest inválido");
            }
        }

        //Update client of the paste parameter Id
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] ClientDto client)
        {
            try
            {
                if(client.Id == id)
                {
                    await _clientService.UpdateClient(client);
                    return Ok($"Client com id: {id} foi atualizado com sucesso");

                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch 
            {
                return BadRequest("Resquest inválido"); ;
            }
        }

        //Delete Client of the ID
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var client = await _clientService.GetClient(id);
                if(client != null)
                {
                    await _clientService.DeleteClient(client);
                    return Ok($"Client de id: {id} foi excluido com sucesso");
                }
                else
                {
                    return NotFound($"Client com id: {id} não encontrado");
                }

            }
            catch
            {
                return BadRequest("Resquest inválido"); ;
            }
        }

    }
}
