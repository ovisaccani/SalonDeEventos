using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProySalonDeEventos.Models
{
    public class Presupuesto
    {
        [Key]
        public int IdPresupuesto { get; set; }
        public string nombreCliente { get; set; }
        public int cantInvitados { get; set; }
        public DateTime fecha { get; set; }
        public string comentario { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }
    }
}
