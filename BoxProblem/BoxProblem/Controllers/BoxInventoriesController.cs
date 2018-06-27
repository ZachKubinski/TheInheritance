using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoxProblem.Data;
using BoxProblem.Services;

namespace BoxProblem.Controllers
{
    public class BoxInventoriesController : Controller
    {
        private BoxInventoryService service;

        public BoxInventoriesController(ApplicationDbContext context)
        {
            service = new BoxInventoryService(context);
        }

        // GET: BoxInventories
        public IActionResult Index()
        {
            return View(service.GetAllBoxes());
        }

        // GET: BoxInventories/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BoxInventory boxInventory = service.GetBoxById(id);
            if (boxInventory == null)
            {
                return NotFound();
            }

            return View(boxInventory);
        }

        // GET: BoxInventories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoxInventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Weight,Volume,CanHoldLiquid,Cost,InventoryCount,CreatedAt")] BoxInventory boxInventory)
        {
            if (ModelState.IsValid)
            {
                service.AddBox(boxInventory);
                return RedirectToAction("Index");
            }
            return View(boxInventory);
        }

        // GET: BoxInventories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BoxInventory boxInventory = service.GetBoxById(id);
            if (boxInventory == null)
            {
                return NotFound();
            }
            return View(boxInventory);
        }

        // POST: BoxInventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Weight,Volume,CanHoldLiquid,Cost,InventoryCount,CreatedAt")] BoxInventory boxInventory)
        {
            if (id != boxInventory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                service.SaveEdit(boxInventory);
                return RedirectToAction("Index");
            }
            return View(boxInventory);
        }

        // GET: BoxInventories/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BoxInventory boxInventory = service.GetBoxById(id);
            if (boxInventory == null)
            {
                return NotFound();
            }

            return View(boxInventory);
        }

        // POST: BoxInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            BoxInventory box = service.GetBoxById(id);
            service.DeleteBox(box);
            return RedirectToAction("Index");
        }
    }
}
