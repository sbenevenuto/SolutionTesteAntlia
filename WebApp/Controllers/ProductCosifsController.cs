﻿using System;
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
    public class ProductCosifsController : Controller
    {
        private readonly IBProductCosif _bProductCosif;

        public ProductCosifsController(IBProductCosif bProductCosif)
        {
            _bProductCosif = bProductCosif;
        }

        // GET: ManualMovements
        public IActionResult Index()
        {
            var entity = _bProductCosif.GetListAll(x => true);
            return View(entity);
        }

        // GET: ProductCosifs/Create
        public IActionResult Create()
        {            
            return View();
        }

        // POST: ProductCosifs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind()] ProductCosif entity)
        {
            if (ModelState.IsValid)
            {
                _bProductCosif.Add(entity);
                return RedirectToAction(nameof(Index));
            }

            return View(entity);
        }

        // GET: ProductCosifs/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _bProductCosif.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // POST: ProductCosifs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind()] ProductCosif entity)
        {
            if (id != entity.ProductCosifId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bProductCosif.Update(entity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(entity);
        }

        // GET: ProductCosifs/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _bProductCosif.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // POST: ProductCosifs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int ProductCosifId)
        {
            _bProductCosif.Delete(x => x.ProductCosifId == ProductCosifId);
            return RedirectToAction(nameof(Index));
        }
    }
}
