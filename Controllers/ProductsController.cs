using FirstMvcProject.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvcProject.Controllers
{
    public class ProductsController : Controller
    {

        private static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "product A", Price =  500m, Description = "baby products", Stock = 100 },
            new Product { Id = 2, Name = "Product B", Price =  200m , Description = "School materials", Stock = 150 },
        };
        
        public IActionResult GetAllProducts()
        {
            return View(Products);
        }

        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                product.Id = Products.Max(p => p.Id);
                Products.Add(product);
                return RedirectToAction("GetAllProducts");
            }
            return View(product);
        }
       
 
    }

}
