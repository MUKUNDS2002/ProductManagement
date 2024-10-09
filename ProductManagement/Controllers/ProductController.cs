using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Data;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDBContext _dbContext;
        public ProductController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.ProductList.ToListAsync());
        }


        public async Task<IActionResult> Delete(int id)
        {
            var data = await _dbContext.ProductList.FirstOrDefaultAsync(x => x.SN == id);
            _dbContext.ProductList.Remove(data);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(string SN, string Product, string Description, string Created)
        {
            ProductModal product = new ProductModal();
            product.Product = Product;
            product.Description = Description;
            product.Created = Convert.ToInt32(Created);

            await _dbContext.ProductList.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(string SN, string Product, string Description, string Created)
        {
            ProductModal productModal = new ProductModal();
            productModal.SN = Convert.ToInt32(SN);
            productModal.Product = Product;
            productModal.Description = Description;
            productModal.Created = Convert.ToInt32(Created);

            _dbContext.ProductList.Update(productModal);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
