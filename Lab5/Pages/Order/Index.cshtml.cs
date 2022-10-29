using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Pages.Order
{
    public class IndexModel : PageModel
    {
        private readonly Lab5.Models.PizzaDeliveryContext _context;

        public IndexModel(Lab5.Models.PizzaDeliveryContext context)
        {
            _context = context;
        }

        public IList<Models.Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
                Order = await _context.Orders
                .Include(o => o.Client).ToListAsync();
            }
        }
    }
}
