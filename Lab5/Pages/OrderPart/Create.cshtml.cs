using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab5.Models;

namespace Lab5.Pages.OrderPart
{
    public class CreateModel : PageModel
    {
        private readonly Lab5.Models.PizzaDeliveryContext _context;

        public CreateModel(Lab5.Models.PizzaDeliveryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
        ViewData["PizzaId"] = new SelectList(_context.Pizzas, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Models.OrderPart OrderPart { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderParts.Add(OrderPart);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
