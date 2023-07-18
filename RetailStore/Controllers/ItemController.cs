using Microsoft.AspNetCore.Mvc;
using RetailStore.Models.Domain;

namespace RetailStore.Controllers
{
    public class ItemController : Controller
    {
        private readonly DatabaseContext _ctx;
        public ItemController(DatabaseContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddItem() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.ItemList.Add(item);
                _ctx.SaveChanges();
                TempData["msg"] = "Added Seccessfully";
                return RedirectToAction("AddItem");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could Not Added";
                return View();
            }
        }
        public IActionResult DisplayItems()
        {
            var items = _ctx.ItemList.ToList();
            return View(items);
        }
        public IActionResult EditItem(int id)
        {
            var item = _ctx.ItemList.Find(id);
            return View();
        }
        [HttpPost]
       
        public IActionResult EditItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.ItemList.Update(item);
                _ctx.SaveChanges();
                return RedirectToAction("DisplayItems");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could Not Updated";
                return View();
            }
        }
        public IActionResult DeleteItem(int id)
        {
            try
            {
                var item = _ctx.ItemList.Find(id);
                if (item != null)
                {
                    _ctx.Remove(item);
                    _ctx.SaveChanges(); 
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("DisplayItems");
        }
    }
}
