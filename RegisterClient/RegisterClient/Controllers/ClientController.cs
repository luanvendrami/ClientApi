using Domain.Entidades;
using Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Consumes("application/json")]
    public class ClientController : Controller
    {

        private readonly MeuDbContext _contexto;

        public ClientController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: ClientController
        [HttpGet]
        //[Route"/[controller]"]    
        public IActionResult Index()
        {

            var one = new ClientDto();

            one.Cep = "CepTeste";
            one.Cpf = "Cpfteste";
            one.DataNascimento = DateTime.Now;
            one.Id = 1;
            one.NomeCompleto = "Luan Vendrami";
            one.Rg = "TesteRg";

            _contexto.Add(one);
            _contexto.SaveChanges();

            return Ok(one);
        }

        //// GET: ClientController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: ClientController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ClientController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ClientController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ClientController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ClientController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ClientController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
