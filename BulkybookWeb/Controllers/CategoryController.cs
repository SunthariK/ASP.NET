
using Bulkybook.DataAccess;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkybookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategorylist=_db.Categories;
            return View(objCategorylist);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category Obj)
        {
            if (Obj.Name == Obj.Displayorder.ToString())
            {
                ModelState.AddModelError("name", "The Displayorder cannot exactly match the name");
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Add(Obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");

            }
            return View(Obj);
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if(id== null||id==0)
            {
                return NotFound();
            }
            var categoryfromdb = _db.Categories.Find(id);
            if(categoryfromdb==null)
            {
                return NotFound();
            }
            return View(categoryfromdb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category Obj)
        {
            if (Obj.Name == Obj.Displayorder.ToString())
            {
                ModelState.AddModelError("name", "The Displayorder cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");

            }
            return View(Obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryfromdb = _db.Categories.Find(id);
            if (categoryfromdb == null)
            {
                return NotFound();
            }
            return View(categoryfromdb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj=_db.Categories.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }

}
