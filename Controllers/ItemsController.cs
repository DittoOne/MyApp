using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly MyAppContext  _context;

        public ItemsController(MyAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var item =await _context.Items.ToListAsync();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }
        
        public async Task<IActionResult> Edit(int Id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == Id);
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int Id,[Bind("Id,Name,Price")] Item item)
        {
            
            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == Id);
            return View(item);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var item = await _context.Items.FindAsync(Id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
               
            }
            return RedirectToAction("Index");
        }
       
    }
}
