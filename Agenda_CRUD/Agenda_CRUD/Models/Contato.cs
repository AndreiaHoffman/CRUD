using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_CRUD.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Pessoa { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }       
   
    }
}
