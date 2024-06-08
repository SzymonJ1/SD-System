using Microsoft.AspNetCore.Mvc;
using SdSystem.Data;
using SdSystem.Models;
using System;
using System.Threading.Tasks;

namespace SdSystem.Controllers
{
    public class TicketController : Controller
    {
        private readonly SdSystemContext _context;

        public TicketController(SdSystemContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Name,Department")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                // Send email with the ticket ID
                // SendEmail(ticket);
                return RedirectToAction("Index", "Home");
            }
            return View(ticket);
        }
    }
}
