using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProySalonDeEventos.Models
{
    public class Evento
    {
        [Key]

        public int IdEvento { get; set; }
        public String nombre { get; set; }
        public String musica { get; set; }
        public String decoracion { get; set; }
        public String catering { get; set; }

        [EnumDataType(typeof(TipoEvento))]
        public TipoEvento tipo { get; set; }

        public Reserva reserva { get; set; }






        public Evento()
        {
        }

        /*
        public static implicit operator Evento(ArrayList v)
        {
            throw new NotImplementedException();
        }
        */

    }

}

