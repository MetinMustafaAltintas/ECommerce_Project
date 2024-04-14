using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.COREMVC.Areas.Admin.Models.Products.PageVMs;
using Project.ENTITIES.Models;

namespace Project.COREMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        readonly ICategoryManager _categoryManager;
        readonly IProductManager _productManager;
        public ProductController(ICategoryManager categoryManager, IProductManager productManager)
        {
            _categoryManager = categoryManager;
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            return View(_productManager.GetAll());
        }
        public IActionResult CreateProduct()
        {
            CreateProductPageVM cpVm = new()
            {
                Categories = _categoryManager.GetActives()
            };
            return View(cpVm);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product, IFormFile formFile)
        {
            Guid uniqueName = Guid.NewGuid();
            string extension = Path.GetExtension(formFile.FileName); //dosyanın uzantısını ele gecirdik...
            product.ImagePath = $"/images/{uniqueName}{extension}";

            string path = $"{Directory.GetCurrentDirectory()}/wwwroot{product.ImagePath}";
            FileStream stream = new(path, FileMode.Create);
            formFile.CopyTo(stream);
            _productManager.Add(product);
            return RedirectToAction("Index");
        }
    }
}