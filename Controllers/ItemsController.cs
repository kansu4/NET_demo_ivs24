using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET_demo_ivs24.Models;

namespace NET_demo_ivs24.Controllers;

public class ItemsController : Controller
{
    // public IActionResult Overview() // IActionResult include all type like ViewResult{return View();} JsonResult{return Json;} ...
    // {
    //     var item = new Item() {Name = "keyboard" };
    //     return View(item);
    // }

    private readonly NET_demo_ivs24Context _context;
        public ItemsController(NET_demo_ivs24Context context)
        { 
            _context = context; 
        }


        public async Task<IActionResult> Index() // wait query data from database
        {
            var item = await _context.Items.ToListAsync();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create([Bind("Id, Name, Price")] Item item) // create and bind to Item model
        {
            if(ModelState.IsValid)
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item); 
            
        }

         public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x=>x.Id == id);
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Price")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

         public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if(item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        
}