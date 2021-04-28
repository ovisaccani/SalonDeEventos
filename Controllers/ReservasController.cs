using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProySalonDeEventos.Context;
using ProySalonDeEventos.Models;

namespace ProySalonDeEventos.Controllers
{
    public class ReservasController : Controller
    {
        private readonly SalonDatabaseContext _context;

        public ReservasController(SalonDatabaseContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var salonDatabaseContext = _context.Reservas.Include(r => r.Cliente).Include(r => r.Evento);
            return View(await salonDatabaseContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Evento)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["CurrentIdCliente"] = new SelectList(_context.Clientes, "IdCliente", "nombre");
            ViewData["CurrentIdEvento"] = new SelectList(_context.Eventos, "IdEvento", "nombre");
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReserva,cantInvitados,fecha,CurrentIdEvento,CurrentIdCliente")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrentIdCliente"] = new SelectList(_context.Clientes, "IdCliente", "nombre", reserva.CurrentIdCliente);
            ViewData["CurrentIdEvento"] = new SelectList(_context.Eventos, "IdEvento", "nombre", reserva.CurrentIdEvento);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["CurrentIdCliente"] = new SelectList(_context.Clientes, "IdCliente", "nombre", reserva.CurrentIdCliente);
            ViewData["CurrentIdEvento"] = new SelectList(_context.Eventos, "IdEvento", "nombre", reserva.CurrentIdEvento);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,cantInvitados,fecha,CurrentIdEvento,CurrentIdCliente")] Reserva reserva)
        {
            if (id != reserva.IdReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.IdReserva))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrentIdCliente"] = new SelectList(_context.Clientes, "IdCliente", "nombre", reserva.CurrentIdCliente);
            ViewData["CurrentIdEvento"] = new SelectList(_context.Eventos, "IdEvento", "nombre", reserva.CurrentIdEvento);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Evento)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            ViewData["CurrentIdCliente"] = new SelectList(_context.Clientes, "IdCliente", "nombre", reserva.CurrentIdCliente);
            ViewData["CurrentIdEvento"] = new SelectList(_context.Eventos, "IdEvento", "nombre", reserva.CurrentIdEvento);

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.IdReserva == id);
        }
    }
}
