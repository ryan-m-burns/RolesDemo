using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RolesDemo.Data;
using RolesDemo.Models;
using System.Diagnostics;

namespace RolesDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,
                              ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult SecureArea()
        {
            List<Product> products = _db.Products.ToList();
            var sortedProducts =
             products.OrderBy(p => int.Parse(p.ProductId)).ToList();

            return View(sortedProducts);
        }

        [Authorize]
        public IActionResult Create()
        {
            List<Product> products = _db.Products.ToList();

            int id = products.Select(p =>
                     int.Parse(p.ProductId)).Max() + 1;
            Product product =
            new Product { ProductId = id.ToString() };

            return View(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Add(product);
                _db.SaveChanges();
                return RedirectToAction(nameof(SecureArea));
            }

            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
