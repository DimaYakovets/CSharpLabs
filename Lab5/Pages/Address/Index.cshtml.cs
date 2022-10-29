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
    public class IndexModel : PageModel
    {
        private readonly IRepository<Models.Address> _repository;

        public IndexModel(IRepository<Models.Address> repository)
        {
            _repository = repository;
        }

        public IList<Models.Address> Address { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Address = (await _repository.GetAllAsync()).ToList();
        }
    }
}
