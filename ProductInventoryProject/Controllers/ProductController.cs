using Microsoft.AspNetCore.Mvc;
using ProductInventoryProject.Models;
using ProductInventoryProject.Models.Data;

namespace ProductInventoryProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsallDbContext _ctx;
        public ProductController(ProductsallDbContext ctx)
        {
            _ctx=ctx;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductDetails store)
        {
            if (ModelState.IsValid)
            {
                _ctx.ProductTable.Add(store);
                _ctx.SaveChanges();
                ViewData["msg"] = "Data Saved Successfully";
                return View();
            }
            return View();
        }
        public IActionResult Read(int ProductId, int page=1)
        {
            int pageSize = 5;
            var totalRecords = _ctx.ProductTable.Count();
            var data = _ctx.ProductTable.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            return View(data);
        }
        public IActionResult Edit(int ProductId)
        {
            var data = _ctx.ProductTable.Find(ProductId);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ProductDetails save)
        {
            _ctx.ProductTable.Update(save);
            _ctx.SaveChanges();
            return RedirectToAction("Read");
        }
        public IActionResult Delete(int id)
        {
            var data = _ctx.ProductTable.Find(id);
            if (data != null)
            {
                _ctx.ProductTable.Remove(data);
                _ctx.SaveChanges();
                return RedirectToAction("Read");
            }
            return View();
        }

        public IActionResult DeleteAll()
        {
           var data =  _ctx.ProductTable.ToList();
            if(data.Any())
            {
                _ctx.ProductTable.RemoveRange(data);
                _ctx.SaveChanges();
            }
            
            return RedirectToAction("Read");
        }

    }
}
