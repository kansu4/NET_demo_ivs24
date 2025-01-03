using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET_demo_ivs24.Models;
using NET_demo_ivs24.Data;
namespace NET_demo_ivs24.Controllers;

public class ItemsController : Controller
{
    // public IActionResult Overview() // IActionResult include all type like ViewResult{return View();} JsonResult{return Json;} ...
    // {
    //     var item = new Item() {Name = "keyboard" };
    //     return View(item);
    // }

    private readonly NET_demo_ivs24Context _context; // Database context for accessing data

        //constructor assign dtb context
        public ItemsController(NET_demo_ivs24Context context)
        { 
            _context = context; 
        }

        // Display list of all items
        public async Task<IActionResult> Index() // wait query data from database
        {
            var item = await _context.Items.ToListAsync(); // retrieve items infos from dtb then pass to the View()
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create([Bind("Id, Name, Price")] Item item) // create and bind to Item model
        {
            // string[] pdfArray = {
            // "/pdfs/sample1.pdf",
            // "/pdfs/sample2.pdf",
            // "/pdfs/sample3.pdf"
            // };

            // Random random = new Random();
            // item.PdfUrl = pdfArray[random.Next(pdfArray.Length)];

            if(ModelState.IsValid)
            {
                _context.Items.Add(item); // Add item info to dtb context
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