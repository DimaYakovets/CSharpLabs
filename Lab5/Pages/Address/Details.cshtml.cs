using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;
using Lab5.Services;

namespace Lab5.Pages.Address
{
    public class DetailsModel : PageModel
    {
        public Models.Address Address { get; set; }


        private readonly IRepository<Models.Address> _registry;

        public DetailsModel(IRepository<Models.Address> registry)
        {
            _registry = registry;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Address = await _registry.GetAsync(id);

            if (Address == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
