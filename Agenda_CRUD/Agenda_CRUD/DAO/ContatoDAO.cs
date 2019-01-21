using Agenda_CRUD.Data;
using Agenda_CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_CRUD.DAO
{
    public class ContatoDAO
    {
        private ApplicationContext _context;

        public ContatoDAO(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable Contatos()
        {
            return _context.Contato.ToList();
        }

        public Contato ContatoID(int? id)
        {
            return _context.Contato.FirstOrDefault(c => c.Id == id);
        }

        public void Gravar(Contato contato)
        {
            try
            {
                if (contato.Id == 0)
                {
                    _context.Contato.Add(contato);
                }
                else
                {
                    _context.Entry(contato).State = EntityState.Modified;
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public Contato Delete(int id)
        {
            Contato contato = ContatoID(id);
            _context.Contato.Remove(contato);
            _context.SaveChanges();
            return contato;
        }

    }
}
