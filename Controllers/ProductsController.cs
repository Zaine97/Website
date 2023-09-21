// ... other using directives ...

using Data;
using EcoPower_Logistics.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Linq;

namespace Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly SuperStoreContext _context;
        private readonly IProductsRepository<Product> _productRepository;

        public ProductsController(SuperStoreContext context, IProductsRepository<Product> productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }

        // ... rest of the actions ...

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}