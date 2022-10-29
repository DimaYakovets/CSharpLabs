using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;
using Lab5.Services;

namespace Lab5.Pages.Address
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Models.Address Address { get; set; } = default!;

        private readonly IRepository<Models.Address> _repository;

        public EditModel(IRepository<Models.Address> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Address = await _repository.GetAsync(id);

            if (Address == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _repository.GetAsync(Address.Id) is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(Address.Id, Address);

            return RedirectToPage("./Index");
        }
    }
}
