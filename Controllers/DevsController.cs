using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Identity;




namespace BugTracker.Controllers
{
    public class DevsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> userManager;

        public DevsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: Devs
        public IActionResult Index()
        {
            var users = userManager.Users;
            return View(users);
        }

        // GET: Devs/Assign
        public IActionResult Assign(int TicketID)
        {
            var users = userManager.Users;
            ViewBag.TicketID = TicketID;
            return View(users);
        }

        // POST: Assign
        public void AssignFinal(string DevName, int AssignedTicketId)
        {

            string assignedDev = DevName;
            int ticketId = AssignedTicketId;
            Dev dev = new Dev();
            dev.AssignedTicketId = ticketId;
            dev.DevName = assignedDev;
            AssignFinalToDB(dev);
            //return dev.AssignedTicketId.ToString() + " " + dev.DevName;
        }

        //POST: Devs/Assign
        public string AssignFinalToDB([Bind("DevName, AssignedTicketId")] Dev dev)
        {
            return dev.AssignedTicketId + " " + dev.DevName;
        }
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignFinalToDB([Bind("DevName, AssignedTicketId")] Dev dev)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dev);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dev);
        }*/

        // GET: Devs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dev = await _context.Dev
                .FirstOrDefaultAsync(m => m.DevId == id);
            if (dev == null)
            {
                return NotFound();
            }

            return View(dev);
        }

        // GET: Devs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dev = await _context.Dev.FindAsync(id);
            if (dev == null)
            {
                return NotFound();
            }
            return View(dev);
        }

        // POST: Devs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DevId,DevName")] Dev dev)
        {
            if (id != dev.DevId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevExists(dev.DevId))
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
            return View(dev);
        }

        // GET: Devs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dev = await _context.Dev
                .FirstOrDefaultAsync(m => m.DevId == id);
            if (dev == null)
            {
                return NotFound();
            }

            return View(dev);
        }

        // POST: Devs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dev = await _context.Dev.FindAsync(id);
            _context.Dev.Remove(dev);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevExists(int id)
        {
            return _context.Dev.Any(e => e.DevId == id);
        }
    }
}
