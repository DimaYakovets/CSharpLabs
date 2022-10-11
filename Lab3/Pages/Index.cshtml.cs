using Lab3.Models;
using Lab3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DeliveryService _deliveryService;

        public IndexModel(ILogger<IndexModel> logger, DeliveryService deliveryService)
        {
            _logger = logger;
            _deliveryService = deliveryService;

        }

        public async Task OnGet()
        {
            ViewData["orders"] = await _deliveryService.GetAllOrders();
        }
    }
}