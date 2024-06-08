using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SdSystem.Data;
using SdSystem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SdSystem.Controllers
{
    [Authorize(Roles = "Support")]
    public class SupportController : Controller
    {
        private readonly SdSystemContext _context;

        public SupportController(SdSystemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.Identity.Name;
            return View(await _context.Tickets.Where(t => t.AssignedTo == userId).ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Name,Department,Priority,Status,AssignedTo,CompletedWork")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
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
            return View(ticket);
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
