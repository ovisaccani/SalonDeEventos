using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProySalonDeEventos.Models
{
    public class Salon
    {
        [Key]
        public int IdSalon { get; set; }
        public String nombre { get; set; }
        //   List <Cliente> clientes { get; set; }
        //  List <Reserva> reservas { get; set; }
        // List <Presupuesto> presupuestos { get; set; }
        //int salonId { get; set; }
        public int ultimoIdCliente { get; set; }
        public int ultimoIdReserva { get; set; }

        public Salon(string nombre)
        {
            this.ultimoIdCliente = 0;
            this.nombre = nombre;
        }
        /*   public void RegistrarCliente(string nombre, string mail, string telefono, string cuit, string direccion, string pass, string user)
           {
               Cliente cliente = buscarCliente(cuit);
               if (cliente == null)
               {
                   cliente = new Cliente(nombre, mail, telefono, cuit, direccion, pass, user, generarIdCliente());
                   clientes.Add(cliente);

               }
               else
               {
                   Console.Write("Hubo un error");
               }
           }
           private int generarIdCliente()
           {

               return ultimoIdCliente+=1;
           }
           private int generarIdReserva()
           {
               return ultimoIdReserva += 1;
           }
           private Cliente buscarCliente(string cuit)
           {
               Cliente cliente = null;
               int idx = 0;
               while (idx < this.clientes.Count && cliente == null)
               {
                   if (((Cliente)this.clientes[idx]).coincideCuit(cuit))
                   {
                       cliente = (Cliente)this.clientes[idx];
                   }
                   idx++;
               }
               return cliente;
           }
           public void pedidoPresupuesto()
           {
           }
           public void generarReserva(int cantInvitados, DateTime fecha, Evento evento, Cliente cliente)
           {
               Reserva reserva = new Reserva(cantInvitados, fecha, generarIdReserva(), evento, cliente);
               this.reservas.Add(reserva);
           }*/
    }
}
