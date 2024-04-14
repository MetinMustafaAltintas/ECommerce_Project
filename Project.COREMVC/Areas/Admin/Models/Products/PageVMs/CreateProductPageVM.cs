using Project.ENTITIES.Models;

namespace Project.COREMVC.Areas.Admin.Models.Products.PageVMs
{
    public class CreateProductPageVM
    {
        public List<Category>  Categories { get; set; }

        public Product Product { get; set; }
    }
}
