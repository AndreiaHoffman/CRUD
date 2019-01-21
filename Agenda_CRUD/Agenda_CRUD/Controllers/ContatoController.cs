using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda_CRUD.DAO;
using Agenda_CRUD.Data;
using Agenda_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_CRUD.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ContatoDAO DAO;

        public ContatoController(ApplicationContext context)
        {
            _context = context;
            DAO = new ContatoDAO(_context);
        }

        public ActionResult Index()
        {
            var contato = DAO.Contatos();
            return View(contato);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Pessoa, Endereco, Telefone")] Contato contato)
        {
            if (ModelState.IsValid)
            {

                DAO.Gravar(contato);
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var contato = DAO.ContatoID(id);
            if(contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id, Pessoa, Endereco, Telefone")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                DAO.Gravar(contato);
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = DAO.ContatoID(id);
            if (contato == null)
            {
                return NotFound();
            }
            return View("Detalhes",contato);
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = DAO.ContatoID(id);
            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(int id)
        {
            var contato = DAO.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}