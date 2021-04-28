using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProySalonDeEventos.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }

        [DisplayName("Cantidad de Invitados")]
        public int cantInvitados { get; set; }
        public DateTime fecha { get; set; }
        public Evento Evento { get; set; }

        [Required]
        [DisplayName("Nombre del evento")]
        public int CurrentIdEvento { get; set; }
        public Cliente Cliente { get; set; }

        [Required]

        [Display(Name ="Nombre del Cliente")]
        public int CurrentIdCliente { get; set; }





        public Reserva()
        {
        }

        public Reserva(int cantInvitados, DateTime fecha, Evento evento, Cliente cliente)
        {
            this.cantInvitados = cantInvitados;
            this.fecha = fecha;
            this.Evento = evento;
            this.Cliente = cliente;
        }

    }
}
