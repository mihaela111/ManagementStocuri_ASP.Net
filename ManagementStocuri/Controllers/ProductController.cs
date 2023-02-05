using ManagementStocuri.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementStocuri.Controllers
{
    public class ProductController : Controller
    {
        private Repository.ProductRepository _productRepository;

        public ProductController(ApplicationDbContext dbContext)
        {
            _productRepository = new Repository.ProductRepository(dbContext);
        }

        // GET: ProductController1
        public ActionResult Index()
        {
            var products=_productRepository.GetAllProducts();
            return View("Index", products);
        }

        // GET: ProductController1/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _productRepository.GetProductByID(id);

            return View("ProductDetails", model);
        }

        // GET: ProductController1/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {

            return View("CreateProduct");
        }

        // POST: ProductController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.ProductModel model = new Models.ProductModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _productRepository.InsertProduct(model);
                }
                
                return View("CreateProduct");
            }
            catch
            {
                return View("CreateProduct");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController1/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {
            var model = _productRepository.GetProductByID(id);
            return View("EditProduct", model);
        }

        // POST: ProductController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var model = new Models.ProductModel();
                var task=TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _productRepository.UpdateProduct(model);
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

        // GET: ProductController1/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            var model=_productRepository.GetProductByID(id);
            return View("DeleteProduct", model);
        }

        // POST: ProductController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _productRepository.DeleteProduct(id);
                return View("DeleteProduct");

            }
            catch
            {
                return View("DeleteProduct");
            }
        }
    }
}
