using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Context;
using Model.Product;
using Business.Product;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IBProduct _bProduct;

        public ProductsController(IBProduct bProduct)
        {
            _bProduct = bProduct;
        }

        // GET: ManualMovements
        public IActionResult Index()
        {
            var entity = _bProduct.GetListAll(x => true);
            return View(entity);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind()] Product entity)
        {
            if (ModelState.IsValid)
            {
                _bProduct.Add(entity);
                return RedirectToAction(nameof(Index));
            }

            return View(entity);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _bProduct.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind()] Product entity)
        {
            if (id != entity.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bProduct.Update(entity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(entity);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _bProduct.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int ProductId)
        {
            _bProduct.Delete(x => x.ProductId == ProductId);
            return RedirectToAction(nameof(Index));
        }
    }
}
