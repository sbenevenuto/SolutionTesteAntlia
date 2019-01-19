using Business.ManualMovement;
using Business.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.ManualMovement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class ManualMovementsController : Controller
    {
        private readonly IBManualMovement _bManualMovements;
        private readonly IBProduct _bProduct;
        private readonly IBProductCosif _bProductCosif;

        public ManualMovementsController(IBManualMovement bManualMovements, IBProduct bProduct, IBProductCosif bProductCosif)
        {
            _bManualMovements = bManualMovements;
            _bProduct = bProduct;
            _bProductCosif = bProductCosif;
        }

        // GET: ManualMovements
        public IActionResult Index()
        {
            var entity = _bManualMovements.GetIncludeNotPagination(x => true, x => new { x.Product, x.ProductCosif });
            return View(entity);
        }

        // GET: ManualMovements/Create
        public IActionResult Create()
        {
            var products = _bProduct.GetListAll(x => true);
            var productCosifs = _bProductCosif.GetListAll(x => true);
            ViewBag.ProductId = new SelectList(products, "ProductId", "Description");
            ViewBag.ProductCosifId = new SelectList(productCosifs, "ProductCosifId", "CodProductCosif");
            return View();
        }

        // POST: ManualMovements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind()] ManualMovement entity)
        {
            if (ModelState.IsValid)
            {
                _bManualMovements.Add(entity);
                return RedirectToAction(nameof(Index));
            }

            var products = _bProduct.GetListAll(x => true);
            var productCosifs = _bProductCosif.GetListAll(x => true);
            ViewBag.ProductId = new SelectList(products, "ProductId", "Description", entity.ProductId);
            ViewBag.ProductCosifId = new SelectList(productCosifs, "ProductCosifId", "CodProductCosif", entity.ProductCosifId);

            return View(entity);
        }

        // GET: ManualMovements/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _bManualMovements.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            var products = _bProduct.GetListAll(x => true);
            var productCosifs = _bProductCosif.GetListAll(x => true);
            ViewBag.ProductId = new SelectList(products, "ProductId", "Description", entity.ProductId);
            ViewBag.ProductCosifId = new SelectList(productCosifs, "ProductCosifId", "CodProductCosif", entity.ProductCosifId);

            return View(entity);
        }

        // POST: ManualMovements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind()] ManualMovement entity)
        {
            if (id != entity.ManualMovementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bManualMovements.Update(entity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }

            var products = _bProduct.GetListAll(x => true);
            var productCosifs = _bProductCosif.GetListAll(x => true);
            ViewBag.ProductId = new SelectList(products, "ProductId", "Description", entity.ProductId);
            ViewBag.ProductCosifId = new SelectList(productCosifs, "ProductCosifId", "CodProductCosif", entity.ProductCosifId);

            return View(entity);
        }

        // GET: ManualMovements/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _bManualMovements.GetIncludeNotPagination(x => x.ManualMovementId == id, x => new { x.Product, x.ProductCosif })?.FirstOrDefault();

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // GET: ManualMovements/Delete/5    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int ManualMovementId)
        {
            _bManualMovements.Delete(x => x.ManualMovementId == ManualMovementId);
            return RedirectToAction(nameof(Index));
        }        
    }
}
