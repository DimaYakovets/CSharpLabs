using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Pages.OrderPart
{
    public class EditModel : PageModel
    {
        private readonly Lab5.Models.PizzaDeliveryContext _context;

        public EditModel(Lab5.Models.PizzaDeliveryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.OrderPart OrderPart { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OrderParts == null)
            {
                return NotFound();
            }

            var orderpart =  await _context.OrderParts.FirstOrDefaultAsync(m => m.Id == id);
            if (orderpart == null)
            {
                return NotFound();
            }
            OrderPart = orderpart;
           ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
           ViewData["PizzaId"] = new SelectList(_context.Pizzas, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OrderPart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderPartExists(OrderPart.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderPartExists(int id)
        {
          return _context.OrderParts.Any(e => e.Id == id);
        }
    }
}
