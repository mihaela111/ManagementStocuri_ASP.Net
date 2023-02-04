using ManagementStocuri.Data;
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
            return View();
        }

        // GET: ProductController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController1/Create
        public ActionResult Create()
        {
            return View("CreateProduct");
        }

        // POST: ProductController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController1/Edit/5
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

        // GET: ProductController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController1/Delete/5
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
