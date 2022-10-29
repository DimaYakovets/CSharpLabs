using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Pages.Pizza
{
    public class DeleteModel : PageModel
    {
        private readonly Lab5.Models.PizzaDeliveryContext _context;

        public DeleteModel(Lab5.Models.PizzaDeliveryContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Models.Pizza Pizza { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pizzas == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizzas.FirstOrDefaultAsync(m => m.Id == id);

            if (pizza == null)
            {
                return NotFound();
            }
            else 
            {
                Pizza = pizza;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Pizzas == null)
            {
                return NotFound();
            }
            var pizza = await _context.Pizzas.FindAsync(id);

            if (pizza != null)
            {
                Pizza = pizza;
                _context.Pizzas.Remove(Pizza);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
