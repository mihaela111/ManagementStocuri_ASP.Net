using ManagementStocuri.Data;
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
            var suppliers=_supplierRepository.GetAllSuppliers();

            return View("Index", suppliers);
        }

        // GET: SupplierController/Details/5
        public ActionResult Details(Guid id)
        {
            var model=_supplierRepository.GetSupplierByID(id);
            return View("SupplierDetails", model);
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
        public ActionResult Edit(Guid id)
        {
            var model=_supplierRepository.GetSupplierByID(id);
            return View("EditSupplier", model);
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var model = new Models.SupplierModel(); 
                var task=TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result) 
                { 
                    _supplierRepository.UpdateSupplier(model);
                    return RedirectToAction("Index");
                }  
                else
                {
                    return RedirectToAction("Index", id);
                }
               
            }
            catch
            {
                return RedirectToAction("Index", id);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: SupplierController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _supplierRepository.GetSupplierByID(id);
            return View("DeleteSupplier", id);
        }

        // POST: SupplierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _supplierRepository.DeleteSupplier(id);
                return View("DeleteSupplier");

                
            }
            catch
            {
                return View("DeleteSupplier");
            }
        }
    }
}
