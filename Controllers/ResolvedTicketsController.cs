using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.Controllers
{
    public class ResolvedTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResolvedTicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ResolvedTickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResolvedTicket.ToListAsync());
        }

        // GET: ResolvedTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resolvedTicket = await _context.ResolvedTicket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resolvedTicket == null)
            {
                return NotFound();
            }

            return View(resolvedTicket);
        }

        // GET: ResolvedTickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResolvedTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RTicketTitle,RTicketDescription,RTicketPriority,RTicketDate,RUsersName")] ResolvedTicket resolvedTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resolvedTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resolvedTicket);
        }

        // GET: ResolvedTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resolvedTicket = await _context.ResolvedTicket.FindAsync(id);
            if (resolvedTicket == null)
            {
                return NotFound();
            }
            return View(resolvedTicket);
        }

        // POST: ResolvedTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RTicketTitle,RTicketDescription,RTicketPriority,RTicketDate,RUsersName")] ResolvedTicket resolvedTicket)
        {
            if (id != resolvedTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resolvedTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResolvedTicketExists(resolvedTicket.Id))
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
            return View(resolvedTicket);
        }

        // GET: ResolvedTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resolvedTicket = await _context.ResolvedTicket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resolvedTicket == null)
            {
                return NotFound();
            }

            return View(resolvedTicket);
        }

        // POST: ResolvedTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resolvedTicket = await _context.ResolvedTicket.FindAsync(id);
            _context.ResolvedTicket.Remove(resolvedTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResolvedTicketExists(int id)
        {
            return _context.ResolvedTicket.Any(e => e.Id == id);
        }
    }
}
