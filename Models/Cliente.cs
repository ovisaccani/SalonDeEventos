using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProySalonDeEventos.Models
{
    public class Cliente
    {

        [Key]
        public int IdCliente { get; set; }
        [Required]
        public String nombre { get; set; }
        [Required]
        public String mail { get; set; }
        [Required]
        public String telefono { get; set; }
        [Required]
        [Display(Name = "CUIL/CUIT/DNI")]
        public String cuit { get; set; }
        [Required]
        public String direccion { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String pass { get; set; }
        [Required]
        public String user { get; set; }

        public ICollection<Reserva> reservas { get; set; }




        public Cliente()
        {
        }

        public Cliente(string nombre, string mail, string telefono, string cuit, string direccion, string pass, string user)
        {
            this.nombre = nombre;
            this.mail = mail;
            this.telefono = telefono;
            this.cuit = cuit;
            this.direccion = direccion;
            this.pass = pass;
            this.user = user;
            //this.clienteId = id;
        }

        /*  public void Login()
          {
          }
         public void cambiarId(int id)
          {
              this.clienteId = id;
          }
          public Boolean coincideCuit(string cuit)
          {
              return cuit == this.cuit;
          }*/
    }
}

