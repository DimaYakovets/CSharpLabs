using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Pages.OrderPart
{
    public class DeleteModel : PageModel
    {
        private readonly Lab5.Models.PizzaDeliveryContext _context;

        public DeleteModel(Lab5.Models.PizzaDeliveryContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Models.OrderPart OrderPart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OrderParts == null)
            {
                return NotFound();
            }

            var orderpart = await _context.OrderParts.FirstOrDefaultAsync(m => m.Id == id);

            if (orderpart == null)
            {
                return NotFound();
            }
            else 
            {
                OrderPart = orderpart;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.OrderParts == null)
            {
                return NotFound();
            }
            var orderpart = await _context.OrderParts.FindAsync(id);

            if (orderpart != null)
            {
                OrderPart = orderpart;
                _context.OrderParts.Remove(OrderPart);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
