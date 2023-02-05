﻿using ManagementStocuri.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementStocuri.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SupplierController : Controller
    {
        private Repository.SupplierRepository _supplierRepository;

        public SupplierController(ApplicationDbContext dbContext)
        {
            _supplierRepository = new Repository.SupplierRepository(dbContext);
        }

        // GET: SupplierController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SupplierController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupplierController/Create
        public ActionResult Create()
        {
            return View("CreateSupplier");
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.SupplierModel model = new Models.SupplierModel();

                var task=TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _supplierRepository.InsertSupplier(model);
                }

                return View("CreateSupplier");
               
            }
            catch
            {
                return View("CreateSupplier");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: SupplierController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupplierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
