#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AmanNayran.Models;

namespace AmanNayran.Controllers
{
    public class NotaDeVendaController : Controller
    {
        private readonly MyDbContext _context;

        public NotaDeVendaController(MyDbContext context)
        {
            _context = context;
        }

        // GET: NotaDeVenda
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.NotasDeVenda.Include(n => n.Cliente).Include(n => n.Transportadora).Include(n => n.Vendedor);
            return View(await myDbContext.ToListAsync());
        }

        // GET: NotaDeVenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotasDeVenda
                .Include(n => n.Cliente)
                .Include(n => n.Transportadora)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.NotaDeVendaId == id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }

            return View(notaDeVenda);
        }

        // GET: NotaDeVenda/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadoras, "TransportadoraId", "TransportadoraId");
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "VendedorId");
            return View();
        }

        // POST: NotaDeVenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NotaDeVendaId,Data,Status,VendedorId,ClienteId,TransportadoraId")] NotaDeVenda notaDeVenda)
        {
            // Define o valor padão para Status
            notaDeVenda.Status = "A ser pago";
            
            if (ModelState.IsValid)
            {
                _context.Add(notaDeVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", notaDeVenda.ClienteId);
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadoras, "TransportadoraId", "TransportadoraId", notaDeVenda.TransportadoraId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "VendedorId", notaDeVenda.VendedorId);
            return View(notaDeVenda);
        }

        // GET: NotaDeVenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotasDeVenda.FindAsync(id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", notaDeVenda.ClienteId);
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadoras, "TransportadoraId", "TransportadoraId", notaDeVenda.TransportadoraId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "VendedorId", notaDeVenda.VendedorId);
            return View(notaDeVenda);
        }

        // POST: NotaDeVenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NotaDeVendaId,Data,Status,VendedorId,ClienteId,TransportadoraId")] NotaDeVenda notaDeVenda)
        {
            if (id != notaDeVenda.NotaDeVendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notaDeVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaDeVendaExists(notaDeVenda.NotaDeVendaId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", notaDeVenda.ClienteId);
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadoras, "TransportadoraId", "TransportadoraId", notaDeVenda.TransportadoraId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "VendedorId", notaDeVenda.VendedorId);
            return View(notaDeVenda);
        }

        // GET: NotaDeVenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotasDeVenda
                .Include(n => n.Cliente)
                .Include(n => n.Transportadora)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.NotaDeVendaId == id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }

            return View(notaDeVenda);
        }

        // POST: NotaDeVenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notaDeVenda = await _context.NotasDeVenda.FindAsync(id);
            _context.NotasDeVenda.Remove(notaDeVenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaDeVendaExists(int id)
        {
            return _context.NotasDeVenda.Any(e => e.NotaDeVendaId == id);
        }

        public async Task<IActionResult> Cancelar(int id)
        {
            var notaDeVenda = await _context.NotasDeVenda.FindAsync(id);

            if (notaDeVenda != null)
            {
                notaDeVenda.Status = "Cancelado";
                _context.Update(notaDeVenda);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Devolver(int id)
        {
            var notaDeVenda = await _context.NotasDeVenda.FindAsync(id);

            if (notaDeVenda != null)
            {
                notaDeVenda.Status = "Devolvido";
                _context.Update(notaDeVenda);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

