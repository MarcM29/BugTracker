using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data;

namespace BugTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tickets = await _context.Ticket.ToListAsync();
            var ticketNum = 0;
            foreach (var item in tickets)
            {
                ticketNum++;
            }

            var rTickets = await _context.ResolvedTicket.ToListAsync();
            var rTicketNum = 0;
            foreach (var item in rTickets)
            {
                rTicketNum++;
            }

            var highNum = 0;
            var medNum = 0;
            var lowNum = 0;
            var rHighNum = 0;
            var rMedNum = 0;
            var rLowNum = 0;
            var tHighNum = 0;
            var tMedNum = 0;
            var tLowNum = 0;
            foreach (var item in tickets)
            {
                if (item.TicketPriority.Equals("high"))
                {
                    tHighNum++;
                    highNum++;
                }
                if (item.TicketPriority.Equals("medium"))
                {
                    tMedNum++;
                    medNum++;
                }
                if (item.TicketPriority.Equals("low"))
                {
                    tLowNum++;
                    lowNum++;
                }
            }
            foreach (var item in rTickets)
            {
                if (item.RTicketPriority.Equals("high"))
                {
                    rHighNum++;
                    highNum++;
                }
                if (item.RTicketPriority.Equals("medium"))
                {
                    rMedNum++;
                    medNum++;
                }
                if (item.RTicketPriority.Equals("low"))
                {
                    rLowNum++;
                    lowNum++;
                }
            }
            ViewBag.TicketNum = ticketNum;
            ViewBag.RTicketNum = rTicketNum;
            ViewBag.HighNum = highNum;
            ViewBag.MedNum =medNum;
            ViewBag.LowNum =lowNum;
            ViewBag.RHighNum = rHighNum;
            ViewBag.RMedNum = rMedNum;
            ViewBag.RLowNum = rLowNum;
            ViewBag.THighNum = tHighNum;
            ViewBag.TMedNum = tMedNum;
            ViewBag.TLowNum = tLowNum;
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
