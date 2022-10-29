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
    public class IndexModel : PageModel
    {
        private readonly Lab5.Models.PizzaDeliveryContext _context;

        public IndexModel(Lab5.Models.PizzaDeliveryContext context)
        {
            _context = context;
        }

        public IList<Models.OrderPart> OrderPart { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.OrderParts != null)
            {
                OrderPart = await _context.OrderParts
                .Include(o => o.Order)
                .Include(o => o.Pizza).ToListAsync();
            }
        }
    }
}
