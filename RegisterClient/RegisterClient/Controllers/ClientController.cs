using Domain.Entidades;
using Infra.Data.Context;
using Infra.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace RegisterClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly MeuDbContext _contexto;

        public ClientController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }

        //[HttpGet]
        //public IQueryable<ClientDto> GetClientOne()
        //{
        //    return _contexto.Client;
        //}

        [HttpGet]
        [ResponseType(typeof(ClientDto))]
        public async Task<ActionResult> GetClient(int id)
        {
            ClientDto client = await _contexto.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<ActionResult> PutClient(int id, ClientDto client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.Id)
            {
                return BadRequest();
            }

            _contexto.Entry(client).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpPost]
        [ResponseType(typeof(ClientDto))]
        public async Task<ActionResult> PostClient(ClientDto client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _contexto.Client.Add(client);

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = client.Id }, client);
        }

        [HttpDelete]
        [ResponseType(typeof(ClientDto))]
        public async Task<ActionResult> DeleteClient(int id)
        {
            ClientDto client = await _contexto.Client.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            _contexto.Client.Remove(client);
            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw;
            }

            return Ok(client);
        }
    }
}
